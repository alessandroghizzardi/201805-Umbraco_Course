angular.module("umbraco").controller("demo.custompropertyeditor", function ($scope, notificationsService) {
//angular.module("umbraco").controller("demo.custompropertyeditor", function ($scope) {
    $scope.limitchars = function () {
        console.log($scope.model);

        //var limit = 30;
        var limit = $scope.model.config.charLimit;
        var length = $scope.model.value.length;
        if (length > limit) {
            $scope.info = "You cannot write more than " + limit + " characters";
            $scope.model.value = $scope.model.value.substr(0, limit);
            notificationsService.remove(0);
            notificationsService.error($scope.info);
        }
        else {
            var remaining = (limit - length);
            $scope.info = "You have " + remaining + " characters left";
        }

        console.log('demo.custompropertyeditor');
        console.log(limit);
        console.log(length);
    }
});