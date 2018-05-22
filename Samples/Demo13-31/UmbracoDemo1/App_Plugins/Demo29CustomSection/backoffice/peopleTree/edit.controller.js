﻿angular.module("umbraco").controller("People.PersonEditController",
	function ($scope, $routeParams, personResource, notificationsService, navigationService) {
        
	    $scope.loaded = false;

        if ($routeParams.id == -1) {
            $scope.person = {};
            $scope.loaded = true;
        }
        else {
            //get a person id -> service
            personResource.getById($routeParams.id).then(function (response) {
                $scope.person = response.data;

                console.log(response.data);
                console.log($scope.person);
                $scope.loaded = true;
            });
        }

	    $scope.save = function (person) {
	        personResource.save(person).then(function (response) {
	            $scope.person = response.data;
	            $scope.personForm.$dirty = false;
	            navigationService.syncTree({ tree: 'peopleTree', path: [-1, -1], forceReload: true });
	            notificationsService.success("Success", person.firstName + " " + person.lastName + " has been saved");
	        });
	    };

	   
	});