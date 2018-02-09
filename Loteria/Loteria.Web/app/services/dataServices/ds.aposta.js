(function () {
    'use strict';

    angular.module('app.dataServices')
        .factory('ds.aposta', DsAposta);

    DsAposta.$inject = ['$http', 'appConfig', 'common'];

    function DsAposta($http, appConfig, common) {

        var apiRoute = common.makeApiRoute('aposta');
        var service = {
            criarMegaSena: criarMegaSena,
            listarJogosMegaSena: listarJogosMegaSena
        };
        return service;

        function criarMegaSena(model) {
            return $http.post(common.makeUrl([apiRoute, 'criarMegaSena']), model);
        }

        function listarJogosMegaSena() {
            return $http.post(common.makeUrl([apiRoute, 'listarJogosMegaSena']));
        }


    }
})();
