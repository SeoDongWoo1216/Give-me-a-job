using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Windows;

using DogWorker.View.CourseInf;
using DogWorker.View.Record;
using DogWorker.View.Apply;
using DogWorker.View.UserInf;
using DogWorker.View;

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
            if (Commons.LOGINED_USER != null)
                BtnLoginedId.Content = $"{Commons.LOGINED_USER.ID} ({Commons.LOGINED_USER.ID})";
        }
        private void ShowLoginView()
        {
            LoginView view = new LoginView();
            view.Owner = this;
            view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            view.ShowDialog();
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
                ActiveControl.Content = new DWRecordMain();
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
                ActiveControl.Content = new DWApplyMain();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnApply_Click : {ex}");
                this.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }
        
        private void BtnUserInf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActiveControl.Content = new DWInfMain();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnWorkerInf_Click : {ex}");
                this.ShowMessageAsync("예외", $"예외발생 : {ex}");
            }
        }
        
    }
}
