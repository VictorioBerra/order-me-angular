
var orderMeApp = angular.module('orderMeApp', ['ui.router']);

orderMeApp.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/products");

    $stateProvider
      .state('products', {
          url: "/products",
          templateUrl: "partials/products/index.html"
      })
        .state('products.list', {
            url: "/list",
            templateUrl: "partials/products/list.html",
            resolve: {
                products: function (ProductService) {
                    return ProductService.getAll();
                }
            },
            controller: 'ProductListController as product'
        })
        .state('products.add', {
            url: "/add",
            templateUrl: "partials/products/add.html",
            controller: 'ProductAddController as product'
        })

});