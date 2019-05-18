var app = angular.module('ngApp', [])
app.controller('myCtrl', function ($scope, $http, veriService,
                                   veriEklemeService) {
    $scope.personel = [];
    $scope.filtre="";
    $scope.isim='ahmet';

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
        veriEklemeService.eklePersonel(personel);
        //$http.post('http://localhost:51572/api/values', personel);
    }
});

app.service('veriService', ['$http',function ($http) {
    this.veriAl = function (filtre) {
        return $http.get('http://localhost:51572/api/values?filtre='+filtre);
    }
}]);

app.service('veriEklemeService',['$http',function($http){
    this.eklePersonel = function(personel){
        let options = {
            headers: this.headers,
            withCredentials: true
            };

        //Personel object automatically map
        var url = 'http://localhost:51572/api/values', data = personel;

        $http.post(url, data, options).then(function (response) {
            // This function handles success
            console.log("personel information has been inserted." + response);
            
        }, function (response) {
        
        // this function handles error
             console.log("Inserted error." + response);
        });
        
    }
}])

app.service('veriEklemeStandartService',['$http',function($http){
    this.eklePersonel = function(personel){
        console.log(personel);
        //Personel object automatically map
        $http.post('http://localhost:51572/api/values',personel).then;
    }
}])


app.directive('personelBilgi',function(){
    return {
        template:"<h1>Merhaba</h1>"
    };
} )


app.directive('personelForm',function(){
    return {
        templateUrl:"personel.html"
    };
} )


