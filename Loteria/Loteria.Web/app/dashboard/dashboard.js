(function () {
    'use strict';

    angular
        .module('app.dashboard')
        .controller('Dashboard', Dashboard);

    Dashboard.$inject = ['$scope', '$http', '$q', 'blockUI', 'common', 'ds.dashboard'];

    function Dashboard($scope, $http, $q,blockUI, common, DsDashboard) {

        common.setBreadcrumb('dashboard');
        var vm = this;

        //Funções
        vm.init = init;

        //Feature Start
        init();

        //Implementations
        function init() {
            
        }
    }
})();