var app;
(function (app) {
    var filters;
    (function (filters) {
        'use strict';
        TrustFilter.$inject = [
            '$sce'
        ];
        function TrustFilter($sce) {
            return function (value) {
                return $sce.trustAsHtml(value);
            };
        }
        filters.TrustFilter = TrustFilter;
        //export class TrustFilter {
        //    public static Factory() {
        //        var factoryFunction = ($sce: ng.ISCEService) => {
        //            return (value) => {
        //                return $sce.trustAsResourceUrl(value)
        //            };
        //        };
        //            factoryFunction.$inject = ['$sce'];
        //            return factoryFunction;
        //        }
        //    }
        //var filterFunction = new TrustFilter();
        angular
            .module('app.filters')
            .filter('trust', TrustFilter);
    })(filters = app.filters || (app.filters = {}));
})(app || (app = {}));
;
//# sourceMappingURL=trust.filter.js.map