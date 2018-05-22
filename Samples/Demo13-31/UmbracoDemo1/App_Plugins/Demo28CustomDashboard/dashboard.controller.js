angular.module("umbraco").controller("demo.dashboard.controller", function ($scope, userService) {
    var vm = this;
    var user = userService.getCurrentUser().then(function (user) {
        console.log(user);
        vm.UserName = user.name;
    });
});