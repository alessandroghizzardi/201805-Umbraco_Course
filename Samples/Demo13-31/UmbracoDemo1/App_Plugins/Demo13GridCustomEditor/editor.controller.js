angular.module("umbraco").controller("demo.gridcustomeditor", function ($scope) {
    var currentVal = $scope.control.value;
    console.log("demo.gridcustomeditor");
    console.log(currentVal);
    if (!currentVal) {
        $scope.control.value = "Default value from controller ";
    }
});