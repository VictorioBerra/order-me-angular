
var orderMeApp = angular.module('orderMeApp', [
    'ui.router',
    'ngAnimate'
]);

orderMeApp.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/products");

    $stateProvider
      .state('products', {
          url: "/products",
          templateUrl: "js/app/partials/products/index.html"
      })
        .state('products.list', {
            url: "/list",
            templateUrl: "js/app/partials/products/list.html",
            resolve: {
                products: function (ProductService) {
                    return ProductService.getAll();
                }
            },
            controller: 'ProductListController as vm'
        })
        .state('products.add', {
            url: "/add",
            templateUrl: "js/app/partials/products/add.html",
            controller: 'ProductAddController as vm'
        })
        .state('products.update', {
            url: "/update/:productId",
            resolve: {
                product: function (ProductService, $stateParams) {                    
                    return ProductService.get($stateParams.productId);
                }
            },
            templateUrl: "js/app/partials/products/update.html",
            controller: 'ProductUpdateController as vm'
        })

});