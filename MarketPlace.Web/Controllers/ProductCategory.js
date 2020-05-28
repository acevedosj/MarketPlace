miAppAngular.controller('ProductCategory', function ($scope, $http) {

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

        $http.post('https://merkaplaceapi.azurewebsites.net/api/Products/Category/Add', $scope.ProductCategory).
            success(function (data, status, headers, config) {
                // this callback will be called asynchronously
                // when the response is available
                toastr.success('saved Category.');
                $scope.isSend = false;
                $scope.ClearForm();
                console.log("ok")
            }).
            error(function (data, status, headers, config) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                toastr.error(data.Message);
                $scope.isSend = false;
                console.log("error")
            })
       
    }

    $scope.ClearForm = function () {
 
        $scope.ProductCategory = {
            Code: null,
            Name: null

        };
    }


});