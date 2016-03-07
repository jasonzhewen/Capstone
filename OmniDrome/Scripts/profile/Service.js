personalInfoModule.service("personalInfoService", function ($http) {
    var property = '';
    this.getSharedProperty = function () {
        return property;
    }
    this.setSharedProperty = function (value) {
        property = value;
    }

    this.getPersonalInfo = function () {
        return $http.get('/Profile/GetInfoData');
    }

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

    //this.getBackgroundInfo = function () {
    //    return $http.get('/Profile/GetBackgroundInfoData');
    //};

    this.addBackgroundInfo = function (BackgroundInfo) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/AddBackgroundInfo",
            data: JSON.stringify({ BackgroundInfoClient: BackgroundInfo }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        //return ServerData;
    }

    this.getBackgroundInfoByID = function (infoid) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/GetBackgroundInfoByInfoID",
            data: JSON.stringify({ id: infoid }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        return ServerData;
    }

    this.updateBackgroundInfo = function (BackgroundInfo) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/UpdateBackgroundInfo",
            data: JSON.stringify({ BackgroundInfoClient: BackgroundInfo }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        //return ServerData;
    }

    this.deleteBackgroundInfo = function (infoID) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/DeleteBackgroundInfo",
            data: JSON.stringify({ id: infoID }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        return ServerData;
    }

    this.getCurrentPosition = function () {
        return $http.get('/Profile/GetCurrentPosition');
    }

    this.addCurrentPosition = function (BackgroundInfo) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/AddCurrentPositionData",
            data: JSON.stringify({ BackgroundInfoClient: BackgroundInfo }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        //return ServerData;
    }

    this.updateCurrentPosition = function (BackgroundInfo) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/UpdateCurrentPosition",
            data: JSON.stringify({ CurrentPositionClient: BackgroundInfo }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        //return ServerData;
    }

    this.getJobTitles = function (searchString) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/GetTenTitles",
            data: JSON.stringify({ searchStringClient: searchString }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        return ServerData;
    }


    this.getDutiesForTitle = function (noc) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/GetSuggestedDuties",
            data: JSON.stringify({ NocCode: noc }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        return ServerData;
    }



    this.getReqForTitle = function (noc) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/GetRequirements",
            data: JSON.stringify({ NocCode: noc }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        return ServerData;
    }




    this.getDreamJobInfo = function () {
        return $http.get('/Profile/CtrlGetDreamJob');
    }

    this.addDreamJobInfo = function (DreamJob) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/AddDreamJobDetails",
            data: JSON.stringify({ DreamJobClient: DreamJob }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        //return ServerData;
    }

    this.deleteDreamJob = function (dreamjobinfoID) {
        var ServerData = $http({
            method: "Post",
            url: "/Profile/DeleteDreamJobInfo",
            data: JSON.stringify({ id: dreamjobinfoID }),
            dataType: 'json',
            //contentType: 'application/json',
        });
        return ServerData;
    }
});