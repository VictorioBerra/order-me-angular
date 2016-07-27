angular.module('orderMeApp')
.factory('ProductService', ['$http', function ($http) {

    var urlBase = '/api/product';

    var ProductService = {};

    ProductService.getAll = function () {
        return $http.get(urlBase);
    }

    ProductService.add = function (name) {
        return $http.post(urlBase, name);
    }

    return ProductService;
}]);