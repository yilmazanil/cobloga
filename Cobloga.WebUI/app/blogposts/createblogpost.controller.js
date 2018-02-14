var app;
(function (app) {
    var blogposts;
    (function (blogposts) {
        'use strict';
        var CreatePostController = /** @class */ (function () {
            function CreatePostController(blogPostService, window) {
                this.blogPostService = blogPostService;
                this.window = window;
            }
            CreatePostController.prototype.$onInit = function () { };
            CreatePostController.prototype.onPostCreate = function (response) {
                this.window.location.href = 'post/index?postId=' + response.ID;
            };
            ;
            CreatePostController.prototype.save = function () {
                var postData = JSON.stringify({ 'content': this.tinymceModel, 'isPublic': this.isPublic });
                this.blogPostService.createPost(postData).then(this.onPostCreate);
            };
            CreatePostController.$inject = ['app.services.BlogPostService'];
            return CreatePostController;
        }());
        angular
            .module('app.blogposts')
            .controller('app.blogposts.CreatePostController', CreatePostController);
    })(blogposts = app.blogposts || (app.blogposts = {}));
})(app || (app = {}));
