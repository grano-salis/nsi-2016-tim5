var app = angular.module('echo');

app.controller('Ctrl3', ['$scope', function($scope) {
        // create a message to display in our view
    console.log('Ctrl3');
    $scope.collection = {
        title : "",
        description: "",
        isprivate: false
    };
    $scope.collectionList = [];

    $scope.createCollection = function (item) {
        $scope.collectionList.push(item);
        $scope.clear();
    };

    $scope.clear = function () {
        $scope.collection = {
            title: "",
            description: "",
            isprivate: false
        };
    }
}]);