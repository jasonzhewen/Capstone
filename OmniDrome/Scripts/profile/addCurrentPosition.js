personalInfoModule.controller('AddCurrentPositionCtrl', function ($scope, $state, $filter, personalInfoService) {
    $scope.$watch('CurrentPositionModel.startDate', function (newValue) {
        $scope.CurrentPositionModel.startDate = $filter('date')(newValue, 'yyyy-MM-dd');
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

    $scope.AddCurrentPosition = function () {
        //$scope.CurrentPositionModel.startDate = $filter('date')(new Date($scope.CurrentPositionModel.startDate), "yyyy-MM-dd");
        personalInfoService.addCurrentPosition($scope.CurrentPositionModel);
        $state.go('ShowCurrentPosition');
        console.log($scope.CurrentPositionModel);
    }

    $scope.Cancel = function () {
        window.history.back();
    }
});