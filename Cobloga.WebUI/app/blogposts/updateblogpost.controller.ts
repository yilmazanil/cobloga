module app.blogposts {
    'use strict';

    interface IUpdateBlogPostScope {
        textEditorAvailable: boolean;
        tinymceModel: string;
        postId: string;
        Update: () => void;
    }

    class UpdatePostController implements IUpdateBlogPostScope {
        textEditorAvailable: boolean;
        tinymceModel: string;
        postId: string;

        $onInit() { }

        static $inject = ['app.services.BlogPostService'];
        constructor(private blogPostService: app.services.IBlogPostService,
            private window: ng.IWindowService) { }


        onPostUpdate(response: app.services.IBlogPostResult): void {
            this.window.location.href = 'post/index?postId=' + response.ID;
        };


        Update(): void {
            this.blogPostService.updatePost(this.postId, this.tinymceModel).then(this.onPostUpdate);
        }
    }

    angular
        .module('app.blogposts')
        .controller('app.blogposts.UpdatePostController',
            UpdatePostController);
} 