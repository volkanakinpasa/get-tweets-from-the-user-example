myApp.controller('TweetsCtrl', ['$scope', '$rootScope', '$http', 'tweetService', function ($scope, $rootScope, $http, tweetService) {
    $scope.tweets = [];
    var startGettingTweets = function () {
      
        var url = '/api/Tweet';
        if ($scope.lastTweetId != undefined) {
            url += '?sinceId=' + $scope.lastTweetId;
        }

        $http({
            method: 'GET',
            url: url,
        }).success(function (data, status, headers, config) {
            if (data != undefined) {

                if (data.tweets != undefined && data.tweets.length > 0) {
                    $scope.temp = [];

                    for (i = 0; i < data.tweets.length; i++) {
                        $scope.temp.push(data.tweets[i]);
                    }
                    for (i = 0; i < $scope.tweets.length; i++) {
                        $scope.temp.push($scope.tweets[i]);
                    }
                    $scope.tweets = $scope.temp;
                    $scope.lastTweetId = data.lastTweetId;

                }
            }

            setTimeout(function () {
                    startGettingTweets();
            }, 10000);

        }).error(function (data, status, headers, config) {
            $scope.errorMessageClass = "Opps! Something went wrong";
        });
    };
    startGettingTweets();
}]);