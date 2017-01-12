'use strict';
var app = angular.module('echo');

app.controller('loginCtrl', function ($scope, $http, $filter, registerService) {
    $scope.registerUser = function (user) {
        var User = {
            Username: user.Username,
            Email: user.Email,
            Password: user.Password,
            FirstName: user.FirstName,
            LastName: user.LastName
        };
        registerService.AddUser(User).then(function (data) {
           
        });
    };
    var user =  {
        'username' : 'atumbul1',
        'password' : 'Password1!'
    };
    registerService.Login(user).then(function(data) {
        console.log(data);
    });

    registerService.GetCookie().then(function (data) {
        console.log(data);
    });


});


app.service('registerService', function ($http) {
    var fac = {};
    fac.AddUser = function (User) {
        return $http({
            url: 'http://do.mac.ba:8888/BusinessLogic/Account.svc/json/register',
            method: 'POST',
            data: JSON.stringify(User)
        });
    };

    fac.GetCookie = function() {
        return $http({
            url: 'http://do.mac.ba:8888/BusinessLogic/Account.svc/json/auth',
            method: 'GET'
        });
    }
    fac.Login = function (user) {
        return $http({
            url: 'http://do.mac.ba:8888/BusinessLogic/Account.svc/json/login',
            method: 'POST',
            data: JSON.stringify(user)
        });
    }
    return fac;
});