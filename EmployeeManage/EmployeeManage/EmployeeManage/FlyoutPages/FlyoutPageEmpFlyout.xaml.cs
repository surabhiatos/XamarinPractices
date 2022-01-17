using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeManage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPageEmpFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutPageEmpFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutPageEmpFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class FlyoutPageEmpFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutPageEmpFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutPageEmpFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutPageEmpFlyoutMenuItem>(new[]
                {
                    new FlyoutPageEmpFlyoutMenuItem { Id = 0, Title = "Employee Profile", TargetType = typeof(ListViewEmp) },
                   /* new FlyoutPageEmpFlyoutMenuItem { Id = 1, Title = "Employee Profile", TargetType = typeof(ListViewEmp) },
                    new FlyoutPageEmpFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new FlyoutPageEmpFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new FlyoutPageEmpFlyoutMenuItem { Id = 4, Title = "Page 5" },*/
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}