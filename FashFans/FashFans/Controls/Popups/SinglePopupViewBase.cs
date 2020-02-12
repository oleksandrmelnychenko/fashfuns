﻿using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.Controls.Popups {
    public abstract class SinglePopupViewBase : ContentView {

        public static readonly BindableProperty IsViewableProperty = BindableProperty.Create(
            nameof(IsViewable),
            typeof(bool),
            typeof(SinglePopupViewBase),
            defaultValue: default(bool),
            propertyChanged: (BindableObject bindable, object oldValue, object newValue) => (bindable as SinglePopupViewBase)?.OnIsViewable());

        public static readonly BindableProperty CloseCommandProperty = BindableProperty.Create(
            nameof(CloseCommand),
            typeof(ICommand),
            typeof(SinglePopupViewBase),
            defaultValue: null);

        public event EventHandler Viewable = delegate { };

        public bool IsViewable {
            get => (bool)GetValue(SinglePopupViewBase.IsViewableProperty);
            set => SetValue(SinglePopupViewBase.IsViewableProperty, value);
        }

        public ICommand CloseCommand {
            get => (ICommand)GetValue(CloseCommandProperty);
            set => SetValue(CloseCommandProperty, value);
        }

        private void OnIsViewable() {
            Viewable.Invoke(this, new EventArgs());
        }
    }
}
