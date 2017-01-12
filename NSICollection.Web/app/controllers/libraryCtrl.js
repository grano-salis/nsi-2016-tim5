'use strict';
var app = angular.module('echo');

app.controller('libraryCtrl', function ($scope, $http, libraryService, $filter) {

    $scope.menuOptions = [
        ['Select', function ($itemScope, $event, modelValue, text, $li) {
            $scope.selected = $itemScope.item.name;
        }],
        null, // Dividier
        ['Remove', function ($itemScope, $event, modelValue, text, $li) {
            $scope.items.splice($itemScope.$index, 1);
        }]
    ];
    
    $scope.clickOnEdit = false;
    
    $scope.menuCollectionOptions = [
        ['Remove', function ($itemScope, $event, modelValue, text, $li) {
        console.log('Collection.delete');
        }]
    ];



 
    $scope.test = [];
    $scope.selectedCollectionId = "";
    $scope.initialize = function () {
        libraryService.GetCollectionItems().then(function (data) {
            for (var i = 0; i < data.data.collections.length; i++) {
                var obj = {
                    title: data.data.collections[i].Title,
                    description: data.data.collections[i].Description,
                    isprivate: data.data.collections[i].IsPrivate,
                    id: data.data.collections[i].ID
                }
                $scope.test.push(obj.title);
            }
            $scope.collectionItemsList = data;

            $scope.defaultCollectionId = $filter("filter")($scope.collectionItemsList.data.collections, { title: 'Unfiled Items' });

            $scope.menuItemOptions = [
       ['Edit', function ($itemScope, $event, modelValue, text, $li) {
           $scope.clickOnEdit = true;
       },
       ],
       null, // Dividier
       ['Remove', function ($itemScope, $event, modelValue, text, $li) {
           console.log('Item.deletee');
           deleteItemOrCollection($itemScope.item.id, 'item');
       }],
            ];
        });
    }
    $scope.initialize();

    $scope.showCollection = function (collection) {
        $scope.showMetadataFlag = false;
        $scope.showCollectionFlag = true;
        $scope.collection = collection;
    };
    
    libraryService.GetDocTypes().then(function (response) {
        for (var i = 0; i < response.data.DocumentTypes.length; i++) {
            var obj = {
                id: response.data.DocumentTypes[i].ID,
                docTypeTitle: response.data.DocumentTypes[i].DocumentTypeTitle
            }
        }
        $scope.documentTypes = response.data.DocumentTypes;
    });

    $scope.showMetadata = function (item) {
        $scope.showCollectionFlag = false;
        $scope.showMetadataFlag = true;
        $scope.item = item;

        $scope.selectedCollection = $filter("filter") ($scope.collectionItemsList.data.collections, { ID : item.CollectionId  });
        $scope.selectedCol = $scope.selectedCollection[0].Title;
        
        $scope.selectedDocumentType = $filter("filter")($scope.documentTypes, { ID: item.DocumentTypeId});
        $scope.selectedDocType = $scope.selectedDocumentType[0].DocumentTypeTitle;
        $scope.clickOnEdit = false;

    };

    $scope.saveCollection = function (collection) {
        libraryService.AddCollection(collection).then(function (response) {
            alert(response.data);
            $scope.initialize();
        });
    }

    $scope.change = function (item)
    {
        $scope.selectedCollection = item;
        $scope.clickOnEdit = false;
    }
    $scope.setUpChangedValue = function(colId) 
    {
        $scope.selectedCollectionId = colId;
    }
    $scope.saveItem = function (item) {
        var Item = {
            title: item.Title,
            id: item.ID,
            documentType: {
                id: item.DocumentTypeId
            },
            collectionId: item.CollectionId != undefined && item.CollectionId > 0 ? item.CollectionId : $scope.defaultCollectionId[0].id,
            isprivate: item.IsPrivate,
            metadata: {
                id: item.Metadata.ID,
                author: item.Metadata.Author,
                abstract: item.Metadata.Abstract,
                publisher: item.Metadata.Publisher,
                language: item.Metadata.Language,
                url: item.Metadata.Url,
                rights: item.Metadata.Rights,
                extra: item.Metadata.Extra
            }
        };

        libraryService.AddItem(Item).then(function (data) {
            $scope.message = data.data;
            alert(data.data);
            $scope.initialize();
        });

        libraryService.GetCollectionItems().then(function (data) {
            for (var i = 0; i < data.data.collections.length; i++) {
                var obj = {
                    title: data.data.collections[i].Title,
                    description: data.data.collections[i].Description,
                    isprivate: data.data.collections[i].IsPrivate,
                    id: data.data.collections[i].ID
                }
                $scope.test.push(obj.title);
            }
            $scope.collectionItemsList = data;
            $scope.defaultCollectionId = $filter("filter")($scope.collectionItemsList.data.collections, { title: 'Unfiled Items' });

            $scope.menuItemOptions = [
       ['Move to', function ($itemScope, $event, modelValue, text, $li) {
           $scope.moveToCollection();
       },
       ],
       null, // Dividier
       ['Remove', function ($itemScope, $event, modelValue, text, $li) {
           console.log('Item.deletee');
           deleteItemOrCollection($itemScope.item.id, 'item');
       }],
            ];
        });
    };
    $scope.exportItems = function () {
        libraryService.ExportItems().then(function (response) {
            alert(response.data);
        });
    }

    $scope.selected = 'None';
    $scope.items = [
        { name: 'John', otherProperty: 'Foo' },
        { name: 'Joe', otherProperty: 'Bar' }
    ];


    $scope.menuOptions = [
        ['Select', function ($itemScope, $event, modelValue, text, $li) {
            $scope.selected = $itemScope.item.name;
        }],
        null, // Dividier
        ['Remove', function ($itemScope, $event, modelValue, text, $li) {
            $scope.items.splice($itemScope.$index, 1);
        }]
    ];


    $scope.menuCollectionOptions = [
['Remove', function ($itemScope, $event, modelValue, text, $li) {
    console.log('Collection.delete');

}]
    ];



    $scope.menuItemOptions = [
        ['Move to', function ($itemScope, $event, modelValue, text, $li) {
            console.log('Item.moveTo');
        }],
        null, // Dividier
        ['Remove', function ($itemScope, $event, modelValue, text, $li) {
            console.log('Item.deletee');
            deleteItemOrCollection($itemScope.item.id, 'item');
        }]
    ];

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

    fac.GetDocTypes = function () {
        return $http({
            url: serviceBase + 'api/Item/GetDocTypes',
            method: 'GET'
        });
    };

    fac.ExportItems = function () {
        return $http({
            url: serviceBase + 'api/Citation/GetCitations?citStyleID=1',
            method: 'GET'
        });
    }
    return fac;

});
 


