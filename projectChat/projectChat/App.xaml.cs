﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace projectChat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           //MainPage = new CreateProduct();
            // MainPage = new NavigationPage(new Login());
            MainPage = new NavigationPage(new ManagerProduct1());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
