EmployeeApp.factory('EmployeeService', ['$http', function ($http) {
 
    var EmployeeService = {};
    EmployeeService.getEmployees = function () {
        return $http.get('/Employee/GetAllEmployees');
        };

    return EmployeeService;

}]);
