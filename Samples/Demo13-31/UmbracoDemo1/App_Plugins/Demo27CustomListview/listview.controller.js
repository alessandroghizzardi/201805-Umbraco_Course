(function () {
    "use strict";

    function DemoListviewLayoutController($scope, listViewHelper, $location, mediaResource, mediaHelper) {

        //vm is a shorthand for view model, used to communicate between view and controller
        var vm = this;

        vm.selectItem = selectItem;
        vm.clickItem = clickItem;

        // Init the controller
        function activate() {

            // Load background image for each item
            angular.forEach($scope.items, function (item) {
                console.log('Loading background image');
                //getBackgroundImage(item);
            });
        }

        //// Load background image
        //function getBackgroundImage(item) {
        //    mediaResource.getById(item.image)
        //        .then(function (media) {
        //            // find the image thumbnail
        //            item.imageThumbnail = mediaHelper.resolveFile(media, true);
        //        });
        //}

        // Item select handler
        function selectItem(selectedItem, $event, index) {

            // use the list view helper to select the item
            listViewHelper.selectHandler(selectedItem, index, $scope.items, $scope.selection, $event);
            $event.stopPropagation();

        }

        // Item click handler
        function clickItem(item) {

            // change path to edit item
            $location.path($scope.entityType + '/' + $scope.entityType + '/edit/' + item.id);

        }

        activate();

    }

    angular.module("umbraco").controller("demo.listview.controller", DemoListviewLayoutController);

})();