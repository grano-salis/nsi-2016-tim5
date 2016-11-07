var app = angular.module('echo');

app.controller('indexCtrl', function ($location, $scope) {
    // create a message to display in our view
    console.log('indexCtrl');
    $scope.location=$location;
    


});