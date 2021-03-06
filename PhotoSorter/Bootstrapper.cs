﻿using System.Reflection;
using Autofac;
using BusinessLogic;
using Models.Helper;
using MVVM_Base.Messenger;
using PhotoSorter.UiHelper;
using Repository;
using ViewModels;
using ViewModels.Helper;

namespace PhotoSorter
{
    public class Bootstrapper
    {
        private static Bootstrapper _instance;
        private static readonly object IsLocked = new object();

        private Bootstrapper()
        {
            Container = Build();
        }

        private static IContainer Build()
        {
            var builder = new ContainerBuilder();

            BuildHelper(builder);
            BuildRepositories(builder);
            BuildServices(builder);
            BuildViewModels(builder);

            return builder.Build();
        }

        private static void BuildHelper(ContainerBuilder builder)
        {
            builder.RegisterType<ModelFactory>().AsImplementedInterfaces();
            builder.RegisterType<ViewModelFactory>().AsImplementedInterfaces();
            builder.RegisterType<NavigationService>().AsImplementedInterfaces();
            builder.RegisterType<Messenger>().AsImplementedInterfaces().SingleInstance();
        }

        private static void BuildRepositories(ContainerBuilder builder)
        {
            // register all Repositories as its implemented interfaces, except the MockViewModel.
            builder.RegisterAssemblyTypes(typeof(IAppSettingsRepository).GetTypeInfo().Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().SingleInstance();
        }

        private static void BuildServices(ContainerBuilder builder)
        {
            // register all Services as its implemented interfaces, except the MockViewModel.
            builder.RegisterAssemblyTypes(typeof(IAppSettingsService).GetTypeInfo().Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().SingleInstance();
        }

        private static void BuildViewModels(ContainerBuilder builder)
        {
            // register all ViewModels as its implemented interfaces, except the MockViewModel.
            builder.RegisterAssemblyTypes(typeof(IMainPageViewModel).GetTypeInfo().Assembly).Where(t => t.Name.EndsWith("ViewModel") && !t.Name.StartsWith("Mock")).AsImplementedInterfaces();
        }

        public IContainer Container { get; }

        public static Bootstrapper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (IsLocked)
                    {
                        if (_instance == null)
                        {
                            _instance = new Bootstrapper();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}