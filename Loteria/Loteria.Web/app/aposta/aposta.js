(function () {
    'use strict';

    angular
        .module('app.aposta')
        .controller('Aposta', Aposta);

    Aposta.$inject = ['$scope', '$rootScope', '$http', '$q', '$modal', 'blockUI', 'appConfig', 'common', 'exception', 'notification', 'ds.aposta', 'ds.sorteio'];
    function Aposta($scope, $rootScope, $http, $q, $modal, blockUI, appConfig, common, exception, notification, dsAposta, dsSorteio) {

        common.setBreadcrumb('Aposta');
        var vm = this;

        //Funções
        vm.init = init;
        vm.jogar = jogar;
        vm.sortear = sortear;

        //Feature Start
        init();

        //Implementations
        function init() {
            var blocker = blockUI.instances.get('blockForm');
            blocker.start();

            dsAposta
                .listarJogosMegaSena()
                .then(function (result) {
                    vm.listaJogos = result.data;
                })
                .finally(function () {
                    blocker.stop();
                });
        }

        function jogar() {
            vm.AlertClassI = '';
            vm.AlertClassDiv = '';
            vm.AlertMessage = '';

            var blocker = blockUI.instances.get('blockForm');
            blocker.start();

            if (vm.Dados != undefined) {
                if (vm.Dados.numeros != undefined) vm.Dados.numeros = vm.Dados.numeros.split(',');
                if (vm.Dados.jogadores != undefined) vm.Dados.jogadores = vm.Dados.jogadores.split(',');
            }

            vm.formValid = common.validateForm(vm.editForm);
            if (vm.formValid) {
                dsAposta
                    .criarMegaSena(vm.Dados)
                    .success(function (result) {
                        vm.listaJogos = result;
                        vm.Dados.numeros = "";
                        vm.Dados.jogadores = "";

                        vm.AlertClassI = 'fa fa-exclamation-triangle';
                        vm.AlertClassDiv = 'alert alert-success';
                        vm.AlertMessage = "Seu jogo foi salvo com sucesso";
                    }).error(function (result) {
                        vm.Dados.numeros = "";
                        vm.Dados.jogadores = "";

                        vm.AlertClassI = 'fa fa-exclamation-triangle';
                        vm.AlertClassDiv = 'alert alert-danger';
                        vm.AlertMessage = result.Message;
                    })
                    .finally(function () {
                        blocker.stop();
                    });
                } else {
                    vm.AlertClassI = 'fa fa-exclamation-triangle';
                    vm.AlertClassDiv = 'alert alert-danger';
                    vm.AlertMessage = "Os campos são obrigatórios";
                    blocker.stop();
            }
        }

        function sortear() {
            var blocker = blockUI.instances.get('blockForm');
            blocker.start();

            dsSorteio
                .sortearMegaSena()
                .success(function (result) {
                    vm.sorteioGanhador = result;
                    vm.sorteioGanhador.ListaJogos = [];
                    vm.sorteioGanhador.ListaJogos = vm.listaJogos;

                    dsSorteio
                        .verificaGanhadores(vm.sorteioGanhador)
                        .success(function (result) {
                            vm.ganhadores = result;
                        })
                        .finally(function () {
                            blocker.stop();
                        });
                })
                .finally(function () {
                });
        }
    }
})();
