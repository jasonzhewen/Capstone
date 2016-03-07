//angular.module('BackgroundInfo.ShowBackgroundInfoController', ['ui.router']);
personalInfoModule.controller('ShowBackgroundInfoCtrl', function ($scope, $state, personalInfoService) {
    //$scope.BackgroundInfoModel =
    //    {
    //        ID: '',
    //        type: '',
    //        title: '',
    //        startDate: '',
    //        endDate: '',
    //        description: '',
    //        isCurrentPosition: '',
    //        UserInfoID: ''
    //    };
    //$scope.BackgroundInfoList = {};
    
    //var GetBackgroundInfo = personalInfoService.getBackgroundInfo();
    //GetBackgroundInfo.then(function (data) {
    //    $scope.BackgroundInfoList = data.data;
    //    //console.log(data);
    //});
    $scope.AddBackgroundInfo = function () {     
        $state.go('AddBackgroundInfo');
    };

    $scope.EditBackgroundInfo = function (id) {
        //console.log($scope.BackgroundInfoModel);
        personalInfoService.setSharedProperty(id);
        $state.go('EditBackgroundInfo');
    };

    $scope.DeleteBackgroundInfo = function (id) {
        personalInfoService.deleteBackgroundInfo(id);
        $state.go('ShowBackgroundInfo');
    };

    $scope.Cancel = function () {
        window.history.back();
    };

});