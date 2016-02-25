﻿//angular.module('BackgroundInfo.EditBackgroundInfoController', ['ui.router']);
personalInfoModule.controller('EditBackgroundInfoCtrl', function ($scope, $filter, $state, personalInfoService) {
    var id = personalInfoService.getSharedProperty();
    var info = personalInfoService.getBackgroundInfoByID(id);
    info.then(function (data) {
        $scope.BackgroundInfoModel = data.data;
        $scope.BackgroundInfoModel.startDate = new Date(parseInt(data.data.startDate.substr(6)));
        $scope.BackgroundInfoModel.endDate = new Date(parseInt(data.data.endDate.substr(6)));
        //console.log($scope.BackgroundInfoModel);
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

    $scope.UpdateBackgroundInfo = function () {
        $scope.BackgroundInfoModel.startDate = $filter('date')($scope.BackgroundInfoModel.startDate, 'yyyy-MM-dd');
        $scope.BackgroundInfoModel.endDate = $filter('date')($scope.BackgroundInfoModel.endDate, 'yyyy-MM-dd');
        var editBackgroundInfo = personalInfoService.updateBackgroundInfo($scope.BackgroundInfoModel);
        $state.go('ShowCurrentPosition');
    }

    $scope.Cancel = function () {
        window.history.back();
    }
});