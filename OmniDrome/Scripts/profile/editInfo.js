personalInfoModule.controller('EditPersonalInfoCtrl', function ($scope, personalInfoService, $state, $filter) {

    $scope.PersonalDetailsModel =
       {
           ID:'',
           firstName: '',
           lastName: '',
           contactNumber: '',
           profession: '',
           currentCity: '',
           currentCountry: '',
           dateOfBirth: '',
           imageUrl: ''
       };

    $scope.realdate = '';

    var GetInfo = personalInfoService.getPersonalInfo();
    //console.log(GetInfo);
    GetInfo.then(function (data) {
        $scope.PersonalDetailsModel.ID = data.data.personalDetailsModel.ID;
        $scope.PersonalDetailsModel.firstName = data.data.personalDetailsModel.firstName;
        $scope.PersonalDetailsModel.lastName = data.data.personalDetailsModel.lastName;
        $scope.PersonalDetailsModel.contactNumber = data.data.personalDetailsModel.contactNumber;
        $scope.PersonalDetailsModel.profession = data.data.personalDetailsModel.profession;
        $scope.PersonalDetailsModel.currentCity = data.data.personalDetailsModel.currentCity;
        $scope.PersonalDetailsModel.currentCountry = data.data.personalDetailsModel.currentCountry;        
        $scope.PersonalDetailsModel.dateOfBirth = data.data.personalDetailsModel.dateOfBirth;
        $scope.realdate = new Date($scope.PersonalDetailsModel.dateOfBirth);
        $scope.PersonalDetailsModel.imageUrl = data.data.personalDetailsModel.imageUrl;
        //console.log($scope.PersonalDetailsModel);
    });

    $scope.EditPersonalInfo = function () {
        $scope.PersonalDetailsModel.dateOfBirth = $filter('date')($scope.realdate, "yyyy-MM-dd");
        //console.log($scope.PersonalDetailsModel);
        var callBack = personalInfoService.updatePersonalDetails($scope.PersonalDetailsModel);
        callBack.then(function (mess) {
            $state.go('ShowInfo');
        })       
    }

    $scope.Cancel = function () {
        window.history.back();
    }

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