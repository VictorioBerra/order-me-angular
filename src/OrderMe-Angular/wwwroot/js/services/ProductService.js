angular.module('orderMeApp')
.factory('ProductService', ['$http', function ($http) {

    var urlBase = '/api/product';

    var ProductService = {
        getAll: getAll,
        add: add
    };

    return ProductService;

    function getAll() {
        return $http.get(urlBase);
    }

    function remove(id) {
        return $http.delete(urlBase, id);
    }

    function add(name) {
        return $http.post(urlBase, {
            "product": {
                Name: name
            }
        });
    }
    
}]);