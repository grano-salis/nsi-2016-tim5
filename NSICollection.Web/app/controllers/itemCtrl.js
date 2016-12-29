'use strict';
var app = angular.module('echo');

app.controller('itemCtrl', function ($scope, $http, itemService) {
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
    

    $scope.itemTypes =
    [
        "Document",
        "Image",
        "Audio",
        "Book"
    ];

  
    $scope.addItem = function (item) {
        var Item = {
            title: item.title,
            documentType: item.currentType,
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
    return fac;

});


