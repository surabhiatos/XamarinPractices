using First_App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace First_App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}