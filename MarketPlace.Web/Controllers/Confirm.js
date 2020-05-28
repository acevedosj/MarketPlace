miAppAngular.controller('Confirm', function ($scope, ShoppingCart) {

    $scope.total = ShoppingCart.total;
    $scope.products = ShoppingCart.products;

});