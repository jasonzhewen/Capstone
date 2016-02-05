angular.module('BackgroundInfo.AddBackgroundInfoController', ['ui.router']);
personalInfoModule.controller('AddBackgroundInfoCtrl', function ($scope) {

    $scope.Cancel = function () {
        window.history.back();
    }
});