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
            },
            'currentPosition': {
                templateUrl: '/Profile/CurrentPosition',
                controller: 'ShowCurrentPositionCtrl'
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
            },
            'currentPosition': {
                templateUrl: '/Profile/CurrentPosition',
                controller: 'ShowCurrentPositionCtrl'
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
            },
            'currentPosition': {
                templateUrl: '/Profile/CurrentPosition',
                controller: 'ShowCurrentPositionCtrl'
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
            },
            'currentPosition': {
                templateUrl: '/Profile/CurrentPosition',
                controller: 'ShowCurrentPositionCtrl'
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
            },
            'currentPosition': {
                templateUrl: '/Profile/CurrentPosition',
                controller: 'ShowCurrentPositionCtrl'
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
            },
            'currentPosition': {
                templateUrl: '/Profile/CurrentPosition',
                controller: 'ShowCurrentPositionCtrl'
            }
        }
    })

    .state('ShowCurrentPosition', {
        url: '/ShowCurrentPosition',
        views: {
            'mainProfile': {
                templateUrl: '/Profile/ShowInfo',
                controller: 'ShowPersonalInfoCtrl'
            },
            'timeLine': {
                templateUrl: '/Profile/ShowBackgroundInfo',
                controller: 'ShowBackgroundInfoCtrl'
            },
            'currentPosition': {
                templateUrl: '/Profile/CurrentPosition',
                controller: 'ShowCurrentPositionCtrl'
            }
        }
    })

    .state('AddCurrentPosition', {
        url: '/AddCurrentPosition',
        views: {
            'mainProfile': {
                templateUrl: '/Profile/ShowInfo',
                controller: 'ShowPersonalInfoCtrl'
            },
            'timeLine': {
                templateUrl: '/Profile/ShowBackgroundInfo',
                controller: 'ShowBackgroundInfoCtrl'
            },
            'currentPosition': {
                templateUrl: '/Profile/AddCurrentPosition',
                controller: 'AddCurrentPositionCtrl'
            }
        }
    })

    .state('EditCurrentPosition', {
        url: '/EditCurrentPosition',
        views: {
            'mainProfile': {
                templateUrl: '/Profile/ShowInfo',
                controller: 'ShowPersonalInfoCtrl'
            },
            'timeLine': {
                templateUrl: '/Profile/ShowBackgroundInfo',
                controller: 'ShowBackgroundInfoCtrl'
            },
            'currentPosition': {
                templateUrl: '/Profile/EditCurrentPosition',
                controller: 'EditCurrentPositionCtrl'
            }
        }
    })
}]);