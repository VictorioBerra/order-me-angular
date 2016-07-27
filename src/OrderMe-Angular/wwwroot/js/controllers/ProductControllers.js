angular.module('orderMeApp')

.controller('ProductAddController', ProductAddController)

.controller('ProductListController', ProductListController);

function ProductAddController(ProductService) {
    var vm = this;

    vm.add = add;

    function add() {
        ProductService.add(vm.newProductName);
    }
}

function ProductListController(products) {
    var vm = this;

    vm.products = products.data;
}