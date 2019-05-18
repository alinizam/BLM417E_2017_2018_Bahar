var app = angular.module('ngApp', [])
app.controller('myCtrl', function ($scope, $http, veriService,veriEklemeService) {
    $scope.personel = [];
    $scope.filtre="";

   var returnData = function (dataResult, status) {
        $scope.personel = dataResult.data; 
        console.log( $scope.personel);
    }
    $scope.filtrele = function(){
        veriService.veriAl($scope.filtre).then(returnData);
        console.log($scope.personel);
        console.log($scope.filtre);
    };

    $scope.personelEkle = function(){
        let personel = {
            PId:$scope.id,
            Adi:$scope.adi,
            Soyadi:$scope.soyadi
        };
       // veriEklemeService.eklePersonel(personel);
        $http.post('http://localhost:51572/api/values',{'PId':'19','Adi':'HHHH'});
    }
});

app.service('veriService', ['$http',function ($http) {
    this.veriAl = function (filtre) {
        return $http.get('http://localhost:51572/api/values?filtre='+filtre);
    }
}]);

app.service('veriEklemeService',['$http',function($http){
    this.eklePersonel = function(personel){
        console.log(personel);
        $http.post('http://localhost:51572/api/values',{'PId':'19','Adi':'HHHH'});
    }
}])



