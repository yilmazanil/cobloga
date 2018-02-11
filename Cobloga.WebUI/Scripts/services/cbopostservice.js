(function () {

    var cbopostservice = function ($http) {
        var getRecentPosts = function () {
            return $http.get("api/posts/").then(function (response) {
                return response.data;
            });
        };

        var getPostDetails = function (id) {
            return $http.post("api/posts/", postData, null).then(function (response) {
                return response.data;
            });
        };
        var createPost = function (content) {
            return $http.put("api/posts", content, null).then(function (response) {
                return response.data;
            });
        };

        var updatePost = function (id, content) {
            var postData = JSON.stringify({ "ID": id, "Content": content });
            return $http.post("api/posts", postData, null).then(function (response) {
                return response.data;
            });
        };


        return {
            getRecentPosts: getRecentPosts,
            getPostDetails: getPostDetails,
            createPost: createPost,
            updatePost: updatePost
        };
    };

    var module = angular.module("cobloga");
    module.factory("cbopostservice", cbopostservice);

}());
