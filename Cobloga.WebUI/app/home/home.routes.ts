((): void => {
    'use strict';

    angular
        .module('app.home')
        .config(config);

    config.$inject = [
        '$routeProvider',
        '$locationProvider'
    ];
    function config(
        $routeProvider: ng.route.IRouteProvider,
        $locationProvider: ng.ILocationProvider): void {
        $routeProvider
            .when('/home', {
                templateUrl: 'app/home/home.html',
                controller: 'app.home.HomeController',
                controllerAs: 'vm',
                resolve: {
                    blogPosts: resolveBlogPosts
                }
            });
    }

    resolveBlogPosts.$inject = ['app.services.BlogPostService'];
    function resolveBlogPosts(blogPostService: app.services.IBlogPostService): ng.IPromise<app.services.IBlogPost[]> {
        return blogPostService.getRecentPosts();
    }
})();