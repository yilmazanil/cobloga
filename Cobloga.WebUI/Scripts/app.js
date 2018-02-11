(function () {
    var app = angular.module("cobloga", ['ui.tinymce']);

    app.config(function ($locationProvider) {
        $locationProvider.html5Mode(true);
    });
}());