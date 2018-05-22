angular.module("umbraco.resources")
	.factory("personResource", function ($http) {
	    return {
	        getById: function (id) {
                return $http.get("backoffice/Demo29CustomSection/PersonApi/GetById?id=" + id);
	        },
	        save: function (person) {
                return $http.post("backoffice/Demo29CustomSection/PersonApi/PostSave", angular.toJson(person));
	        },
            deleteById: function(id) {
                return $http.delete("backoffice/Demo29CustomSection/PersonApi/DeleteById?id=" + id);
            }
	    };
	});