const eventController = function () {

    const getCreateEvent = function (context) {

        ///NAV_BAR_INFO
        const loggedIn = storage.getData('userInfo') !== null;
        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
        }
        ///...

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        }).then(function () {
            this.partial('../views/events/create-event-form.hbs')
        })
    };

    const postCreateEvent = function (context) {
        let formData = context.params;
        //data.name;
        //data.dateTime;
        //data.description;
        //data.imageURL;

        const loggedIn = storage.getData('userInfo') !== null;
        if (loggedIn == false) {
            return;
        }
        username = JSON.parse(storage.getData('userInfo')).username;

        formData.peopleInterestedIn = 0;
        formData.organizer = username;

        console.lo;

        ///VALIDATIONS
        if (formData.name.length < 6) {
            console.log("Name length must be atleast 6 characters long!");
        } else if (dateValidation(formData.dateTime) == false) {
            console.log("Invalid Date! Should be in the format [24 February] or [24 March - 10 PM]");
        } else if (formData.description.length < 10) {
            console.log("Description must be atleast 10 characters long!");
        } else if (!formData.imageURL.startsWith("http://") && !formData.imageURL.startsWith("https://")) {
            console.log("Image Url must start with http:// or https://");
        } else {
            ///...
            eventModel.create(formData)
                .then(helper.handler)
                .then((data) => {
                    console.log(data);
                    homeController.getHome(context);
                })
        }
    }

    const getEventDetails = async function (context) {

        ///NAV_BAR_INFO
        const loggedIn = storage.getData('userInfo') !== null;
        let username2;
        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            username2 = username;
            context.loggedIn = loggedIn;
            context.username = username;
        }
        ///...

        try {
            let eventId = context.params.eventId;
            let response = await eventModel.getSingle(eventId);
            let event = await response.json();

            context.isOwner = event.organizer === username2;

            for (const key in event) {
                context[key] = event[key];
            }

            context.loadPartials({
                header: "../views/common/header.hbs",
                footer: "../views/common/footer.hbs"
            }).then(function () {
                this.partial('../views/events/event-details.hbs')
            })

        } catch (e) {
            alert("Problem Fetching Event Data");
            console.log(e);
        }

    }

    const getDeleteEvent = async function (context) {
        let eventId = context.params.eventId;
        console.log(eventId);
        let response = await eventModel.deleteEvent(eventId);
        let delResult = await response.json();
        ///redirect to home; 
        homeController.getHome(context);
    }

    const getEditEvent = async function (context) {
        ///NAV_BAR_INFO
        const loggedIn = storage.getData('userInfo') !== null;
        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
        }
        ///...

        let eventId = context.params.eventId;
        let response = await eventModel.getSingle(eventId);
        let event = await response.json();

        for (const key in event) {
            context[key] = event[key];
        }

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        }).then(function () {
            this.partial('../views/events/edit-event-form.hbs')
        })
    }

    const postEditEvent = function (context) {
        console.log("post edit event");
        let eventId = context.params.eventId;
        let data = { ...context.params };
        delete data.eventId;
        console.log("before create response");
        // let response = await eventModel.create(data);
        eventModel.edit(data, eventId)
            .then(helper.handler)
            .then(data => {
                console.log(data);
                console.log("after response");
                context.redirect("#", "home");
            });
    }

    const getJoinEvent = async function (context) {
        let eventId = context.params.eventId;
        let response = await eventModel.getSingle(eventId);
        let event = await response.json();

        event.peopleInterestedIn = Number(event.peopleInterestedIn) + 1;

        let putResponse = await eventModel.edit(event, eventId);
        let jsonPutResponse = await putResponse.json();

        ///refreshing the count
        context.redirect("#", "eventDetails", eventId);
    }

    const getUserProfile = async function (context) {
        ///NAV_BAR_INFO
        let username;
        const loggedIn = storage.getData('userInfo') !== null;
        if (loggedIn) {
            username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
        }
        ///...

        var response = await eventModel.getAll(); 
        var events = await response.json();
        events = events.filter(x => x.organizer == username);
        let eventNames = events.map(x => x.name);
        
        context.events = eventNames;
        context.eventsCount = eventNames.length; 

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
        }).then(function () {
            this.partial('../views/user/user-details.hbs')
        })
    }

    return {
        getCreateEvent,
        postCreateEvent,
        getEventDetails,
        getDeleteEvent,
        getEditEvent,
        postEditEvent,
        getJoinEvent,
        getUserProfile
    }
}();

function dateValidation(string) {
    let validMonths = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    let validTimeOfDayAbr = ["PM", "AM"];
    let tokens = string.split(/[ -]/g).filter(x => x !== "");
    console.log(tokens);
    if (tokens.length != 2 && tokens.length != 4) {
        console.log("split length is not 2 or 4");
        return false;
    }

    if (!+tokens[0]) {
        console.log("Day of month is not a number!");
        return false;
    }

    if (!validMonths.includes(tokens[1])) {
        console.log("Month is not valid!");
        return false;
    }

    if (tokens.length === 4) {
        if (!+tokens[2]) {
            console.log("hout is not number!");
            return false;
        }

        if (!validTimeOfDayAbr.includes(tokens[3])) {
            console.log("PM not right!");
            return false;
        }
    }

    return true;
}