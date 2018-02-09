
(function () {
    'use strict';

    var appAposta = angular.module('app.aposta', ['angular-loading-bar', 'app.config']);

    appAposta.config(["$stateProvider", "appConfig", function ($stateProvider, appConfig) {

        $stateProvider
            .state("aposta", {
                parent: 'app',
                url: appConfig.routePrefix + "/aposta",
                views: {
                    'content': {
                        templateUrl: "app/aposta/aposta.html",
                        controller: "Aposta as vm"
                    }
                }
            });
    }]);

})();
