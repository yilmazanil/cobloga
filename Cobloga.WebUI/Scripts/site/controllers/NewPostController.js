'use strict';
(function () {
    var app = angular.module("cobloga");

    var NewPostController = function ($scope, $http) {
        $scope.tinymceModel = 'Initial content';

        $scope.getContent = function () {
            console.log('Editor content:', $scope.tinymceModel);
        };

        $scope.setContent = function () {
            $scope.tinymceModel = 'Time: ' + (new Date());
        };

        $scope.Save = function () {
            var postData = JSON.stringify($scope.tinymceModel);
            var config = {
                //headers : {
                //    'Content-Type': 'application/json;charset=utf-8;'
                //}
            }
            $http.post("api/cbapostapi/", postData, config).then(function (response) {
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
            codesample_content_css: '../Content/prism.css',
            skin_url: '../node_modules/tinymce/skins/lightgray',
            branding: false,
            statusbar: false,
            height :800
        };
    };



    app.controller("NewPostController", ["$scope", "$http", NewPostController]);
}());