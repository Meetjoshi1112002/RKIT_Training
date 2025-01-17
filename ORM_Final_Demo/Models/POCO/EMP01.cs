using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * THis PCOC is basically a reflection of my actul DB table
 * 
 * ORM Lite assumes that your class represents a database table, and each property corresponds to a column in that table.
 * 
 * By default, it assumes that the table name is the class name and the column names are the property names.
 * 
 * Some useful attributes :
        [Alias]: Specify the table name.
        [Field]: Specify the column name.
        [PrimaryKey]: Mark the primary key field.
        [AutoIncrement]: Mark the field as auto-incrementing.
        [Index]: Define an index on a column.
        [Ignore]: Ignore the property during database operations.
        [ForeignKey]: For foreign key relationships.
 
 */

namespace ORM_Final_Demo.Models.POCO
{
    public class EMP01
    {
        [PrimaryKey]
        public int P01F01 { get; set; }   // ID of the user

        public string P01F02 { get; set; } // Name of the user

        public DateTime P01F03 { get; set; } // This is user Birth Date

        public string P01F04 { get; set; }  // The password of user
    }
}
