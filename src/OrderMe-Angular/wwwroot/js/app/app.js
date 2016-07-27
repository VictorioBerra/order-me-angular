
var orderMeApp = angular.module('orderMeApp', ['ui.router']);

orderMeApp.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/home");

    $stateProvider
      .state('home', {
          url: "/home",
          templateUrl: "partials/home.html"
      });

});