var EmployeeApp = angular.module('EmployeeApp', [])



EmployeeApp.controller('EmployeeController', function ($scope, EmployeeService) {

    getEmployees();

    function getEmployees() {
        EmployeeService.getEmployees()
            .success(function (employees) {
                $scope.employees = employees;
                console.log($scope.employees);
            })
            .error(function (error) {
                $scope.status = 'Unable to load employee data: ' + error.message;
                console.log($scope.status);
            });

    }
});


