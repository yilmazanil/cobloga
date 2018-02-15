module app.blogposts {
    'use strict';

    interface IDisplayBlogPostScope {
        BlogPost: app.services.IBlogPost
    }

    class DisplayPostController implements IDisplayBlogPostScope {
        BlogPost: app.services.IBlogPost
        $onInit() { }

        static $inject = ['app.services.BlogPostService', '$window', 'blogPost'];
        constructor(private blogPostService: app.services.IBlogPostService,
            private window: ng.IWindowService, blogPost: app.services.IBlogPost) {
            this.BlogPost = blogPost;
        }
    }

    angular
        .module('app.blogposts')
        .controller('app.blogposts.DisplayPostController',
        DisplayPostController);
} 