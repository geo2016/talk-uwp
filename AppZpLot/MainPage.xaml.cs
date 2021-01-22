using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace AppZpLot
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // 标记当前是否正在抽奖中
        private bool _isLotting = false;

        public MainPage()
        {
            this.InitializeComponent();

            //全屏显示
            ApplicationView view = ApplicationView.GetForCurrentView();
            view.TryEnterFullScreenMode();
        }

        private void AppExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void zpLot(object sender, TappedRoutedEventArgs e)
        {
            if (_isLotting)
            {
                // 停止
                rotate1.Pause();

                media1.Stop();
            }
            else
            {
                // 开始
                media1.Play();

                if(rotate1.GetCurrentState() == ClockState.Stopped)
                {
                    rotate1.Begin();
                }
                else
                {
                    rotate1.Resume();
                }
            }

            _isLotting = !_isLotting;
        }

        private void media1_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (_isLotting)
            {
                media1.Play();
            }
        }
    }
}
