using CRUD_Demo.BL;
using CRUD_Demo.Models;
using CRUD_Demo.Models.DTO;
using CRUD_Demo.Models.ENUM;

namespace CRUD_Demo.Controller
{
    public static class ApiController
    {
        private static readonly BLEmployee _empServices;

        // Static constructor to initialize the service object
        static ApiController()
        {
            _empServices = new BLEmployee();
        }

        #region Add Employee (POST)
        public static Response AddEmployee(DTOEMP01 dtoemp)
        {
            try
            {
                _empServices.OpType = Operation.Add;
                _empServices.PreSave(dtoemp);

                // Validate and save the employee data
                Response validationResponse = _empServices.Validate();
                if (validationResponse.ErrorStatus)
                {
                    return validationResponse; // If validation fails, return the error response
                }

                return _empServices.Save(); // Save the employee data
            }
            catch (Exception ex)
            {
                return new Response { ErrorStatus = true, Message = $"Error: {ex.Message}" };
            }
        }
        #endregion

        #region Update Employee (PUT)
        public static Response UpdateEmployee(DTOEMP01 dtoemp)
        {
            try
            {
                _empServices.OpType = Operation.Update;
                _empServices.PreSave(dtoemp);

                // Validate and save the employee data
                var validationResponse = _empServices.Validate();
                if (validationResponse.ErrorStatus)
                {
                    return validationResponse; // If validation fails, return the error response
                }

                return _empServices.Save(); // Save the updated employee data
            }
            catch (Exception ex)
            {
                return new Response { ErrorStatus = true, Message = $"Error: {ex.Message}" };
            }
        }
        #endregion

        #region Delete Employee (DELETE)
        public static Response DeleteEmployee(int id)
        {
            try
            {
                _empServices.OpType = Operation.Delete;
                _empServices.PreDelete(id);

                // Validate and delete the employee data
                var validationResponse = _empServices.Validate();
                if (validationResponse.ErrorStatus)
                {
                    return validationResponse; // If validation fails, return the error response
                }

                return _empServices.Save(); // Delete the employee data
            }
            catch (Exception ex)
            {
                return new Response { ErrorStatus = true, Message = $"Error: {ex.Message}" };
            }
        }
        #endregion

        #region Get Employee By Id (GET)
        public static Response GetEmployeeById(int id)
        {
            try
            {
                return _empServices.GetById(id); // Get employee data by id
            }
            catch (Exception ex)
            {
                return new Response { ErrorStatus = true, Message = $"Error: {ex.Message}" };
            }
        }
        #endregion

        #region Get All Employees (GET)
        public static Response GetAllEmployees()
        {
            try
            {
                return _empServices.GetAll(); // Get all employees
            }
            catch (Exception ex)
            {
                return new Response { ErrorStatus = true, Message = $"Error: {ex.Message}" };
            }
        }
        #endregion
    }
}
