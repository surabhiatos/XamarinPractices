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
    public partial class FlyoutPageEmpDetail : ContentPage
    {

        public FlyoutPageEmpDetail()
        {
            InitializeComponent();
        }

        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {

        }
      /*  WebView webView = new WebView
        {
            Source = new UrlWebViewSource
            {
                Url = "https://atos.net/en/"
            },
            VerticalOptions = LayoutOptions.FillAndExpand
        };*/

        // Build the page.
        

        
    }
}