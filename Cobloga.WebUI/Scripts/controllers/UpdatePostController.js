'use strict';
(function () {
    var app = angular.module("cobloga");

    var UpdatePostController = function ($scope, $http, $location) {
        $scope.Update = function () {
            var postData = JSON.stringify({ "postId": $scope.postId, "content": $scope.tinymceModel });
            $http.post("api/posts/", postData, null).then(function (response) {
                return response.data;
            });
        };
        $scope.tinymceOptions = {
            plugins: ['link', 'paste', 'table', 'codesample', 'code'],
            toolbar: "codesample | code | undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | save",
            codesample_languages: [
                { text: 'HTML/XML', value: 'markup' },
                { text: 'JavaScript', value: 'javascript' },
                { text: 'CSS', value: 'css' },
                { text: 'PHP', value: 'php' },
                { text: 'Ruby', value: 'ruby' },
                { text: 'Python', value: 'python' },
                { text: 'Java', value: 'java' },
                { text: 'C', value: 'c' },
                { text: 'C#', value: 'csharp' },
                { text: 'C++', value: 'cpp' }
            ],
            menubar: false,
            codesample_content_css: '../../Content/prism.css',
            skin_url: '../../node_modules/tinymce/skins/lightgray',
            branding: false,
            statusbar: false,
            height: 800
        };

    };


    app.controller("UpdatePostController", ["$scope", "$http", "$location", UpdatePostController]);
}());