module app.home {
    'use strict';

    interface IHomeScope {
        RecentPosts: app.services.IBlogPost[];
    }

    class HomeController implements IHomeScope {
        RecentPosts: app.services.IBlogPost[];

        $onInit() {
            this.blogPostService.getRecentPosts().then((response: app.services.IBlogPost[]) => {
                this.RecentPosts = response;
            });
        }

        static $inject = ['app.services.BlogPostService'];
        constructor(private blogPostService: app.services.IBlogPostService) {
           
        }
    }
    angular
        .module('app.home')
        .controller('app.home.HomeController',
            HomeController);
} 