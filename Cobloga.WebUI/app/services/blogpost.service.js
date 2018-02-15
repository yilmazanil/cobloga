var app;
(function (app) {
    var services;
    (function (services) {
        'use strict';
        var BlogPostService = (function () {
            function BlogPostService($http, apiEndpoint) {
                this.$http = $http;
                this.apiEndpoint = apiEndpoint;
            }
            BlogPostService.prototype.getRecentPosts = function () {
                return this.$http
                    .get(this.apiEndpoint.baseUrl + '/posts')
                    .then(function (response) {
                    return response.data;
                });
            };
            BlogPostService.prototype.getPostDetails = function (uniqueId) {
                return this.$http
                    .get(this.apiEndpoint.baseUrl + '/posts/' + uniqueId)
                    .then(function (response) {
                    return response.data;
                });
            };
            BlogPostService.prototype.createPost = function (postContent) {
                return this.$http
                    .put(this.apiEndpoint.baseUrl + '/posts', postContent, null)
                    .then(function (response) {
                    return response.data;
                });
            };
            BlogPostService.prototype.updatePost = function (id, postContent) {
                var postData = JSON.stringify({ "ID": id, "Content": postContent });
                return this.$http
                    .post(this.apiEndpoint.baseUrl + '/posts', postData, null)
                    .then(function (response) {
                    return response.data;
                });
            };
            return BlogPostService;
        }());
        factory.$inject = [
            '$http',
            'app.blocks.ApiEndpoint'
        ];
        function factory($http, apiEndpoint) {
            return new BlogPostService($http, apiEndpoint);
        }
        angular
            .module('app.services')
            .factory('app.services.BlogPostService', factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
//# sourceMappingURL=blogpost.service.js.map