'use strict';
var app = angular.module('echo');

app.controller('itemCtrl', function ($scope, $http, $filter, itemService) {

    $scope.message = "";
    $scope.itemList = [];
    $scope.collectionList = [];
    $scope.defaultCollectionId = 0;
    $scope.message = "";
    $scope.item = {
        title: "",
        currentType: "",
        isprivate: false,
        attachmentPath : "",
        metadata : {
            author: "",
            abstract: "",
            publisher: "",
            language: "",
            url: "",
            rights: "",
            extra: ""
        }
    };

    itemService.GetCollections().then(function (data) {
        var col = data.data.collections;
        for (var i = 0; i < col.length; i++) {
            var obj = {
                title: col[i].Title,
                id: col[i].ID
            }
            $scope.collectionList.push(obj);
        }
        $scope.defaultCollectionId = $filter("filter")($scope.collectionList, { title: 'Unfiled Items' });
    });
    
    itemService.GetDocTypes().then(function (response) {
        for (var i = 0; i < response.data.DocumentTypes.length; i++) {
            var obj = {
                id: response.data.DocumentTypes[i].ID,
                docTypeTitle: response.data.DocumentTypes[i].DocumentTypeTitle
            }
        }
        $scope.itemTypes = response.data.DocumentTypes;
    });

    $scope.change = function (id) {
        var newTemp = $filter("filter")($scope.itemTypes, { ID: id });
        $scope.item.currentType = newTemp[0].DocumentTypeTitle;
    };

    $scope.clear = function () {
        $scope.item = {
            title: "",
            currentType: "",
            isprivate: false,
            attachmentPath: "",
            metadata: {
                author: "",
                abstract: "",
                publisher: "",
                language: "",
                url: "",
                rights: "",
                extra: ""
            }
        };
    }
  
    $scope.addItem = function (item) {
        var Item = {
            title: item.title,
            documentType: {
                id: item.documenttypeid
            },
            collectionId: item.collectionId != undefined && item.collectionId > 0 ? item.collectionId : $scope.defaultCollectionId[0].id,
            isprivate: item.isprivate,
            metadata: {
                author: item.metadata.author,
                abstract: item.metadata.abstract,
                publisher: item.metadata.publisher,
                language: item.metadata.language,
                url: item.metadata.url,
                rights: item.metadata.rights,
                extra: item.metadata.extra
            }
        };

        itemService.AddItem(Item).then(function (data) {
            $scope.message = "Item was successfuly created";
            $scope.clear();
        });
    };   
});


app.service('itemService', function ($http) {
    var fac = {};
    var serviceBase = 'http://localhost:60824/';
    fac.AddItem = function (Item) {
        return $http({
            url: serviceBase + 'api/Item/AddItem',
            method: 'POST',
            data: JSON.stringify(Item)
        });
    };
 
    fac.GetDocTypes = function () {
        return $http({
            url: serviceBase + 'api/Item/GetDocTypes',
            method: 'GET'
        });
    };

    fac.GetCollections = function () {
        return $http({
            url: serviceBase + 'api/Collection/GetCollections',
            method: 'GET'
        });
    }
    return fac;

});


