'use strict';
(function () {
    var app = angular.module("cobloga");

    var CreatePostController = function ($scope, $http, $window, cbopostservice) {
        var onPostCreate = function (response) {
            $window.location.href = 'post/index?postId=' + response;
        };

        $scope.Save = function () {
            var postData = JSON.stringify($scope.tinymceModel);
            cbopostservice.createPost(postData).then(onPostCreate);
        };
    };


    app.controller("CreatePostController", ["$scope", "$http", "$window", "cbopostservice", CreatePostController]);
}());