using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Windows;

using DogWorker.View.DogInf;
using DogWorker.View.DogWorkerInf;
using DogWorker.View.CourseInf;
using DogWorker.View.Record;
using DogWorker.View.Apply;

namespace DogWorker
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_ContentRendered(object sender, EventArgs e)
        {
            ShowLoginView();
        }

        private void MetroWindow_Activated(object sender, EventArgs e)
        {
            //if (Commons.LOGINED_USER != null)
            //    BtnLoginedId.Content = $"{Commons.LOGINED_USER.UserEmail} ({Commons.LOGINED_USER.UserName})";
        }
        private void ShowLoginView()
        {

        }

        private async void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    ActiveControl.Content = new MyAccount();
            //}
            //catch (Exception ex)
            //{
            //    Commons.LOGGER.Error($"예외발생 BtnAccount_Click : {ex}");
            //    await this.ShowMessageAsync("예외", $"예외발생 : {ex}");
            //}
        }

        private async void BtnUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //ActiveControl.Content = new UserList();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnUser_Click : {ex}");
                await this.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }

        private void BtnStore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // ActiveControl.Content = new StoreList();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnStore_Click : {ex}");
                this.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }

        private async void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            var result = await this.ShowMessageAsync("종료", "프로그램을 종료하시겠습니까?",
                MessageDialogStyle.AffirmativeAndNegative, null);
            if (result == MessageDialogResult.Affirmative)
            {
                Application.Current.Shutdown();
            }

        }

        private void BtnSetting_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    ActiveControl.Content = new SettingList();
            //}
            //catch (Exception ex)
            //{
            //    Commons.LOGGER.Error($"예외발생 BtnSetting_Click : {ex}");
            //    this.ShowMessageAsync("예외", $"예외발생 : {ex}");
            //}
        }

        private void BtnDogInf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActiveControl.Content = new DogInfMain();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnDogInf_Click : {ex}");
                this.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }

        private void BtnWorkerInf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActiveControl.Content = new DWIMain();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnWorkerInf_Click : {ex}");
                this.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }

        private void BtnCourseInf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActiveControl.Content = new CourseInfMain();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnCourseInf_Click : {ex}");
                this.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }

        private void Btnrecord_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActiveControl.Content = new RecordMain();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 Btnrecord_Click : {ex}");
                this.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActiveControl.Content = new CSApplyMain();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnApply_Click : {ex}");
                this.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }
    }
}
