var app = angular.module('ngApp', [])
app.controller('myCtrl', function ($scope, $http, veriFactory) {
   var returnData = function (dataResult, status) {
        $scope.personel = dataResult.data; 
        console.log( $scope.personel);
    }
    veriFactory.veriAl().then(returnData);
});

app.service('veriService', function ($http) {
    this.veriAl = function () {
        return $http.get('http://localhost:51572/api/values');
    }
});

app.factory('veriFactory', function ($http) {
    var factory = {};
    factory.veriAl = function () {
        return $http.get('http://localhost:51572/api/values')
            .then(function (data, status) {
                console.log("Veri alan fonksiyon çağrıldı");
                return data;
            }).catch(function (data, status) {
                console.log("Hata oldu" + status);
            });
    }
    return factory;
});




