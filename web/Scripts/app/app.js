angular.module('tweetService', [])
    .service('tweetService', ['$http', function ($http) {
        this.getTweets = function (lastTweetId, callback) {
            $http({
                method: 'GET',
                url: '/api/Tweet/' + lastTweetId,
            }).success(function (data, status, headers, config) {
                callback(data, status, headers, config);

            }).error(function (data, status, headers, config) {
                callback(data, status, headers, config);
            });

        };
    }]);

var myApp = angular.module('myApp', ['ngRoute', 'tweetService', 'ngSanitize']);
