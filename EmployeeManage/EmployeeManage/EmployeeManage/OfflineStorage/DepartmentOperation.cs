using EmployeeManage.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManage.OfflineStorage
{
    public class DepartmentOperation
    {
        public static async void CreateDepartmentsList()
        {
            
            List<Departments> list = new List<Departments>
            {
                new Departments()
                {
                    ID = 1,
                    DepartmentName = "Associate Consultant"
                },
                new Departments()
                {
                    ID = 2,
                    DepartmentName = "Consultant"
                }

            };
            await App.DatabaseConnection.InsertAllAsync(list);
        }

        public static Task<List<Departments>> GetDepartmentsAsync()
        {
            //Get all notes.
            return App.DatabaseConnection.Table<Departments>().ToListAsync();
        }

        internal static object GetEmployeeAsync<T>()
        {
            throw new NotImplementedException();
        }
    }
}
