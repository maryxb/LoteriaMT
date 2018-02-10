(function () {
    'use strict';

    angular.module('app.dataServices')
        .factory('ds.sorteio', DsSorteio);

    DsSorteio.$inject = ['$http', 'appConfig', 'common'];

    function DsSorteio($http, appConfig, common) {

        var apiRoute = common.makeApiRoute('sorteio');
        var service = {
            sortearMegaSena: sortearMegaSena,
            verificaGanhadores: verificaGanhadores
        };
        return service;

        function sortearMegaSena(listaJogos) {
            return $http.post(common.makeUrl([apiRoute, 'sortearMegaSena']));
        }

        function verificaGanhadores(sorteioGanhador) {
            return $http.post(common.makeUrl([apiRoute, 'verificaGanhadores']), sorteioGanhador);
        }

        
    }
})();
