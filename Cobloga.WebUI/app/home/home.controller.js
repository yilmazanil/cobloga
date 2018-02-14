var app;
(function (app) {
    var home;
    (function (home) {
        'use strict';
        var HomeController = /** @class */ (function () {
            function HomeController(blogPostService) {
                this.blogPostService = blogPostService;
            }
            HomeController.prototype.$onInit = function () {
                var _this = this;
                this.blogPostService.getRecentPosts().then(function (response) {
                    _this.RecentPosts = response;
                });
            };
            HomeController.$inject = ['app.services.BlogPostService'];
            return HomeController;
        }());
        angular
            .module('app.home')
            .controller('app.home.HomeController', HomeController);
    })(home = app.home || (app.home = {}));
})(app || (app = {}));
