personalInfoModule.service("personalInfoService", function ($http) {
    this.getPersonalInfo = function () {
        return $http.get('/Profile/GetInfoData');
    };

    this.addPersonalDetails = function (PersonalDetailsModel) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/AddPersonalInfo",
            data: JSON.stringify({ PersonalDetailsModelClient: PersonalDetailsModel }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        //return ServerData;
    }

    this.updatePersonalDetails = function (PersonalDetailsModel) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/UpdatePersonalInfo",
            data: JSON.stringify({ PersonalDetailsModelClient: PersonalDetailsModel }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        return ServerData;
    }

    this.getBackgroundInfo = function () {
        return $http.get('/Profile/GetBackgroundInfoData');
    };
});