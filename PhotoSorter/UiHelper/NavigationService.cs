﻿using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MVVM_Base;
using MVVM_Base.Properties;
using PhotoSorter.Pages;

namespace PhotoSorter.UiHelper
{
    public class NavigationService : INavigationService
    {
        private readonly IDictionary<string, Type> _pageDictionary;

        public NavigationService()
        {
            _pageDictionary = new Dictionary<string, Type>();
            Register(nameof(MainPage), typeof(MainPage));
            Register(nameof(SettingsPage), typeof(SettingsPage));
            Register(nameof(EditPage), typeof(EditPage));
        }

        public void NavigateTo(string pageKey)
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame?.Navigate(_pageDictionary[pageKey]);
        }

        public void NavigateTo<TViewModel>(string pageKey, [NotNull] TViewModel viewModel) where TViewModel : ViewModelBase
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.DataContext = viewModel;
            rootFrame?.Navigate(_pageDictionary[pageKey]);
        }

        public void NavigateBack()
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame?.GoBack();
        }

        public void Register(string key, Type page)
        {
            _pageDictionary.Add(key, page);
        }
    }
}