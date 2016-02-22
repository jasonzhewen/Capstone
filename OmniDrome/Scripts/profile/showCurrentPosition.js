personalInfoModule.controller('ShowCurrentPositionCtrl', function ($scope,$filter,$state, personalInfoService) {
    
    var GetCurrentPosition = personalInfoService.getCurrentPosition();
    GetCurrentPosition.then(function (data) {
        //console.log(data);
        if (data.data !== "") {
            $scope.CurrentPositionModel.ID = data.data.ID;
            $scope.CurrentPositionModel.UserInfoID = data.data.UserInfoID;
            $scope.CurrentPositionModel.type = data.data.type;
            $scope.CurrentPositionModel.title = data.data.title;
            $scope.CurrentPositionModel.startDate = $filter('date')(new Date(parseInt(data.data.startDate.substr(6))), "yyyy-MM-dd");
            $scope.CurrentPositionModel.description = data.data.description;
            //console.log($scope.CurrentPositionModel.startDate);
        }
    });

    $scope.CurrentPositionModel =
        {
            ID: '',
            type: '',
            title: '',
            startDate: '',
            endDate: '',
            description: '',
            isCurrentPosition: '',
            UserInfoID: ''
        };

    $scope.Edit = function () {       
        $state.go('EditCurrentPosition');
    };

    $scope.Done = function () {
        $scope.CurrentPositionModel.endDate = $filter('date')(new Date(), "yyyy-MM-dd");
        $scope.CurrentPositionModel.isCurrentPosition = false;
        var DoneCurrentPosition = personalInfoService.updateCurrentPosition($scope.CurrentPositionModel);
        $state.go('ShowCurrentPosition');
    };

    $scope.isEmpty = function (obj) {
        var isEmpty = true;
        angular.forEach(obj, function (value, key) {
            if (value !== '') {
                isEmpty = false;
            }
        });
        return isEmpty;
    };

});