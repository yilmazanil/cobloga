module app.home {
    'use strict';

    interface IHomeScope {
        RecentPosts: app.services.IBlogPost[];
    }

    class HomeController implements IHomeScope {
        RecentPosts: app.services.IBlogPost[];

       
        $onInit() {}

        static $inject = ['blogPosts'];
        constructor(posts: app.services.IBlogPost[]) {
            this.RecentPosts = posts;
        }
    }
    angular
        .module('app.home')
        .controller('app.home.HomeController',
            HomeController);
} 