(function () {
    'use strict';

    angular
        .module('app.aposta')
        .controller('Aposta', Aposta);

    Aposta.$inject = ['$scope', '$rootScope', '$http', '$q', '$modal', 'blockUI', 'appConfig', 'common', 'exception','notification', 'ds.aposta'];
    function Aposta($scope, $rootScope, $http, $q, $modal, blockUI, appConfig, common, exception, notification, dsAposta) {

        common.setBreadcrumb('Aposta');
        var vm = this;
        vm.search = {
            DataInicio: null,
            DataFim: null,
            Responsavel: undefined,
            IdSetor: 0,
            Tipo: 0,
            Status: 0
        };

        //Funções
        vm.init = init;
        vm.edit = edit;
        vm.jogar = jogar;

        //Feature Start
        init();

        //Implementations
        function init() {
            var blocker = blockUI.instances.get('blockGrid');
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
            var blocker = blockUI.instances.get('blockGrid');
            blocker.start();

            vm.Dados.numeros = vm.Dados.numeros.split(',');
            vm.Dados.jogadores = vm.Dados.jogadores.split(',');

            //vm.formValid = common.validateForm($scope.forms.editForm);
            //if (vm.formValid) {
                dsAposta
                    .criarMegaSena(vm.Dados)
                    .then(function (result) {
                        vm.listaJogos = result.data;
                    })
                    .finally(function () {
                        blocker.stop();
                    });
            //}
            //else {
            //    vm.AlertClassI = 'fa fa-exclamation-triangle';
            //    vm.AlertClassDiv = 'alert alert-danger';
            //    vm.AlertMessage = "Os campos são obrigatórios";
            //}
        }
        function edit(item) {
            var modalInstance = $modal.open({
                templateUrl: 'app/aposta/crud.html',
                controller: 'CrudAposta as vm',
                backdrop: true,
                size: 'lg',
                resolve: {
                    atividade: function () {
                        return item;
                    }
                }
            });
            modalInstance.result.then(function () {
                init();
            });
        }
    }
})();
