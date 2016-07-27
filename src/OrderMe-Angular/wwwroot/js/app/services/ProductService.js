angular.module('orderMeApp')
.factory('ProductService', ['$http', function ($http) {

    var urlBase = '/api/product';

    var ProductService = {
        getAll: getAll,
        get: get,
        add: add,
        remove: remove,
        update: update
    };

    return ProductService;

    function getAll() {
        return $http.get(urlBase);
    }

    function get(id) {
        return $http.get(urlBase + "/" + id, id);
    }

    function remove(id) {
        return $http.delete(urlBase + "/" + id, id);
    }

    function add(name, price) {
        return $http.post(urlBase, {
                Name: name,
                Price: price
        });
    }

    function update(id, name, price) {
        return $http.put(urlBase + "/" + id, {
            ProductId: id,
            Name: name,
            Price: price
        });
    }
    
}]);