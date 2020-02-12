﻿using FashFans.Models.Args.BottomTabSwitcher;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms.Internals;

namespace FashFans.ViewModels.Base
{
    public class ContentPageBaseViewModel : ViewModelBase {

        private readonly Dictionary<Guid, bool> _busySequence = new Dictionary<Guid, bool>();

        private List<IBottomBarTab> _bottomBarItems;
        public List<IBottomBarTab> BottomBarItems {
            get => _bottomBarItems;
            protected set {
                _bottomBarItems?.ForEach(bottomItem => bottomItem.Dispose());
                SetProperty<List<IBottomBarTab>>(ref _bottomBarItems, value);
            }
        }

        ObservableCollection<PopupBaseViewModel> _popups = new ObservableCollection<PopupBaseViewModel>();
        public ObservableCollection<PopupBaseViewModel> Popups {
            get => _popups;
            private set => SetProperty(ref _popups, value);
        }

        ICommand _refreshCommand;
        public ICommand RefreshCommand {
            get => _refreshCommand;
            protected set => SetProperty(ref _refreshCommand, value);
        }

        int _electedBottomItemIndex;
        public int SelectedBottomItemIndex {
            get => _electedBottomItemIndex;
            set {
                try {
                    ///
                    /// TODO: implement Take/Lose intent args (like in PeackMVP).
                    /// P.S. Dispose() clearing everything, including ResourceLoader (language switching is not working after that).
                    ///
                    //BottomBarItems?[_electedBottomItemIndex].Dispose();
                    BottomBarItems?[value].InitializeAsync(new SelectedBottomBarTabArgs());

                    if (BottomBarItems != null && BottomBarItems.Any()) {
                        SomeBottomTabWasSelectedArgs someBottomTabWasSelectedArgs = new SomeBottomTabWasSelectedArgs(BottomBarItems?[value].GetType());
                        BottomBarItems.ForEach(barItem => barItem.InitializeAsync(someBottomTabWasSelectedArgs));
                    }
                }
                catch (Exception exc) {
                    string message = exc.Message;
                    Debugger.Break();
                }

                SetProperty(ref _electedBottomItemIndex, value);
            }
        }

        bool _isPullToRefreshEnabled;
        public bool IsPullToRefreshEnabled {
            get => _isPullToRefreshEnabled;
            protected set => SetProperty(ref _isPullToRefreshEnabled, value);
        }

        bool _isRefreshing;
        public bool IsRefreshing {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        bool _isPopupsVisible;
        public bool IsPopupsVisible {
            get => _isPopupsVisible;
            set => SetProperty<bool>(ref _isPopupsVisible, value);
        }

        ActionBarBaseViewModel _actionBarViewModel;
        public ActionBarBaseViewModel ActionBarViewModel {
            get => _actionBarViewModel;
            protected set {
                _actionBarViewModel?.Dispose();
                SetProperty(ref _actionBarViewModel, value);
            }
        }

        public override void Dispose() {
            base.Dispose();

            ActionBarViewModel?.Dispose();
            Popups?.ForEach<PopupBaseViewModel>(popup => popup.Dispose());
        }

        public override Task InitializeAsync(object navigationData) {

            ActionBarViewModel?.InitializeAsync(navigationData);

            return base.InitializeAsync(navigationData);
        }

        public void SetBusy(Guid guidKey, bool isBusy) {
            if (_busySequence.ContainsKey(guidKey)) {
                _busySequence[guidKey] = isBusy;
            } else {
                _busySequence.Add(guidKey, isBusy);
            }

            _busySequence.Where(kVP => !kVP.Value).Select(kVP => kVP.Key).ToArray().ForEach(g => _busySequence.Remove(g));

            IsBusy = _busySequence.Any();
        }
    }
}
