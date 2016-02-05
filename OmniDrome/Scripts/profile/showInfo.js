personalInfoModule.controller('ShowPersonalInfoCtrl', function ($scope, personalInfoService) {

    $scope.PersonalDetailsModel =
        {
            firstName: '',
            lastName: '',
            contactNumber: '',
            profession: '',
            currentCity: '',
            currentCountry: '',
            dateOfBirth: '',
            imageUrl: ''
        };

    var GetInfo = personalInfoService.getPersonalInfo();
    GetInfo.then(function (data) {
        $scope.PersonalDetailsModel.firstName = data.data.personalDetailsModel.firstName;
        $scope.PersonalDetailsModel.lastName = data.data.personalDetailsModel.lastName;
        $scope.PersonalDetailsModel.contactNumber = data.data.personalDetailsModel.contactNumber;
        $scope.PersonalDetailsModel.profession = data.data.personalDetailsModel.profession;
        $scope.PersonalDetailsModel.currentCity = data.data.personalDetailsModel.currentCity;
        $scope.PersonalDetailsModel.currentCountry = data.data.personalDetailsModel.currentCountry;
        $scope.PersonalDetailsModel.dateOfBirth = data.data.personalDetailsModel.dateOfBirth;
        $scope.PersonalDetailsModel.imageUrl = data.data.personalDetailsModel.imageUrl;
    });

    $scope.isEmpty = function (obj) {
        var isEmpty = true;
        angular.forEach(obj, function (value, key) {
            if (value !== null) {
                isEmpty = false;
            }
        });
        return isEmpty;
    };
});