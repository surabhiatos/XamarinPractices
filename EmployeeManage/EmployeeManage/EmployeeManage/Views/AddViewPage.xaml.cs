using EmployeeManage;
using EmployeeManage.OfflineStorage;
using Student_Management_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeManage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddViewPage : ContentPage
    {
        public AddViewPage(Models.Employee employee, bool isReadOnly = true)
        {
            InitializeComponent();
            IsEnabled = isReadOnly;
            BindingContext = new AddUpdatePageViewModel(employee, isReadOnly);
        }
    }
}