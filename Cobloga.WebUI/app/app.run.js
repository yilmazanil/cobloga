//interface IAppCookies {
//    userId: string;
//}
(function () {
    'use strict';
    angular
        .module('app')
        .run(run);
    run.$inject = [
        '$rootScope',
    ];
    function run($rootScope) {
        $rootScope.$on('$routeChangeError', function () {
        });
        //currentUser.userId = $cookies.userId;
    }
})();
