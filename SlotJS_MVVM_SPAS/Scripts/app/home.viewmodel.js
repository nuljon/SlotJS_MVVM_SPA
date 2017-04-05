function HomeViewModel(app, dataModel) {
    var self = this;
    self.creditLog = 0;
    self.credit = ko.observable("");
    self.player = ko.observable("");
    self.userid = ko.observable("");

    //  get the player data and set our game globals as self...
    Sammy(function () {
        this.get('#home', function () {
            // Make a call to the protected Web API by passing in a Bearer Authorization Header
            $.ajax({
                method: 'get',
                url: app.dataModel.userInfoUrl,
                contentType: "application/json; charset=utf-8",
                headers: {
                    'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                },
                success: function (data) {
                    self.player(data.playerName);
                    self.credit(data.credits * 1);
                    self.creditLog = data.credits * 1;
                    self.userid = data.userid;
                }
            });
        });
        this.get('/', function () { this.app.runRoute('get', '#home'); });
    });

    // update db method called by a click event
    self.UpdateCredits = function (event) {

        var userpara = { id: app.Views.Home.userid, cred: app.Views.Home.credit() }

        // reset the creditLog
        app.Views.Home.creditLog = app.Views.Home.credit();

        // update db with a PUT call using json
        $.ajax({
            url: "api/Me/" + app.Views.Home.userid,
            type: "PUT",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(userpara),
            headers: {
                'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
            },
           /* success: function (data) {
                alert("successful update");
            },
            error: function (err) {
                alert('Error');
            } */
        });
    };
  
    return self;
}

// on logout click event 
app.logout = function (event) {

    // submit the logout form by referencing the id in the view html tag
    $('#logoutForm').submit();
    // drop our asccess token
    sessionStorage.removeItem('accessToken');
};


// on change password click event 
app.xpassword = function (event) {

    // submit the changpassword form by referencing the id in the view html tag
    $('#xPasswordForm').submit();
};


//$('#xPassword').on('click', app.xpassword);
$('#logout').on('click', app.logout);

app.addViewModel({
    name: "Home",
    bindingMemberName: "home",
    factory: HomeViewModel
});
