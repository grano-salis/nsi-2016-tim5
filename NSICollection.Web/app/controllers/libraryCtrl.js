'use strict';
var app = angular.module('echo');

app.controller('libraryCtrl', function ($scope, $http, libraryService) {

    libraryService.GetCollectionItems().then(function (data) {
        for (var i = 0; i < data.data.length; i++) {
            var obj = {
                title: data.data[i].Title,
                description: data.data[i].Description,
                isprivate: data.data[i].IsPrivate,

            }
        }
        $scope.collectionItemsList = data;
    });
});

// Move this into separate js
app.service('libraryService', function ($http) {
    var fac = {};
    var serviceBase = 'http://localhost:60824/';
    fac.GetCollectionItems = function (library) {
        return $http({
            url: serviceBase + 'api/Library/GetCollectionItems',
            method: 'GET'
        });
    };
    return fac;

});