'use strict';
(function () {
    var app = angular.module("cobloga");

    var HomeController = function ($scope, $http) {

        var onFetchComplete = function (response) {
            $scope.RecentPosts = response.data;
        };

        $http.get("api/posts/").then(onFetchComplete);
    };



    app.controller("HomeController", ["$scope", "$http", HomeController]);
}());