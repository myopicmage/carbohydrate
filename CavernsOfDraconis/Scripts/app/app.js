var caverns = angular.module('caverns', []);

caverns.controller('home', ['$scope', function ($scope) {
    $scope.greeting = "hello!";
    $scope.gamename = '';
    $scope.password = '';
}]);

caverns.controller('game', ['$scope', function($scope) {
    $scope.name = 'Game Title';
}]);