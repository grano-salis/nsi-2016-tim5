(function () {

    // Declare app level module which depends on views, and components
    var app = angular.module('echo', ['ngRoute']);

    app.config(function ($routeProvider) {
        $routeProvider
        .when('/', {
            templateUrl: 'views/home.html',
            controller: 'homeCtrl'
        })
        .when('/addCollection', {
            templateUrl: 'views/addCollection.html',
            controller: 'Ctrl3'
        })
        .when('/login', {
            templateUrl: 'views/loginForm.html',
            controller: 'loginCtrl'
        })

        .when('/addItem', {
            templateUrl: 'views/addItem.html',
            controller: 'itemCtrl'
        })
        .when('/library', {
            templateUrl: 'views/library.html',
            controller: 'libraryCtrl'
        })
        .when('/exportItem', {
            templateUrl: 'views/exportItem.html',
            controller: 'exportCtrl'
        });
    });


    var serviceBase = "";

    if (window.location.origin.search("localhost") == -1) {
        serviceBase = window.location.origin + "/api/";
    } else {
        serviceBase = 'http://localhost:60824/';
    }

    app.constant('ngAuthSettings', {
        apiServiceBaseUri: serviceBase,
        clientId: 'ngAuthApp'
    });

    app.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.defaults.useXDomain = true;
        delete $httpProvider.defaults.headers.common['X-Requested-With'];
    }
    ]);
})();