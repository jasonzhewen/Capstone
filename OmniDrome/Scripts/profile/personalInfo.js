var personalInfoModule = angular.module('PersonalInfo', ['ui.router']);
personalInfoModule.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');

    $stateProvider
    .state('ShowInfo', {
        url: '/',
        views: {
            'mainProfile': {
                templateUrl: '/Profile/ShowInfo',
                controller: 'ShowPersonalInfoCtrl'
            },
            'timeLine': {
                templateUrl: '/Profile/ShowBackgroundInfo',
                controller: 'ShowBackgroundInfoCtrl'
            }
        }
    })

    .state('AddInfo', {
        url: '/AddInfo',
        views: {
            'mainProfile': {
                templateUrl: '/Profile/AddInfo',
                controller: 'AddPersonalInfoCtrl'
            },
            'timeLine': {
                templateUrl: '/Profile/ShowBackgroundInfo',
                controller: 'ShowBackgroundInfoCtrl'
            }
        }
    })

    .state('EditInfo', {
        url: '/EditInfo',
        views: {
            'mainProfile': {
                templateUrl: '/Profile/EditInfo',
                controller: 'EditPersonalInfoCtrl'
            },
            'timeLine': {
                templateUrl: '/Profile/ShowBackgroundInfo',
                controller: 'ShowBackgroundInfoCtrl'
            }
        }
    })

    .state('ShowBackgroundInfo', {
        url: '/ShowBackgroundInfo',
        views: {
            'mainProfile': {
                templateUrl: '/Profile/ShowInfo',
                controller: 'ShowPersonalInfoCtrl'
            },
            'timeLine': {
                templateUrl: '/Profile/ShowBackgroundInfo',
                controller: 'ShowBackgroundInfoCtrl'
            }
        }
    })

    .state('AddBackgroundInfo', {
        url: '/AddBackgroundInfo',
        views: {
            'mainProfile': {
                templateUrl: '/Profile/ShowInfo',
                controller: 'ShowPersonalInfoCtrl'
            },
            'timeLine': {
                templateUrl: '/Profile/AddBackgroundInfo',
                controller: 'AddBackgroundInfoCtrl'
            }
        }
    })

    .state('EditBackgroundInfo', {
        url: '/EditBackgroundInfo',
        views: {
            'mainProfile': {
                templateUrl: '/Profile/ShowInfo',
                controller: 'ShowPersonalInfoCtrl'
            },
            'timeLine': {
                templateUrl: '/Profile/EditBackgroundInfo',
                controller: 'EditBackgroundInfoCtrl'
            }
        }
    })
}]);