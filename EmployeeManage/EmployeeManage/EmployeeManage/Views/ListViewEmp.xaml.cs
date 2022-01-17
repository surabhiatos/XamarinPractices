using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EmployeeManage.OfflineStorage;
using EmployeeManage.Models;
using EmployeeManage.ViewModels;

namespace EmployeeManage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewEmp : ContentPage
    {
        private static EmployeeListPageViewModel viewModel = null;
        public static EmployeeListPageViewModel ViewModel
        {
            get
            {
                if (viewModel == null)
                    viewModel = new EmployeeListPageViewModel();
                return viewModel;
            }
        }

        public ListViewEmp()
        {
            InitializeComponent();
            BindingContext = ViewModel;

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            ViewModel.EmployeeList = await EmployeeOperations.GetEmployeeAsync();
        }

        private async void MenuItemDelete(object sender, EventArgs e)
        {
            try
            {
                if (await DisplayAlert("Note", "Are you sure to delete?", "Yes", "No"))
                {
                    MenuItem grid = (MenuItem)sender;
                    if (grid != null)
                    {
                        Employee employee = (Employee)grid.BindingContext;
                        if (employee != null)
                        {
                            if (ViewModel.DeleteEmployeeCommand.CanExecute(employee))
                                ViewModel.DeleteEmployeeCommand.Execute(employee);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void MenuItemEdit(object sender, EventArgs e)
        {
            MenuItem grid = (MenuItem)sender;
            if (grid != null)
            {
                Employee employee = (Employee)grid.BindingContext;
                if (employee != null)
                {
                    if (ViewModel.EditEmployeeCommand.CanExecute(employee))
                        ViewModel.EditEmployeeCommand.Execute(employee);
                }
            }
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Employee employee = e.Item as Employee;
            if (employee != null)
            {
                if (ViewModel.ViewEmployeeCommand.CanExecute(employee))
                    ViewModel.ViewEmployeeCommand.Execute(employee);
            }
        }
    }
}