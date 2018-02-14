module app.filters {
    'use strict';



    export class TrustFilter {
        public static Factory() {
            var factoryFunction = ($sce: ng.ISCEService) => {
                return (value) => {
                    return $sce.trustAsResourceUrl(value)
                };
            };

                factoryFunction.$inject = ['$sce'];

                return factoryFunction;
            }
        }


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
    };