(function () {

    'use strict';
    angular
        .module('app')
        .controller('appController', appController);

    appController.$inject = ['$rootScope', '$scope', '$state', '$timeout'];

    function appController($rootScope, $scope, $state, $timeout) {

        //Roles/Profile
        $scope.$state = $state;

        //App Core (Theme)
        Core.init();
    }


})();