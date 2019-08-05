const homeController = function () {

    const getHome = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;
        if(loggedIn){
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
        }

        if (!loggedIn) {
            renderLoggedOutHome(context);
        } else {
            var response = await eventModel.getAll(); 
            var events = await response.json(); 
            
            if (events.length > 0) {
                context.events = events;
                context.loadPartials({
                    "event-card": "../views/events/event-card.hbs",
                    header: "../views/common/header.hbs",
                    footer: "../views/common/footer.hbs"
                }).then(function () {
                    this.partial('../views/home/homeLoggedIn.hbs')
                })
            } else {
                context.loadPartials({
                    header: "../views/common/header.hbs",
                    footer: "../views/common/footer.hbs"
                }).then(function () {
                    this.partial('../views/home/home-not-found.hbs')
                })
            }
        }
    };

    return {
        getHome
    }
}();

function renderLoggedOutHome(context) {
    context.loadPartials({
        header: "../views/common/header.hbs",
        footer: "../views/common/footer.hbs"
    }).then(function () {
        this.partial('../views/home/home.hbs')
    })
}