
using EmployeeManage.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using EmployeeManage.Models;
using EmployeeManage.OfflineStorage;

namespace EmployeeManage
{
    public partial class App : Application
    {
        private static SQLiteAsyncConnection Database = null;
        public static SQLiteAsyncConnection DatabaseConnection
        {
            get
            {
                if (Database == null)
                    Database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                return Database;
            }

        }
        private void CreateDBTables()
        {
            DatabaseConnection.CreateTableAsync<Employee>().Wait();
            DatabaseConnection.DropTableAsync<Departments>().Wait();
            DatabaseConnection.CreateTableAsync<Departments>().Wait();
            DepartmentOperation.CreateDepartmentsList();
        }


        public App()
        {
            InitializeComponent();
            CreateDBTables();

           // DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPageEmp());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
