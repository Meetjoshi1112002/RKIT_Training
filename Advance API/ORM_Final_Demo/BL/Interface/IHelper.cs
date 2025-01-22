using ORM_Final_Demo.Models;
using ORM_Final_Demo.Models.Enum;
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

namespace ORM_Final_Demo.ServiceProvicer.Interface
{
    public interface IHelper<T> 
    {
        Op Type { get; set; }
        Response GetById(int id);

        Response GetAll();

        void PreSave(T objDto);

        Response Validate();

        Response Save();
    }
}
