personalInfoModule.controller('AddBackgroundInfoCtrl', function ($scope, $state, $filter, personalInfoService) {
    $scope.$watch('BackgroundInfoModel.startDate', function (newValue) {
        $scope.BackgroundInfoModel.startDate = $filter('date')(newValue, 'yyyy-MM-dd');
    });
    $scope.$watch('BackgroundInfoModel.endDate', function (newValue) {
        $scope.BackgroundInfoModel.startDate = $filter('date')(newValue, 'yyyy-MM-dd');
    });

    $scope.BackgroundInfoModel =
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

    $scope.AddBackgroundInfo = function () {
        //$scope.CurrentPositionModel.startDate = $filter('date')(new Date($scope.CurrentPositionModel.startDate), "yyyy-MM-dd");
        personalInfoService.addBackgroundInfo($scope.BackgroundInfoModel);
        $state.go('ShowBackgroundInfo');
    }

    $scope.Cancel = function () {
        window.history.back();
    }
});