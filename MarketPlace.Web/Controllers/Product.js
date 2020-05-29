﻿miAppAngular.controller('Product', function ($scope, $http,ShoppingCart) {

    $scope.isSend = false;

    $scope.Product = {
        Code: null,
        Name: null,
        UnitPrice: null,
        CategoryId: null,
        CategoryCode: null,
        CategoryName: null

    };

    $scope.Image = null;


    $scope.saveProduct = function () {

       
        if ($scope.myForm.$error.required != undefined) {
            toastr.info('check the form information.');
            return;
        }
            
        $scope.isSend = true;

        $scope.data = new FormData();
        $scope.Accept = 'application/json';
        $scope.data.append("application/json", JSON.stringify($scope.Product))
        if ($scope.Image != null) {
            $scope.data.append($scope.Image.name, $scope.Image);
        }

        var BuildHeaders = ({
            'Content-Type': undefined,
            'Accept': $scope.Accept
        });

        $scope.promise = $http({
            method: 'POST',
            url: 'https://merkaplaceapi.azurewebsites.net/api/Products/Add',
            headers: BuildHeaders,
            transformRequest: angular.identity,
            data: $scope.data
        }).success(function (data, status, headers, config) {
            toastr.success('saved product.');
            $scope.isSend = false;
            $scope.ClearForm();
            console.log("ok")
        }).error(function (data, status, headers, config) {
            toastr.error(data.Message);
            $scope.isSend = false;
            console.log("error")
        });
       
    }

    $scope.ClearForm = function () {
        $scope.Image = null;
        $scope.Product = {
            Code: null,
            Name: null,
            UnitPrice: null,
            CategoryId: null,
            CategoryCode: null,
            CategoryName: null

        };
    }

    $scope.ProductCategory = function () {        
        //https://localhost:44381
        $http.get('https://merkaplaceapi.azurewebsites.net/api/ProductCategory/List').
            success(function (data, status, headers, config) {
                // this callback will be called asynchronously
                // when the response is available
                $scope.ProductCategory = data;
            }).
            error(function (data, status, headers, config) {
                toastr.error(data.Message);
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
    }
    $scope.ProductCategory();

    $scope.fileNameChanged = function (item) {
        var file = item.files;
        if (file.length>0)
            $scope.Image = item.files[0];
    }

});