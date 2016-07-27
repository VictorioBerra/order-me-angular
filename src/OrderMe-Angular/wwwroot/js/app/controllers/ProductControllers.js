angular.module('orderMeApp')

.controller('ProductAddController', ProductAddController)
.controller('ProductListController', ProductListController)
.controller('ProductUpdateController', ProductUpdateController);

function ProductAddController(ProductService) {
    var vm = this;

    vm.add = add;
    
    function add() {
        ProductService.add(vm.newProductName, vm.newProductPrice)
        .then(function (res) {
            if (res.status == 200) {
                vm.newProductName = "";
                vm.newProductPrice = "";
            }            
        });
    }

}

function ProductListController(ProductService, products) {
    var vm = this;

    vm.products = products.data;
    vm.remove = remove;

    function remove(productId) {
        ProductService.remove(productId)
        .then(function (res) {
            if (res.status == 200) {
                vm.products = vm.products.filter(function (product) {                    
                    return product.productId != productId;
                });
            }
        });
    }

}

function ProductUpdateController($stateParams, $state, ProductService, product) {
    var vm = this;
    
    vm.product = product.data;
    vm.update = update;

    function update() {
        ProductService.update($stateParams.productId, vm.product.name, vm.product.price)
        .then(function (res) {
            if (res.status == 200) {
                $state.go('products.list');
            }
        });
    }

}