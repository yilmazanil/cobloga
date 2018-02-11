'use strict';
(function () {
    var app = angular.module("cobloga");

    var CreatePostController = function ($scope, $http, $location) {
        $scope.Save = function () {
            var postData = JSON.stringify($scope.tinymceModel);
            $http.post("api/post", postData, null).then(function (response) {
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
            height :800
        };

       

        //var setDisplayMode = function () {
        //    var qsParams = $location.search();
        //    if (qsParams && qsParams.postId) {
        //        $http.get("api/cbapostapi/" + qsParams.postId).then(function (response) {
        //            $scope.postId = qsParams.postId;
        //            $scope.isEditable = true;
        //            $scope.tinymceModel = response.data.Content;
        //        });
        //    }
        //    else {
        //        $scope.tinymceModel = '';
        //        $scope.postId ='';
        //        $scope.isEditable = false;
        //    }

        //};
        //setDisplayMode();
    };



    app.controller("CreatePostController", ["$scope", "$http", "$location", CreatePostController]);
}());