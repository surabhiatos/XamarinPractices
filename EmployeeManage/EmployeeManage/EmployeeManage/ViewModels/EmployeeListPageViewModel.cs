using EmployeeManage.Models;
using EmployeeManage.OfflineStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmployeeManage.ViewModels
{
    public class EmployeeListPageViewModel : BaseViewModel
    {
        public EmployeeListPageViewModel()
        {

        }

        private List<Employee> _employeeList;
        public List<Employee> EmployeeList
        {
            get => _employeeList;
            set
            {
                if (value != _employeeList)
                {
                    _employeeList = value;
                    OnPropertyChanged(nameof(EmployeeList));
                }
            }
        }


        private string _searchBarText;
        public string SearchBarText
        {
            get => _searchBarText;
            set
            {
                if (value != _searchBarText)
                {
                    _searchBarText = value;
                    Search();
                    OnPropertyChanged(nameof(SearchBarText));
                }
            }
        }

        private async void Search()
        {
            try
            {
                if (string.IsNullOrEmpty(SearchBarText))
                    EmployeeList = await EmployeeOperations.GetEmployeeAsync();
                else
                {
                    List<Models.Employee> employees = await EmployeeOperations.GetEmployeeAsync();
                    EmployeeList = employees.Where(x => x.FirstName.ToLower().StartsWith(SearchBarText.ToLower())).ToList();
                }
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Error", ex.Message, "OK");
            }

        }

        public ICommand AddEmployeeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsEnabled = false;
                    await Application.Current.MainPage.Navigation.PushAsync(new AddViewPage(null));
                    IsEnabled = true;
                });
            }
        }

        public ICommand DeleteEmployeeCommand
        {
            get
            {
                return new Command<Employee>(async (employee) =>
                {
                    IsEnabled = false;
                    await EmployeeOperations.DeleteEmployeeAsync(employee);
                    IsEnabled = true;
                });
            }
        }

        public ICommand EditEmployeeCommand
        {
            get
            {
                return new Command<Employee>(async (employee) =>
                {
                    IsEnabled = false;
                    await Application.Current.MainPage.Navigation.PushAsync(new AddViewPage(employee));
                    IsEnabled = true;
                });
            }
        }

        public ICommand ViewEmployeeCommand
        {
            get
            {
                return new Command<Employee>(async (employee) =>
                {
                    IsEnabled = false;
                    await Application.Current.MainPage.Navigation.PushAsync(new AddViewPage(employee,false));
                    IsEnabled = true;
                });
            }
        }

    }
}
