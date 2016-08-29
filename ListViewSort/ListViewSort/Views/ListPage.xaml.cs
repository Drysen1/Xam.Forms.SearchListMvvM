using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListViewSort.ViewModels;
using Xamarin.Forms;
using System.Windows.Input;

namespace ListViewSort.Views
{
    public partial class ListPage : ContentPage
    {
        //To be able to implement MVVM this is the OnTextChangedCommand that binds via event further down.
        public const string OnTextChangedCommandPropertyName = "OnTextChangedCommand";
        public static BindableProperty OnTextChangedProperty = BindableProperty.Create(
            propertyName: "OnTextChangedCommand",
            returnType: typeof(ICommand),
            declaringType: typeof(ListPage),
            defaultValue: null);

        //To be able to implement MVVM this is the OnTextChangedCommand that binds via event further down.
        public ICommand OnTextChangedCommand
        {
            get { return (ICommand)GetValue(OnTextChangedProperty); }
            set { SetValue(OnTextChangedProperty, value); }
        }

        //Constructor
        public ListPage()
        {
            InitializeComponent();
            BindingContext = new ListPageViewModel();
        }

        //Override
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            RemoveBinding(OnTextChangedProperty);
            SetBinding(OnTextChangedProperty, new Binding(OnTextChangedCommandPropertyName));
        }

        //TextChanged event binds command and executes it so we can use it in the viewmodel.
        private void SearchBarOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var command = OnTextChangedCommand;
            if (command != null)
            {
                command.Execute(e.NewTextValue);
            }

        }
    }
}
