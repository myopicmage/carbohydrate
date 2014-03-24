var caverns = angular.module('caverns', []);

caverns.controller('home', ['$scope', function ($scope) {
    $scope.greeting = "hello!";
    $scope.gamename = '';
    $scope.password = '';
}]);

caverns.controller('game', ['$scope', '$http', function($scope, $http) {
    $scope.name = "The Room (not Wiseau's)";
    $scope.points = 0;

    $scope.cards = [];

    $http.get('/api/Card/10').then(function (response) {
        if (response.status === 200) {
            $scope.cards = response.data;
        }
    });
}]);