﻿module app.services {
    'use strict';

    export interface IBlogPostService {
        getRecentPosts(): ng.IPromise<IBlogPost[]>;
        getPostDetails(uniqueId: string): ng.IPromise<IBlogPost>;
        createPost(postContent: string): ng.IPromise<IBlogPost>;
        updatePost(id: string, postContent: string): ng.IPromise<string>;
    }

    export interface IBlogPost {
        ID: string;
        Content: string;
        CreatedDate: Date;
        UserId?: number;
    }

    export interface IBlogPostResult {
        ID: string;
        IsSuccess: boolean;
        Message: string;
    }

    class BlogPostService implements IBlogPostService {
        constructor(private $http: ng.IHttpService,
            private apiEndpoint: app.blocks.IApiEndpointConfig) { }

        getRecentPosts(): ng.IPromise<IBlogPost[]> {
            return this.$http
                .get(this.apiEndpoint.baseUrl + '/blogpost')
                .then((response: ng.IHttpPromiseCallbackArg<IBlogPost[]>): IBlogPost[] => {
                    return <IBlogPost[]>response.data;
                });
        }

        getPostDetails(uniqueId: string): ng.IPromise<IBlogPost> {
            return this.$http
                .get(this.apiEndpoint.baseUrl + '/blogpost?id=' + uniqueId)
                .then((response: ng.IHttpPromiseCallbackArg<IBlogPost>): IBlogPost => {
                    return <IBlogPost>response.data;
                });
        }

        createPost(postContent: string): ng.IPromise<IBlogPost> {
            return this.$http
                .put(this.apiEndpoint.baseUrl + '/blogpost', postContent, null)
                .then((response: ng.IHttpPromiseCallbackArg<IBlogPost>): IBlogPost => {
                    return <IBlogPost>response.data;
                });
        }

        updatePost(id: string, postContent: string): ng.IPromise<string> {
            var postData = JSON.stringify({ "ID": id, "Content": postContent });
            return this.$http
                .post(this.apiEndpoint.baseUrl + '/blogpost', postData, null)
                .then((response: ng.IHttpPromiseCallbackArg<string>): string => {
                    return response.data;
                });
        }
    }

    factory.$inject = [
        '$http',
        'app.blocks.ApiEndpoint'
    ];
    function factory($http: ng.IHttpService,
        apiEndpoint: app.blocks.IApiEndpointConfig): IBlogPostService {
        return new BlogPostService($http, apiEndpoint);
    }

    angular
        .module('app.services')
        .factory('app.services.BlogPostService',
            factory);
} 