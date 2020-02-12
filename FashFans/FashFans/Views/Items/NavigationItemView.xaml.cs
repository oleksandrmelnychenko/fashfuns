using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FashFans.Views.Items {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationItemView : ContentView {

        public static BindableProperty CommandProperty =
            BindableProperty.Create(propertyName: "Command",
                                    returnType: typeof(ICommand),
                                    declaringType: typeof(NavigationItemView),
                                    defaultValue: null,
                                    defaultBindingMode: BindingMode.OneWay);
        public ICommand Command {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static BindableProperty IsSelectedProperty =
           BindableProperty.Create(propertyName: "IsSelected",
                                   returnType: typeof(bool),
                                   declaringType: typeof(NavigationItemView),
                                   defaultValue: default(bool),
                                   defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: SelectChanged);
        public bool IsSelected {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(CommandProperty, value); }
        }

        /// <summary>
        ///     ctor().
        /// </summary>
        public NavigationItemView() {
            InitializeComponent();
        }

        private static void SelectChanged(BindableObject bindable, object oldValue, object newValue) {
            if (bindable is NavigationItemView declarer) {
                declarer.VisibilitySelected();
            }
        }

        private void VisibilitySelected() {
            if (IsSelected) {
                _selectedImage.IsVisible = true;
                _icon_CachedImage.IsVisible = false;
            } else {
                _selectedImage.IsVisible = false;
                _icon_CachedImage.IsVisible = true;
            }
        }
    }
}