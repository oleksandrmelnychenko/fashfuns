﻿using Xamarin.Forms;

namespace FashFans.Controls.ActionBars {
    public class ActionBarBaseView : ContentView {

        private static readonly string BINDING_CONTEXT_SOURCE_PATH = "ActionBarViewModel";

        public ActionBarBaseView() {
            SetBinding(BindingContextProperty, new Binding(BINDING_CONTEXT_SOURCE_PATH));
        }
    }
}
