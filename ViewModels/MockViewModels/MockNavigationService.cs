﻿using System;
using MVVM_Base;

namespace ViewModels.MockViewModels
{
    public class MockNavigationService : INavigationService
    {
        public void NavigateTo(string viewType)
        {
        }

        public void NavigateTo<TViewModel>(string pageKey, TViewModel viewModel) where TViewModel : ViewModelBase
        {
            
        }

        public void NavigateBack()
        {
        }

        public void Register(string key, Type page)
        {
        }
    }
}