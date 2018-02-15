module app.blogposts {
    'use strict';

    interface IUpdateBlogPostScope {
        tinymceModel: string;
        postId: string;
        Update: () => void;
    }

    class UpdatePostController implements IUpdateBlogPostScope {
        tinymceModel: string;
        postId: string;
        IsPublic: boolean;

        $onInit() { }

        static $inject = ['app.services.BlogPostService', '$window'];
        constructor(private blogPostService: app.services.IBlogPostService,
            private window: ng.IWindowService) { }


        onPostUpdate(response: app.services.IBlogPostResult): void {
            this.window.location.href = 'post/index?postId=' + response.ID;
        }


        Update(): void {
            this.blogPostService.updatePost(this.postId, this.tinymceModel).then((result: string): void => {
                this.window.location.href = 'post/index?postId=' + result;
            })
        }
        
    }

    angular
        .module('app.blogposts')
        .controller('app.blogposts.UpdatePostController',
            UpdatePostController);
} 