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

caverns.controller('manage', ['$scope', '$http', function ($scope, $http) {
    $scope.cards = [];
    $scope.colour = 'white';
    $scope.text = '';

    $http.get('/api/Card/10').then(function (response) {
        console.log(response);

        if (response.status === 200) {
            $scope.cards = response.data;
        }
    });
}]);

caverns.directive('manageTable', function ($http) {
    function link(scope, element, attrs) {
        $(element).on('$click', function () {
            console.log(scope);
            console.log(attrs);
        });
    }

    return {
        link: link
    }
});