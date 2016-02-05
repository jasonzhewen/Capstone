angular.module('BackgroundInfo.EditBackgroundInfoController', ['ui.router']);
personalInfoModule.controller('EditBackgroundInfoCtrl', function ($scope) {

    $scope.Cancel = function () {
        window.history.back();
    }
});