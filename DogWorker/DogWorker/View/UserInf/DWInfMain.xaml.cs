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
using DogWorker.Model;

namespace DogWorker.View.UserInf
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DWInfMain : Page
    {
        public DWInfMain()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            List<USERTBL> user = Logic.DataAccess.Getusers();
            TxtName.Text = user[0].Name.ToString();
            TxtAge.Text = user[0].Age.ToString();
            TxtPhone.Text = user[0].Phone.ToString();
            TxtID.Text = user[0].ID.ToString();
            TxtPW.Text = user[0].PW.ToString();
            TxtEmail.Text = user[0].Email.ToString();

        }
    }
}
