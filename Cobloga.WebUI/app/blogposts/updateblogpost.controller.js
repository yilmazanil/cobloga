var app;
(function (app) {
    var blogposts;
    (function (blogposts) {
        'use strict';
        var UpdatePostController = (function () {
            function UpdatePostController(blogPostService, window) {
                this.blogPostService = blogPostService;
                this.window = window;
            }
            UpdatePostController.prototype.$onInit = function () { };
            UpdatePostController.prototype.onPostUpdate = function (response) {
                this.window.location.href = 'post/index?postId=' + response.ID;
            };
            UpdatePostController.prototype.Update = function () {
                var _this = this;
                this.blogPostService.updatePost(this.postId, this.tinymceModel).then(function (result) {
                    _this.window.location.href = 'post/index?postId=' + result;
                });
            };
            UpdatePostController.$inject = ['app.services.BlogPostService', '$window'];
            return UpdatePostController;
        }());
        angular
            .module('app.blogposts')
            .controller('app.blogposts.UpdatePostController', UpdatePostController);
    })(blogposts = app.blogposts || (app.blogposts = {}));
})(app || (app = {}));
//# sourceMappingURL=updateblogpost.controller.js.map