
(function () {
    'use strict';

    var appManutencao = angular.module('app.manutencao', ['angular-loading-bar', 'app.config']);

    appManutencao.config(["$stateProvider", "appConfig", function ($stateProvider, appConfig) {

        $stateProvider
        .state("manutencao", {
            parent: 'app',
            url: appConfig.routePrefix + "/manutencao",
            views: {
                'content': {
                    templateUrl: "app/manutencao/list.html",
                    controller: "Manutencao as vm"
                }
            },
            data: { requireAuth: true }
        });
    }]);

})();