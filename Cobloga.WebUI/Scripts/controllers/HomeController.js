'use strict';
(function () {
    var app = angular.module("cobloga");

    var HomeController = function ($scope, $http, cbopostservice) {

        var onFetchComplete = function (response) {
            $scope.RecentPosts = response;
        };

        cbopostservice.getRecentPosts().then(onFetchComplete);
    };

    app.controller("HomeController", ["$scope", "$http", "cbopostservice", HomeController]);
}());