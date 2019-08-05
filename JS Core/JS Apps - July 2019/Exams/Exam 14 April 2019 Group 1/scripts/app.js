const app = Sammy("#main", function () {

    this.use('Handlebars', 'hbs');

    /// Home
    this.get('#/home', homeController.getHome);
    ///...

    /// User
    this.get('#/register', userController.getRegister);
    this.get('#/login', userController.getLogin);

    this.post('#/register', userController.postRegister);
    this.post('#/login', userController.postLogin);
    this.get('#/logout', userController.logout);
    ///...

    ///CREATE_EVENT
    this.get("#/createEvent", eventController.getCreateEvent);
    this.post("#/createEvent", eventController.postCreateEvent);


    this.get("#/eventDetails/:eventId", eventController.getEventDetails);
    this.get("#/deleteEvent/:eventId", eventController.getDeleteEvent)
    this.get("#/editEvent/:eventId", eventController.getEditEvent); 
    this.post("#/editEvent/:eventId", eventController.postEditEvent); 
    this.get("#/joinEvent/:eventId", eventController.getJoinEvent);

    ///USER_PROFILE
    this.get("#/userProfile", eventController.getUserProfile)
});

(() => {
    app.run('#/home');
})();