var app = angular.module('App', ['ngRoute']);

app.config(function ($routeProvider, $locationProvider) {
  $locationProvider.hashPrefix('');

  $routeProvider
    .when('/menulist', {
      templateUrl: 'views/menulist.html',
      controller: 'menulistCtrl'
    })
    .when('/additem', {
      templateUrl: 'views/additem.html',
      controller: 'menulistCtrl'
    }).when('/restaurantinfo', {
      templateUrl: 'views/restaurantinfo.html',
      controller: 'menulistCtrl'
    }).otherwise({
      redirectTo: '/menulist'
    });

});


app.controller('menulistCtrl', function ($scope, $http, $timeout) {
  //variables
  $scope.addSuccess = false;
  $scope.menu = [];


  var jsonLink = "http://li648-103.members.linode.com/api/MenuItems";
  $http.get(jsonLink).then(function (data) {
    $scope.menu = data.data;
    //console.log(JSON.stringify($scope.food));
  });
  $http.get("http://li648-103.members.linode.com/api/Tags").then(function (data) {
    var resultArray = [];
    for (let i of data.data) {
      resultArray.push(i.tagName);
    }
    $scope.tagNames = resultArray;
    console.log($scope.tagNames);
  });
  $scope.deleteitem = function (item, index) {
    console.log(item);
    //DELETE li648-103.members.linode.com/api/MenuItems/item.id
    $http.delete("http://li648-103.members.linode.com/api/MenuItems/" + item.id).then(function (data) {
      $scope.menu.splice(item.index, 1);
      $http.get(jsonLink).then(function (data) {
        $scope.menu = data.data;
        //console.log(JSON.stringify($scope.food));
      });
    });
  };

  $scope.additem = function () {
    if ($scope.newDiscount !== undefined && $scope.newDiscount.description !== undefined && $scope.newDiscount.discountPercentage !== undefined &&
      $scope.newDiscount.description.length != 0 && $scope.newDiscount.discountPercentage.length != 0) {
      $http.post("http://li648-103.members.linode.com/api/Discounts", JSON.stringify($scope.newDiscount)).then(function (data) {
        $scope.newItem.discountId = data.data;
        $http.post("http://li648-103.members.linode.com/api/MenuItems", JSON.stringify($scope.newItem)).then(function (data) {
          console.log("DATA SENT SUCCESSFULLY!");
          $scope.addSuccess = true;
          $timeout(function () { $scope.addSuccess = false; }, 3000);
        });
      });
    }
    else {
      $http.post("http://li648-103.members.linode.com/api/MenuItems", JSON.stringify($scope.newItem)).then(function (data) {
        console.log("DATA SENT SUCCESSFULLY!");
        $scope.addSuccess = true;
        $timeout(function () { $scope.addSuccess = false; }, 3000);
      });
    }
  };



  $scope.testApplication = function () {
    // testing code appears here
  };

});



