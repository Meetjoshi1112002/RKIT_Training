using CRUD_Demo.Extension;
using CRUD_Demo.Models;
using CRUD_Demo.Models.DTO;
using CRUD_Demo.Models.ENUM;
using CRUD_Demo.Models.POCO;
using MySql.Data.MySqlClient;

namespace CRUD_Demo.BL
{
    public class BLEmployee : IUserService<DTOEMP01>
    {
        private string connecitonString = "Server=127.0.0.1;Port=3306;Database=dbwithcdemofinal;User Id=Admin;Password=gs@123";

        private int _id;

        private EMP01 _empObj;

        public Operation OpType { get; set; }

        public Response _responseObj;

        public BLEmployee()
        {
            _responseObj = new();
        }

        #region Private method to check if the user exists
        private bool ISEMP01Exists(int id)
        {
            // Define the SQL query to check if the employee exists
            string query = "SELECT COUNT(*) FROM EMP01 WHERE P01F01 = @id";  // Assuming P01F01 is the ID column in EMP01 table

            try
            {
                // Create a new MySqlConnection using the connection string
                using (MySqlConnection conn = new MySqlConnection(connecitonString))
                {
                    // Open the connection
                    conn.Open();

                    // Create a new MySqlCommand object with the query and the connection
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add the parameter to the command to prevent SQL injection
                        cmd.Parameters.AddWithValue("@id", id);

                        // Execute the query and get the result (count of records)
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // If the count is greater than 0, the employee exists
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the database operation
                Console.WriteLine("An error occurred while checking if the employee exists: " + ex.Message);
                return false;
            }
        }
        #endregion

        #region PreDelete , to the _id for the delete operation
        public void PreDelete(int _id)
        {
            if (_id < 1) throw new Exception("provice a valid ID");
            this._id = _id;
        }
        #endregion

        #region PreSave: here we convert the dtot ot poco for futher process and set the _id for ins ,upd
        public void PreSave(DTOEMP01 dtoobj)
        {
            if (dtoobj == null || dtoobj.P01F01 <= 0)
            {
                throw new ArgumentNullException("proivde vallid dto");
            }

            _empObj = dtoobj.Convert<EMP01>();
            _id = dtoobj.P01F01;
        }
        #endregion

        #region Validate --> based on operation , we validate wheater the user exists or not
        public Response Validate()
        {
            bool Exists = ISEMP01Exists(_id);

            if(OpType == Operation.Add && Exists)
            {
                _responseObj.ErrorStatus = true;
                _responseObj.Message = "User already exists or cannot adde";
            }
            else if((OpType == Operation.Update || OpType == Operation.Delete) && !Exists)
            {
                _responseObj.ErrorStatus = true;
                _responseObj.Message = "User Not foudn";
            }
            return _responseObj;
        }
        #endregion

        #region Save --> Here we based on the type of opertion , perform the action  on databse
        public Response Save()
        {
            try
            {
                // Create a MySqlConnection object inside the using block to automatically close it after usage
                using (MySqlConnection conn = new MySqlConnection(connecitonString))
                {
                    // Open the database connection
                    conn.Open();

                    // Prepare the MySqlCommand object based on the operation type (Add, Update, Delete)
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if (OpType == Operation.Add)
                    {
                        // Add a new user to the database using an INSERT query
                        string query = "INSERT INTO EMP01 (P01F01,P01F02, P01F03, P01F04) VALUES (@P01F01, @P01F02, @P01F03, @P01F04)";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@P01F01", _id);  // User Id
                        cmd.Parameters.AddWithValue("@P01F02", _empObj.P01F02);  // User Name
                        cmd.Parameters.AddWithValue("@P01F03", _empObj.P01F03);  // User Email
                        cmd.Parameters.AddWithValue("@P01F04", _empObj.P01F04);  // User Password

                        // Execute the query (returns the number of affected rows)
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if a user was added successfully
                        if (rowsAffected > 0)
                        {
                            _responseObj.ErrorStatus = false;
                            _responseObj.Message = "User added successfully.";
                        }
                        else
                        {
                            _responseObj.ErrorStatus = true;
                            _responseObj.Message = "Failed to add user.";
                        }
                    }
                    else if (OpType == Operation.Update)
                    {
                        // Update an existing user in the database
                        string query = "UPDATE EMP01 SET P01F02 = @P01F02, P01F03 = @P01F03, P01F04 = @P01F04 WHERE P01F01 = @P01F01";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@P01F01", _empObj.P01F01);  // User ID
                        cmd.Parameters.AddWithValue("@P01F02", _empObj.P01F02);  // User Name
                        cmd.Parameters.AddWithValue("@P01F03", _empObj.P01F03);  // User Email
                        cmd.Parameters.AddWithValue("@P01F04", _empObj.P01F04);  // User Password

                        // Execute the query (returns the number of affected rows)
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if the user was updated successfully
                        if (rowsAffected > 0)
                        {
                            _responseObj.ErrorStatus = false;
                            _responseObj.Message = "User updated successfully.";
                        }
                        else
                        {
                            _responseObj.ErrorStatus = true;
                            _responseObj.Message = "Failed to update user.";
                        }
                    }
                    else if (OpType == Operation.Delete)
                    {
                        // Delete the user by ID from the database
                        string query = "DELETE FROM EMP01 WHERE P01F01 = @P01F01";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@P01F01", _id);  // User ID to delete

                        // Execute the query (returns the number of affected rows)
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if the user was deleted successfully
                        if (rowsAffected > 0)
                        {
                            _responseObj.ErrorStatus = false;
                            _responseObj.Message = "User deleted successfully.";
                        }
                        else
                        {
                            _responseObj.ErrorStatus = true;
                            _responseObj.Message = "Failed to delete user.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the operation
                _responseObj.ErrorStatus = true;
                _responseObj.Message = ex.Message;
            }

            return _responseObj;
        }
        #endregion

        #region Get employee by id
        public Response GetById(int id)
        {
            try
            {

                // Define the SQL query to fetch employee by ID
                string query = "SELECT P01F01, P01F02, P01F03, P01F04 FROM EMP01 WHERE P01F01 = @P01F01";

                using (MySqlConnection conn = new MySqlConnection(connecitonString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameter to prevent SQL injection
                        cmd.Parameters.AddWithValue("@P01F01", id);

                        // Execute the query and read the result
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Convert data from the reader to ReadDTOEMP01
                                var employeeDto = new ReadDTOEMP01
                                {
                                    P01F01 = reader.GetInt32("P01F01"),
                                    P01F02 = reader.GetString("P01F02"),
                                    P01F03 = reader.GetString("P01F03")
                                };

                                // Return success response with employee data
                                _responseObj.ErrorStatus = false;
                                _responseObj.Message = "Employee found.";
                                _responseObj.data = employeeDto;
                            }
                            else
                            {
                                _responseObj.ErrorStatus = true;
                                _responseObj.Message = "No employee found with the given ID.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _responseObj.ErrorStatus = true;
                _responseObj.Message = "Error: " + ex.Message;
            }

            return _responseObj;
        }
        #endregion

        #region Get all Employee
        public Response GetAll()
        {
            try
            {
                // Define the SQL query to fetch all employees
                string query = "SELECT P01F01, P01F02, P01F03, P01F04 FROM EMP01";

                List<ReadDTOEMP01> employeeList = new List<ReadDTOEMP01>();

                using (MySqlConnection conn = new MySqlConnection(connecitonString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Execute the query and read the result
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Convert data from the reader to ReadDTOEMP01
                                var employeeDto = new ReadDTOEMP01
                                {
                                    P01F01 = reader.GetInt32("P01F01"),
                                    P01F02 = reader.GetString("P01F02"),
                                    P01F03 = reader.GetString("P01F03")
                                };
                                employeeList.Add(employeeDto);
                            }

                            // If no employees found, return an appropriate message
                            if (employeeList.Count == 0)
                            {
                                _responseObj.ErrorStatus = true;
                                _responseObj.Message = "No employees found.";
                            }
                            else
                            {
                                // Return success response with the list of employees
                                _responseObj.ErrorStatus = false;
                                _responseObj.Message = "Employees retrieved successfully.";
                                _responseObj.data = employeeList;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _responseObj.ErrorStatus = true;
                _responseObj.Message = "Error: " + ex.Message;
                Console.WriteLine(ex.Message);
            }

            return _responseObj;
        }
        #endregion






    }
}
