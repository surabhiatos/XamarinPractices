using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EmployeeManage.Models
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int ID { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public DateTime Birthday { get; set; }

        public int Department { get; set; }


        public string Address { get; set; }

        public int Gender { get; set; }

        public string Package { get; set; }
        
    }
   

}
