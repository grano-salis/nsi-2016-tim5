var app = angular.module('echo');

app.controller('indexCtrl', function ($location, $scope) {
    // create a message to display in our view
    console.log('indexCtrl');
    $scope.location = $location;

    $scope.uploadFile = function(files) {
        var fd = new FormData();
        //Take the first selected file
        fd.append("file", files[0]);

        $http.post(uploadUrl, fd, {
            withCredentials: true,
            headers: {'Content-Type': undefined },
            transformRequest: angular.identity
        }).success("all right!").error("damn!");

    };
    


});