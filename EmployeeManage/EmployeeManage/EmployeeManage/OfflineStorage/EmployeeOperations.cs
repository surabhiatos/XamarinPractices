using EmployeeManage.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManage.OfflineStorage
{
    public class EmployeeOperations
    {
        public static Task<List<Employee>> GetEmployeeAsync()
        {
            //Get all notes.
            return App.DatabaseConnection.Table<Employee>().ToListAsync();
        }

        public static Task<Employee> GetEmployeeAsync(int id)
        {
            // Get a specific note.
            return App.DatabaseConnection.Table<Employee>()
                            .FirstOrDefaultAsync(i => i.ID == id);
        }

        public static Task<int> InsertOrUpdateEmployeeAsync(Employee note)
        {
            if (note.ID != 0)
            {
                // Update an existing note.
                return App.DatabaseConnection.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return App.DatabaseConnection.InsertAsync(note);
            }
        }

        public static Task<int> DeleteEmployeeAsync(Employee note)
        {
            // Delete a note.
            return App.DatabaseConnection.DeleteAsync(note);
        }
    }

}
