module app.blogposts {
    'use strict';

    interface ICrateBlogPostScope{
        isPublic: boolean;
        tinymceModel: string;
        save: () => void;
    }

    class CreatePostController implements ICrateBlogPostScope {
        isPublic: boolean;
        tinymceModel: string;

        $onInit() { }

        static $inject = ['app.services.BlogPostService', '$window'];
        constructor(private blogPostService: app.services.IBlogPostService,
            private window: ng.IWindowService) { }


        onPostCreate(response: app.services.IBlogPostResult): void {
            this.window.location.href = 'post/index?postId=' + response.ID;
        };


        save(): void {
            var postData = JSON.stringify({ 'content': this.tinymceModel, 'isPublic': this.isPublic });
            this.blogPostService.createPost(postData).then(this.onPostCreate);
        }
    }

    angular
        .module('app.blogposts')
        .controller('app.blogposts.CreatePostController',
            CreatePostController);
} 