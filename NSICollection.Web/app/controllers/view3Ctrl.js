'use strict';
var app = angular.module('echo');

app.controller('Ctrl3', function ($scope, $http, collectionService, $timeout) {
    $scope.collectionList = [];
    $scope.collection = {
        title : "",
        description: "",
        isprivate: false
    };
    $scope.message = "";
    collectionService.GetCollections().then(function (data) {
        var col = data.data.collections;
        for (var i = 0; i < col.length; i++) {
            var obj = {
                title:col[i].Title,
                description:col[i].Description,
                isprivate: col[i].IsPrivate
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
            $scope.message = "Collection was successfuly created";
        });
       

        $timeout(function () { $scope.callAtTimeout(); }, 3000);
        $scope.clear();
    };

    $scope.callAtTimeout = function () {
        console.log("$scope.callAtTimeout - Timeout occurred");
    }
    $scope.clear = function () {
        $scope.collection = {
            title: "",
            description: "",
            isprivate: false
        };
        $scope.message = "";
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
