'use strict';
var app = angular.module('echo');

app.controller('exportCtrl', function ($scope, $http) {
    $scope.itemList = [];
    $scope.message = "";
    $scope.item = {
        title: "My Document",
        currentType: "book",
        isprivate: false,
        metadata: {
            author: "Arnela Tumbul",
            abstract: "Long story short",
            publisher: "Sarajevo",
            language: "en",
            url: "https://google.com",
            extra: "Addition",
            issued: "11.10.2016."
        }
    };
});

function exportItem() {
    $.ajax({
        url: "http://localhost:60824/api/citation/GetIEEECitationOfFirstItem",
        dataType: "json",
        method: "GET",
        success: function (data, textStatus, jqXHR) {
            alert(data);
        }
    });
}