using ORM_Demo.Models;
using ORM_Demo.Models.DTO;
using ORM_Demo.Models.Enum;
using ORM_Demo.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * This is a Interface for the service provider of Database
 * 
 * It tells the service provider to ensure some speicific funcitonaliy :
 *                                                                      1st : Know the type of opeation 
 *                                                                      
 *                                                                      2nd: PreSave subroutine --> convert DTO -> POCO and set _id 
 *                                                                      
 *                                                                      3rd : Validate(only in case of edit operation) 
 *                                                                              --> check the correctness of _id and check if user exits
 *                                                                              
 *                                                                      4th : Save --> based on opeation update or insert
    
 
 
 */

namespace ORM_Demo.Data_Access.Reporitory
{
    public interface IAdminInterface<T> where T : class  // --> THis means the T must be a class here
    {
        // OpType Type { get; set; }

        // void PreSave(T dtoObj);

        // Response Validate();

        // Response Save();

        Response GetAll();

        Response GetById(int Id);

        Response AddAdmin(T _obj, string passw);

         Response UpdateAdmin(T _obj ,string passw = null);

        Response DeleteAdmin(int Id);

    }
}
