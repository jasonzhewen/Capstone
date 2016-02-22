personalInfoModule.controller('AddPersonalInfoCtrl', function ($scope, $state, $filter, personalInfoService) {

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

    $scope.realdate = '';

    $scope.AddPersonalInfo = function () {
        $scope.PersonalDetailsModel.dateOfBirth = $filter('date')($scope.realdate, "yyyy-MM-dd");
        //console.log($scope.realdate);
        var callBack = personalInfoService.addPersonalDetails($scope.PersonalDetailsModel);        
        $state.go('ShowInfo');        
    }

    $scope.Cancel = function () {
        window.history.back();
    }
});