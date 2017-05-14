var app = angular.module('App', ['ngRoute']);

app.config(function($routeProvider,$locationProvider){
  $locationProvider.hashPrefix('');

  $routeProvider
    .when('/menulist',{
      templateUrl: 'views/menulist.html',
      controller: 'menulistCtrl'
  })
    .when('/additem',{
      templateUrl: 'views/additem.html',
      controller: 'menulistCtrl'
  }).when('/restaurantinfo',{
      templateUrl: 'views/restaurantinfo.html',
      controller: 'menulistCtrl'
  }).otherwise({
    redirectTo: '/menulist'
  });

});


app.controller('menulistCtrl',function($scope, $http, $timeout) {
  //variables
  $scope.addSuccess = false;
  
  var jsonLink = "http://li648-103.members.linode.com/api/MenuItems";
  $http.get(jsonLink).then(function(data){
    $scope.menu = data.data;
    //console.log(JSON.stringify($scope.food));
  });
  $http.get("http://li648-103.members.linode.com/api/Tags").then(function(data)
  {
    var resultArray = [];
    for (let i of data.data)
      {
        resultArray.push(i.tagName);
      }
    $scope.tagNames = resultArray;
    console.log($scope.tagNames);
  });
  $scope.deleteitem = function(item,index){
    //DELETE li648-103.members.linode.com/api/MenuItems/item.id
  };

  $scope.additem = function(){
    $http.post("http://li648-103.members.linode.com/api/MenuItems", JSON.stringify($scope.newItem)).then(function(data){
      console.log("DATA SENT SUCCESSFULLY!");
      $scope.addSuccess = true;
      $timeout(function () { $scope.addSuccess = false; }, 3000);
    });
  };
  
  

  $scope.testApplication = function()
  {
    // testing code appears here
  };
  
});



