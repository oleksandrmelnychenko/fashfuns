﻿using FashFans.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FashFans.Services.Navigation {
    public interface INavigationService {

        bool IsBackButtonAvailable { get; }

        ViewModelBase LastPageViewModel { get; }

        ViewModelBase PreviousPageViewModel { get; }

        IReadOnlyCollection<ViewModelBase> CurrentViewModelsNavigationStack { get; }

        Task InitializeAsync(object parameter = default(object));

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task NavigateToModalAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToModalAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();

        Task RemoveIntermediatePagesAsync();

        Task GoBackAsync();

        void InitAfterResumeApp();

        void UnsubscribeAfterSleepApp();

        Task CloseModalAsync();
    }
}
