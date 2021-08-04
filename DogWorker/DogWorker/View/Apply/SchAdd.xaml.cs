using DogWorker.Model;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DogWorker.View.Apply
{
    /// <summary>
    /// SchAdd.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SchAdd : MetroWindow


    {
        public SchAdd()
        {
            InitializeComponent();
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isVaild())
            {
                ScheduleTBL schdules = new ScheduleTBL()
                {
                    Uidx = int.Parse(TxtSchName.Text),
                    Schdate = DateTime.Parse(DtpSchDate.SelectedDate.ToString()),
                    Schtime = TmpSchTime.SelectedDateTime.Value.TimeOfDay,
                    Schplace = TxtSchPlace.Text,
                    Rsyn = CmbSchReserve.Text,
                    Rstime = DateTime.Now
                };

                Logic.DataAccess.Setschedules(schdules);
            }

            var result = await this.ShowMessageAsync("추가등록", "추가등록하시겠습니까?", MessageDialogStyle.AffirmativeAndNegative,null);
            if (result == MessageDialogResult.Affirmative)
            {
                DataClear();
            }
            else
            {
                Close();
            }
        }

        
        private void DataClear()
        {
            DtpSchDate.SelectedDate = null;
            TmpSchTime.SelectedDateTime = null;
            TxtSchPlace.Text = null;
            
        }

        private bool isVaild()
        {
            if (DtpSchDate.SelectedDate == null)
            {
                this.ShowMessageAsync("입력", "날짜를 입력하세요");
                return false;
            }
            if (TmpSchTime == null)
            {
                this.ShowMessageAsync("입력", "시간을 입력하세요");
                return false;
            }
            if (string.IsNullOrEmpty(TxtSchPlace.Text))
            {
                this.ShowMessageAsync("입력", "장소를 입력하세요");
                return false;
            }
            

            return true;
            
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
