var app;
(function (app) {
    var blogposts;
    (function (blogposts) {
        'use strict';
        var UpdatePostController = /** @class */ (function () {
            function UpdatePostController(blogPostService, window) {
                this.blogPostService = blogPostService;
                this.window = window;
            }
            UpdatePostController.prototype.$onInit = function () { };
            UpdatePostController.prototype.onPostUpdate = function (response) {
                this.window.location.href = 'post/index?postId=' + response.ID;
            };
            ;
            UpdatePostController.prototype.Update = function () {
                this.blogPostService.updatePost(this.postId, this.tinymceModel).then(this.onPostUpdate);
            };
            UpdatePostController.$inject = ['app.services.BlogPostService'];
            return UpdatePostController;
        }());
        angular
            .module('app.blogposts')
            .controller('app.blogposts.UpdatePostController', UpdatePostController);
    })(blogposts = app.blogposts || (app.blogposts = {}));
})(app || (app = {}));
