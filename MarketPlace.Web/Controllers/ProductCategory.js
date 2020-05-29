miAppAngular.controller('ProductCategory', function ($scope, $http, ConnectApi) {

    $scope.isSend = false;

    $scope.ProductCategory = {
        Code: null,
        Name: null
    };


    $scope.saveProductCategory = function () {    

        if ($scope.myForm.$error.required != undefined) {
            toastr.info('check the form information.');
            return;
        }

        $scope.isSend = true;

        $http.post(ConnectApi.Connection + '/api/Products/Category/Add', $scope.ProductCategory).
            success(function (data, status, headers, config) {

                toastr.success('saved Category.');
                $scope.isSend = false;
                $scope.ClearForm();
                
            }).
            error(function (data, status, headers, config) {

                toastr.error(data);
                $scope.isSend = false;

            })
       
    }

    $scope.ClearForm = function () {
 
        $scope.ProductCategory = {
            Code: null,
            Name: null

        };
    }


});