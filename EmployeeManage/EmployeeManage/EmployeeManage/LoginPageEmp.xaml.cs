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
    public partial class LoginPageEmp : ContentPage
    {
       
        public LoginPageEmp()
        {
            InitializeComponent();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.Compare(txtUsername.Text.ToLower(), "1") > 0)
                await DisplayAlert("Alert", "Invalid Credentials", "OK");
            else if (string.Compare(txtPassword.Text.ToLower(), "111") > 0)
                await DisplayAlert("Alert", "Invalid Password", "OK");
            else
                await Navigation.PushAsync(new FlyoutPageEmp());
        }
    }
}