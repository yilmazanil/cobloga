module app.blogposts {
    'use strict';

    interface IUpdateBlogPostScope {
        tinymceModel: string;
        postId: string;
        Save: () => void;
    }

    class UpdatePostController implements IUpdateBlogPostScope {
        tinymceModel: string;
        postId: string;
        IsPublic: boolean;

        $onInit() { }

        static $inject = ['app.services.BlogPostService', '$window', 'blogPost'];
        constructor(private blogPostService: app.services.IBlogPostService,
            private window: ng.IWindowService, blogPost: app.services.IBlogPost) {
            this.tinymceModel = blogPost.Content;
            this.postId = blogPost.ID;
        }

        Save(): void {
            this.blogPostService.updatePost(this.postId, this.tinymceModel).then((result: string): void => {
                this.window.location.href = '/blogposts/'+result;
            })
        }
    }

    angular
        .module('app.blogposts')
        .controller('app.blogposts.UpdatePostController',
            UpdatePostController);
} 