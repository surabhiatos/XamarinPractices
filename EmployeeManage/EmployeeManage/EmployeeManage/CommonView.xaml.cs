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
    public partial class CommonView : ContentView
    {
        public CommonView()
        {
            InitializeComponent();
            BindingContext = this;
        }
        public string TitleTextMain { 
            get => (string)GetValue(TitleTextProperty);
            set => SetValue(TitleTextProperty, value);
                }

        private static BindableProperty TitleTextProperty = BindableProperty.Create(
                                                         propertyName: nameof(TitleTextMain),
                                                         returnType: typeof(string),
                                                         declaringType: typeof(CommonView),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: TitleTextPropertyChanged);

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CommonView control = (CommonView)bindable;
            control.TitleTextMain = newValue.ToString();
        }
        public Color TitleColor
        {
            get => (Color)GetValue(TitleColorProperty);
            set => SetValue(TitleColorProperty, value);
        }

        private static BindableProperty TitleColorProperty = BindableProperty.Create(
                                                         propertyName: nameof(TitleTextMain),
                                                         returnType: typeof(Color),
                                                         declaringType: typeof(CommonView),
                                                         defaultValue: Color.White,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: TitleColorPropertyChanged);

        private static void TitleColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CommonView control = (CommonView)bindable;
            control.TitleColor = (Color)newValue;
        }
    }
}