﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace AppWindowObj
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Debug.WriteLine("MainPage Created");

            Application.Current.EnteredBackground += Current_EnteredBackground;
            Application.Current.Resuming += Current_Resuming;
            Application.Current.Suspending += Current_Suspending;
        }

        private void Current_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            Debug.WriteLine("Current_Suspending");
        }

        private void Current_Resuming(object sender, object e)
        {
            Debug.WriteLine("Current_Resuming");
        }

        private void Current_EnteredBackground(object sender, Windows.ApplicationModel.EnteredBackgroundEventArgs e)
        {
            Debug.WriteLine("Current_EnteredBackground");
        }

        private void GoPage1(object sender, RoutedEventArgs e)
        {
            this.shellFrame1.Navigate(typeof(Page1));
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            if (this.shellFrame1.CanGoBack)
            {
                this.shellFrame1.GoBack();
            }
        }

        private void GoPage2(object sender, RoutedEventArgs e)
        {
            this.shellFrame1.Navigate(typeof(Page2));
        }
    }
}
