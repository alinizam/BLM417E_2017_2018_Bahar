app.config(function($routeProvider){
    $routeProvider
    .when("/", {templateUrl:"index.html"})
    .when("/istanbul", {templateUrl:"istanbul.html"})
    .when("/ankara", {templateUrl:"Ankara.html"})
})