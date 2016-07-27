angular.module('orderMeApp')

.controller('ProductAddController', ProductAddController)

.controller('ProductListController', ProductListController);

function ProductAddController(ProductService, toaster) {
    var vm = this;

    vm.add = add;

    function add() {
        var res = ProductService.add(vm.newProductName);

        if (res.status = 200)
            toaster.success("Added: '" + vm.newProductName + "'");
    }
}

function ProductListController(products) {
    var vm = this;

    vm.products = products.data;
}