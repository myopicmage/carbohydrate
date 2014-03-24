var caverns = angular.module('caverns', []);

caverns.controller('home', ['$scope', function ($scope) {
    $scope.greeting = "hello!";
    $scope.gamename = '';
    $scope.password = '';
}]);

caverns.controller('game', ['$scope', '$http', function ($scope, $http) {
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
        if (response.status === 200) {
            $scope.cards = response.data;
        }
    });
}]);

caverns.directive('manageTable', function ($http) {
    function link(scope, element) {
        $(element).click(function () {
            $http.post('/api/Card', {
                title: scope.text,
                type: scope.colour
            }).success(function () {
                scope.cards.push({
                    title: scope.text,
                    type: scope.colour
                });

                scope.text = '';
            });
        });
    }

    return {
        link: link
    };
});