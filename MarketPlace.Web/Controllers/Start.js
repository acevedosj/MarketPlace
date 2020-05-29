miAppAngular.controller('Start', function ($scope, $location, $http, ShoppingCart, ConnectApi) {

    $scope.ProductCategory = function () {

        var item = { Code: "01", Name: "All", ProductCategoryId: "*" }

        $http.get(ConnectApi.Connection + '/api/ProductCategory/List').
            success(function (data, status, headers, config) {

                $scope.ProductCategory = data;
                $scope.ProductCategory.push(item);
            }).
            error(function (data, status, headers, config) {
                toastr.error(data.Message);

            });
    }
    $scope.ProductCategory();


    $scope.getProduts = function () {

        $http.get(ConnectApi.Connection + '/api/Products/List').
            success(function (data, status, headers, config) {
                $scope.products = data;
                $scope.originProducts = data;
            }).
            error(function (data, status, headers, config) {

            });      
       
    }

    $scope.getProduts();

    $scope.searchByCategory = function (item) {
        $scope.products = $scope.originProducts.filter(i => i.CategoryId === item || item === "*");
     
    }

    $scope.searchByName = function () {
        var item = $scope.ProductName ? $scope.ProductName : '';
        $scope.products = $scope.originProducts.filter(i => i.Name.toLowerCase().trim() === item.toLowerCase().trim() || item.trim() === "");
    }

    $scope.cart = [];

    $scope.toBuy = function (_item) {
        _item.hide = true;
        $scope.cart.push(_item);
        ShoppingCart.products = $scope.cart;
    }

    $scope.remove = function (_item) {
        var index = $scope.cart.indexOf(_item);
        if (index > -1) {
            _item.hide = false;
            $scope.cart.splice(index, 1);
            ShoppingCart.products = $scope.cart;
        }
    }


    $scope.total = function () {
        var total = 0;
        for (item of $scope.cart) {

            total += item.UnitPrice;
        }

        ShoppingCart.total = total;
        return total;
    }

    $scope.finalize = function () {
        $location.path("/Confirm");
    }

});