personalInfoModule.controller('EditCurrentPositionCtrl', function ($scope,$filter,$state, personalInfoService) {
    //$scope.$watch('CurrentPositionModel.startDate', function (newValue) {
    //    $scope.CurrentPositionModel.startDate = $filter('date')(newValue, 'yyyy-MM-dd');
    //});

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

    var GetCurrentPosition = personalInfoService.getCurrentPosition();
    GetCurrentPosition.then(function (data) {
        if (data.data !== "") {
            $scope.CurrentPositionModel.ID = data.data.ID;
            $scope.CurrentPositionModel.type = data.data.type;
            $scope.CurrentPositionModel.title = data.data.title;
            $scope.CurrentPositionModel.startDate = new Date(parseInt(data.data.startDate.substr(6)));
            $scope.CurrentPositionModel.description = data.data.description;
            $scope.CurrentPositionModel.UserInfoID = data.data.UserInfoID;
        }
    });

    $scope.UpdateCurrentPosition = function () {
        $scope.CurrentPositionModel.isCurrentPosition = true;
        $scope.CurrentPositionModel.startDate = $filter('date')($scope.CurrentPositionModel.startDate, 'yyyy-MM-dd');
        var editCurrentPosition = personalInfoService.updateCurrentPosition($scope.CurrentPositionModel);
        $state.go('ShowCurrentPosition');
    }

    $scope.Cancel = function () {
        window.history.back();
    }
});