'use strict';
var app = angular.module('echo');

app.controller('Ctrl3', function ($scope, $http, collectionService) {
    $scope.collectionList = [];
    $scope.collection = {
        title : "",
        description: "",
        isprivate: false
    };
    collectionService.GetCollections().then(function (data) {
        for (var i = 0; i < data.data.length; i++) {
            var obj = {
                title: data.data[i].Title,
                description: data.data[i].Description,
                isprivate: data.data[i].IsPrivate
            }
            $scope.collectionList.push(obj);
        }
    });
  

    $scope.createCollection = function (item) {
        $scope.collectionList.push(item);
        var Collection = {
            title: item.title,
            description: item.description,
            isprivate: item.isprivate
        };
        collectionService.AddCollection(Collection).then(function (data) {
            // TODO callback, handle success/error
        });
        $scope.clear();
    };

    $scope.clear = function () {
        $scope.collection = {
            title: "",
            description: "",
            isprivate: false
        };
    }
});


// Move this into separate js
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
    fac.GetCollections = function (collection) {
        return $http({
            url: serviceBase + 'api/Collection/GetCollections',
            method: 'GET'
        });
    };
    return fac;

});
