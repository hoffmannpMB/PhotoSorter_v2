﻿using System;
using System.Windows.Input;
using Models;
using MVVM_Base;

namespace ViewModels.MockViewModels
{
    public class MockPhotoViewModel : IPhotoViewModel
    {
        public ICommand BackCommand { get; }
        public ICommand EditCommand { get; }
        public TimeSpan TimeTaken { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string TmpImagePath { get; set; }
        public float Rotation { get; set; }
        public ICameraModel CameraModel { get; set; }
        public DateTimeOffset DateTaken { get; set; }
        public string Description { get; set; }
        public IRedundantPhotoModel SelectedRedundantPhoto { get; set; }
        public IObservableCollection<IRedundantPhotoModel> RedundantPhotos { get; }
    }
}