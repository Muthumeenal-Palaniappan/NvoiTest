/// <reference path="c:\users\muthukumarpl\documents\visual studio 2015\Projects\MerchantApplicationFrontEnd\MerchantApplicationFrontEnd\scripts/angular.min.js" />

(function () {
    var app = angular.module('merchantModule', ['ngTable', 'ngResource']);
    app.controller('merchantController', function ($scope) {
        $scope.message = "Merchant Details";
    });
    //app.controller('apiResultController', function ($http,$scope) {
    //    $http.get("http://api.demo.muulla.com/cms/merchant/all/active/10/1").then(function (response) {
    //        $scope.mydata = response.data;
    //        $scope.statusText = response.statusText;
    //    });
    //});
    app.controller('merchantDetailController', function ($http, $scope) {
        debugger;
        var accessToken = 'eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiI1NGQxOTY4MGI1MWMxNTI2MGI5NDRmZDUiLCJpc3N1ZV9kYXRlIjoiMjAxNS0wOS0wOVQwNToxMzo1My40NThaIn0.Hk2XypA_KMUnIKdSVYnwq3Rn3QyMNSQ-e80-sZsA9bY';
        $http({
            method: 'GET',
            url: 'http://api.demo.muulla.com/cms/merchant/all/active/10/1',
            headers: {
                'Authorization': 'Bearer ' + accessToken
            },
        }).then(function successCallback(response) {
            debugger;
            $scope.merchantDetails = response.data;
        }, function errorCallback(response) {
            if (response.status = 401) { // If you have set 401
                $scope.error = "There are error";
            }
        });
    });
    app.controller("merchantDetailTablecontroller", function ($scope, $http, NgTableParams) {
        var accessToken = 'eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiI1NGQxOTY4MGI1MWMxNTI2MGI5NDRmZDUiLCJpc3N1ZV9kYXRlIjoiMjAxNS0wOS0wOVQwNToxMzo1My40NThaIn0.Hk2XypA_KMUnIKdSVYnwq3Rn3QyMNSQ-e80-sZsA9bY';
        //var Api = $resource('http://api.demo.muulla.com/cms/merchant/all/active/10/1',null, {
        //    'get': {
        //        method: 'GET', isArray: true, headers: {
        //            'Authorization': 'Bearer ' + accessToken}
        //        //,'Content-Type': 'application/json'}
        //    }
        //}, null);
        $scope.merchantstable = new NgTableParams({},
          //{  page: 1,//shows the first page
          //  count: 10//count of rows on page
          //},
            {
            getData: function (params) {
                debugger;
                          
                    var accessToken = 'eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiI1NGQxOTY4MGI1MWMxNTI2MGI5NDRmZDUiLCJpc3N1ZV9kYXRlIjoiMjAxNS0wOS0wOVQwNToxMzo1My40NThaIn0.Hk2XypA_KMUnIKdSVYnwq3Rn3QyMNSQ-e80-sZsA9bY';
                  return   $http({
                        method: 'GET',
                        url: 'http://api.demo.muulla.com/cms/merchant/all/active/10/1',
                        headers: {
                            'Authorization': 'Bearer ' + accessToken
                        },
                    }).then(function successCallback(response) {
                        debugger;
                        params.total(response.data.pagination.total_records);
                        params.count(response.data.pagination.page_size);
                        //params.page(1);
                        return response.data.data;
                    },
                    function errorCallback(response) {
                        if (response.status = 401) { // If you have set 401
                            $scope.error = "There are errors on http get";
                        }
                    });
            }
        });
        $scope.merchantstable.reload();
    });
})();