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

    $scope.showCollection = function (collection) {
        $scope.showMetadataFlag = false;
        $scope.showCollectionFlag = true;
        $scope.collection = collection;
    };
    $scope.showMetadata = function (item) {
        $scope.showCollectionFlag = false;
        $scope.showMetadataFlag = true;
        $scope.item = item;
    };

    $scope.saveCollection = function (collection) {
        libraryService.AddCollection().then(function (response) {
            alert(response.data);
        });
    }
    $scope.saveItem = function (item) {
        libraryService.AddItem(item).then(function (response) {
            alert(response.data);
        });
    }
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
    fac.AddCollection = function (collection) {
        return $http({
            url: serviceBase + 'api/Collection/AddCollection',
            method: 'POST',
            data: JSON.stringify(collection)
        });
    };
    fac.AddItem = function (item) {
        return $http({
            url: serviceBase + 'api/Item/AddItem',
            method: 'POST',
            data: JSON.stringify(item)
        });
    };
    return fac;

});
 
