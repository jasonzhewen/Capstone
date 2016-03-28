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
        console.log($scope.CurrentPositionModel);
        var add = personalInfoService.addCurrentPosition($scope.CurrentPositionModel);
        add.then(function (mess) {
            $state.go('ShowCurrentPosition');
        })
        
    }

    $scope.Cancel = function () {
        window.history.back();
    }
});