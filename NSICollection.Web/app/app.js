(function(){

  // Declare app level module which depends on views, and components
  var app = angular.module('echo', ['ngRoute']);
  
  app.config(function($routeProvider) {
        $routeProvider            
            .when('/', {
                templateUrl : 'views/home.html',
                controller  : 'homeCtrl'
            })
             .when('/addCollection', {
                templateUrl : 'views/addCollection.html',
                controller  : 'Ctrl3'
            })            
            .when('/login', {
                templateUrl : 'views/loginForm.html',
                controller  : 'loginCtrl'
            });

            
    });


    

})();