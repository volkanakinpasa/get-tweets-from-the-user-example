myApp.config(['$routeProvider', function($routeProvider) {
    
    $routeProvider.when('/tweets', {
        templateUrl: 'template-tweets.html',
        controller: 'TweetsCtrl'
    }).otherwise({
        templateUrl: 'template-tweets.html',
        redirectTo: '/tweets'
    });

}]);
