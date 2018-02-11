'use strict';

(function () {
    var app = angular.module("cobloga");

    app.filter("trust", ['$sce', function ($sce) {
        return function (htmlCode) {
            return $sce.trustAsHtml(htmlCode);
        };
    }]);
}());