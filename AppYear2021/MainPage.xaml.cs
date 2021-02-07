using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace AppYear2021
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer _timer1 = new DispatcherTimer();
        int _iDaysLeft = 0;

        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.GetForCurrentView().TryEnterFullScreenMode();

            calcDaysLeft();
            _timer1.Interval = TimeSpan.FromSeconds(1);
            _timer1.Tick += _timer1_Tick;
            _timer1.Start();

            Application.Current.LeavingBackground += Current_LeavingBackground;
        }

        private void _timer1_Tick(object sender, object e)
        {
            calcDaysLeft();
        }

        /// <summary>
        /// 计算离开2021年春节还有多少天
        /// </summary>
        private void calcDaysLeft()
        {
            int iDaysRemain = 0;

            TimeSpan ts1 = new DateTime(2021, 2, 12) - DateTime.Now;
            if (ts1.TotalDays > 0)
            {
                iDaysRemain = (int)Math.Ceiling(ts1.TotalDays);
            }

            if (iDaysRemain != _iDaysLeft)
            {
                _iDaysLeft = iDaysRemain;
                tbDaysLeft.Text = $"{_iDaysLeft}";
            }
        }

        private void Current_LeavingBackground(object sender, Windows.ApplicationModel.LeavingBackgroundEventArgs e)
        {
            aniScal.Begin();

            // 光照效果
            aniPanel(panel1);
        }

        private void aniPanel(StackPanel o1)
        {
            var t1 = ElementCompositionPreview.GetElementVisual(o1);
            Compositor c1 = t1.Compositor;

            PointLight light1 = c1.CreatePointLight();
            light1.Color = Colors.White;
            light1.CoordinateSpace = t1;
            light1.Intensity = 5.6f;
            light1.Targets.Add(t1);

            light1.Offset = new Vector3(-(float)o1.ActualWidth, (float)o1.ActualHeight, (float)200);

            var ani = c1.CreateScalarKeyFrameAnimation();
            ani.InsertKeyFrame(1, 2 * (float)o1.ActualWidth);
            ani.Duration = TimeSpan.FromSeconds(2.0f);
            ani.IterationBehavior = AnimationIterationBehavior.Forever;

            light1.StartAnimation("Offset.X", ani);
        }
    }
}
