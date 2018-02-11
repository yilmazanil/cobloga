'use strict';
(function () {
    var app = angular.module("cobloga");

    var UpdatePostController = function ($scope, $http, $window, cbopostservice) {
        var onPostUpdate = function (response) {
            $window.location.href = 'post/index?postId=' + response;
        };

        $scope.Update = function () {
            cbopostservice.updatePost($scope.postId, $scope.tinymceModel).then(onPostUpdate);
        };
    };

    app.controller("UpdatePostController", ["$scope", "$http","$window","cbopostservice", UpdatePostController]);
}());