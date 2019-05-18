angular.module('ngApp', [])
.controller('myCtrl', function($scope, $http) {
    $http.get('http://localhost:51572/api/values').
        then(function(response) {
            $scope.personel = response.data;
        });
});
