module app.filters {
    'use strict';



    TrustFilter.$inject = [
            '$sce'
    ];
    export function TrustFilter($sce: ng.ISCEService): any {
        return (value) => {
            return $sce.trustAsHtml(value)
                };
    }
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
        //angular
        //    .module('app.filters')
        //    .filter('trust', TrustFilter);
    };