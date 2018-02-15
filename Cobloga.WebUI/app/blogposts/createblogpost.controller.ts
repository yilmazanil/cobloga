module app.blogposts {
    'use strict';

    interface ICrateBlogPostScope{
        isPublic: boolean;
        tinymceModel: string;
        Save: () => void;
    }

    class CreatePostController implements ICrateBlogPostScope {
        isPublic: boolean;
        tinymceModel: string;

        $onInit() { }

        static $inject = ['app.services.BlogPostService', '$window'];
        constructor(private blogPostService: app.services.IBlogPostService,
            private window: ng.IWindowService) {
            this.isPublic = true;
        }


        Save(): void {
            var postData = JSON.stringify({ 'content': this.tinymceModel, 'isPublic': this.isPublic });
            this.blogPostService.createPost(postData).then((response: app.services.IBlogPost): void => {
                this.window.location.href = '/blogposts/' + response.ID;
            });
        }
    }

    angular
        .module('app.blogposts')
        .controller('app.blogposts.CreatePostController',
            CreatePostController);
} 