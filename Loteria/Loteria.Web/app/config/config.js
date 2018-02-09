/**
*  Configurações da App
*  ==============================================================
**/

(function () {
    'use strict';

    /*
    * App Global Configuration constant
    */

    angular
        .module('app.config')
        .constant('appConfig',
        {
            routePrefix: '',                                    // Prefixo para rotas do angular
            apiPrefix: 'http://localhost:65028',                // Prefixo as urls de chamada na API (sem '/' no final)
            loggerUrl: undefined,                               // Url logs API
            logExceptions: false
        });

})();
