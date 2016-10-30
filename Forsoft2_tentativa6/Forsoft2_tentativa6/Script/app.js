var app = angular.module("app", []);

app.controller("EventosController", function ($http, $scope) {
    $http.get("/api/Eventos")
    .success(function (data) {
        console.log(data);
        $scope.dados = data;
    })
    .error(function (error) {
        console.log(error);
    });
});