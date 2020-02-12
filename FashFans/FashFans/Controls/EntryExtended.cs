﻿using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.Controls {
    public class EntryExtended : Entry {

        public static readonly BindableProperty LetterSpacingPlaceholderProperty = BindableProperty.Create(
            propertyName: nameof(LetterSpacingPlaceholder),
            returnType: typeof(float),
            declaringType: typeof(EntryExtended),
            defaultValue: (Device.RuntimePlatform == Device.Android) ? .05F : 1f);

        public static readonly BindableProperty LetterSpacingProperty = BindableProperty.Create(
           propertyName: nameof(LetterSpacing),
           returnType: typeof(float),
           declaringType: typeof(EntryExtended),
           defaultValue: (Device.RuntimePlatform == Device.Android) ? .05F : 1f);

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            propertyName: nameof(BorderColor),
            returnType: typeof(Color),
            declaringType: typeof(EntryExtended),
            defaultValue: Color.Transparent);

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
            propertyName: nameof(BorderWidth),
            returnType: typeof(float),
            declaringType: typeof(EntryExtended),
            defaultValue: default(float));

        public static readonly BindableProperty BorderRadiusProperty = BindableProperty.Create(
            propertyName: nameof(BorderRadius),
            returnType: typeof(float),
            declaringType: typeof(EntryExtended),
            defaultValue: default(float));

        public static readonly BindableProperty LeftPaddingProperty = BindableProperty.Create(
            propertyName: nameof(LeftPadding),
            returnType: typeof(int),
            declaringType: typeof(EntryExtended),
            defaultValue: 5);

        public static BindableProperty RightPaddingProperty = BindableProperty.Create(
            propertyName: nameof(RightPadding),
            returnType: typeof(int),
            declaringType: typeof(EntryExtended),
            defaultValue: 5);

        public static readonly BindableProperty CompletedCommandProperty = BindableProperty.Create(
            propertyName: nameof(CompletedCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(EntryExtended),
            defaultValue: default(ICommand));

        public EntryExtended() {
            Completed += OnEntryExtendedCompleted;
        }

        public float LetterSpacingPlaceholder {
            get { return (float)GetValue(LetterSpacingPlaceholderProperty); }
            set { SetValue(LetterSpacingPlaceholderProperty, value); }
        }

        public float LetterSpacing {
            get { return (float)GetValue(LetterSpacingProperty); }
            set { SetValue(LetterSpacingProperty, value); }
        }

        public Color BorderColor {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public float BorderWidth {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public float BorderRadius {
            get { return (float)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        public int LeftPadding {
            get { return (int)GetValue(LeftPaddingProperty); }
            set { SetValue(LeftPaddingProperty, value); }
        }

        public int RightPadding {
            get { return (int)GetValue(RightPaddingProperty); }
            set { SetValue(RightPaddingProperty, value); }
        }

        public ICommand CompletedCommand {
            get => (ICommand)GetValue(CompletedCommandProperty);
            set => SetValue(CompletedCommandProperty, value);
        }

        private void OnEntryExtendedCompleted(object sender, EventArgs e) => CompletedCommand?.Execute(null);
    }
}
