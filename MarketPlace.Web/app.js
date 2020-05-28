var miAppAngular = angular.module('MarketPlace', ['ngRoute']);

miAppAngular.config(['$routeProvider', function ($routeProvider) {

    $routeProvider.when('/', {
        templateUrl: 'Templates/Start.html',
        controller: 'Start'
    }).when('/Confirm', {
        templateUrl: 'Templates/Confirm.html',
        controller: 'Confirm'
    })
        .when('/Product', {
            templateUrl: 'Templates/Product.html',
            controller: 'Product'
        })
        .when('/ProductCategory', {
            templateUrl: 'Templates/ProductCategory.html',
            controller: 'ProductCategory'
        })
        .when('/404', {
            templateUrl: 'Templates/404.html',
            controller: 'Start'
        })
        .otherwise({

            redirectTo: '/404'

        })
    
}])