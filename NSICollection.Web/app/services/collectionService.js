'use strict';

var app = angular.module('echo');

app.service('collectionService', function ($http) {
    var fac = {};
    var serviceBase = 'http://localhost:60824/';
    fac.AddCollection = function (collection) {
        return $http({
            url: serviceBase + 'api/Collection/AddCollection',
            method: 'POST',
            data: JSON.stringify(collection)
        });
    };
    return fac;

});
