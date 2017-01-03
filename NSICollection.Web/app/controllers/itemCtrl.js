'use strict';
var app = angular.module('echo');

app.controller('itemCtrl', function ($scope, $http, $filter, itemService) {
    $scope.itemList = [];
    $scope.message = "";
    $scope.item = {
        title: "",
        currentType: "",
        isprivate: false,
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
  
    $scope.addItem = function (item) {
        var Item = {
            title: item.title,
            documentType: {
                id: item.documenttypeid
            },
            isprivate: item.isprivate
            ,metadata: {
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
            $scope.message = data.data;
            alert(data.data);
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

    return fac;

});


