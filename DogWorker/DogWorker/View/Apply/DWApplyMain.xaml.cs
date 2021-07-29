using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace DogWorker.View.Apply
{
    
    public partial class DWApplyMain : Page
    {
        public DWApplyMain()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                LoadData();

                InitErrorMessages();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 StoreList Loaded : {ex}");
                throw ex;
            }
        }
        private void InitErrorMessages()
        {
           // LblBasicCode.Visibility = LblCodeDesc.Visibility = LblCodeName.Visibility = Visibility.Hidden;

        }
        private void LoadData()
        {
            List<Model.ScheduleTBL> schedules = Logic.DataAccess.Getschedules();
            this.DataContext = schedules;

            CmbSchYN.Items.Add("Y");
            CmbSchYN.Items.Add("N");
        }
        
        private void BtnReserve_Click(object sender, RoutedEventArgs e)
        {
            SchAdd view = new SchAdd();
            view.ShowDialog();
            
            //LoadData(); 20210730일날 하기
        }

        private void GrdData_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                var select = GrdData.SelectedItem as Model.ScheduleTBL;
                var user = Logic.DataAccess.Getusers().Where(s => s.Uidx.Equals(select.Uidx)).FirstOrDefault();
               // var user = GrdData.SelectedItem as Model.USERTBL;
                TxtSchName.Text = user.Name.ToString();
                TxtSchAge.Text = user.Age.ToString();
                DtpSchDate.Text = select.Schdate.ToString();
                CmbSchYN.Text = select.Rsyn.ToString();

                if (select.Schtime!=null)
                {
                    TmpSchTime.SelectedDateTime = new DateTime(select.Schtime.Ticks);
                }
                TxtSchPlace.Text = select.Schplace.ToString();
                //TxtSchBreed.Text = breed.Breed.ToString();
                //TxtSchFeature.Text = breed.Memo.ToString();
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외 발생 : {ex}");
                //ClearInputs();
            }
        }
    }
}
