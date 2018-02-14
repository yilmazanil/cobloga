var app;
(function (app) {
    var filters;
    (function (filters) {
        'use strict';
        var TrustFilter = /** @class */ (function () {
            function TrustFilter() {
            }
            TrustFilter.Factory = function () {
                var factoryFunction = function ($sce) {
                    return function (value) {
                        return $sce.trustAsResourceUrl(value);
                    };
                };
                factoryFunction.$inject = ['$sce'];
                return factoryFunction;
            };
            return TrustFilter;
        }());
        filters.TrustFilter = TrustFilter;
        //class TrustFilter {
        //    constructor(private $sce: ng.ISCEService) {
        //    }
        //    static filter($sce: ng.ISCEService) {
        //        return (value) => {
        //            return $sce.trustAsResourceUrl(value)
        //        };
        //    }
        //}
        //filter.$inject = [
        //    '$sce'
        //];
        //function filter($sce: ng.ISCEService): TrustFilter{
        //    return new TrustFilter($sce);
        //}
        angular
            .module('app.filters')
            .filter('trust', TrustFilter);
    })(filters = app.filters || (app.filters = {}));
})(app || (app = {}));
;
