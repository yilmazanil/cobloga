interface IBlogPostRouteParams extends ng.route.IRouteParamsService {
    uniqueId: string;
}

((): void => {
    'use strict';

    angular
        .module('app.blogposts')
        .config(config);

    config.$inject = [
        '$routeProvider',
        '$locationProvider'
    ];
    function config(
        $routeProvider: ng.route.IRouteProvider,
        $locationProvider: ng.ILocationProvider): void {
        $routeProvider
            .when('/blogposts/update/:uniqueId', {
                templateUrl: 'app/blogposts/blogpost.html',
                controller: 'app.blogposts.BlogPostController',
                controllerAs: 'vm',
                resolve: {
                    blogPost: resolveBlogPost
                }
            }).when('/blogposts/:uniqueId', {
                templateUrl: 'app/blogposts/displayblogpost.html',
                controller: 'app.blogposts.DisplayPostController',
                controllerAs: 'vm',
                resolve: {
                    blogPost: resolveBlogPost
                }
            });
    }

    resolveBlogPost.$inject = [
        '$route',
        'app.services.BlogPostService'
    ];
    function resolveBlogPost(
        $route: ng.route.IRouteService,
        blogPostService: app.services.IBlogPostService): ng.IPromise<app.services.IBlogPost> {
        var routeParams = <IBlogPostRouteParams>$route.current.params;
        return blogPostService.getPostDetails(routeParams.uniqueId);
    }
})();