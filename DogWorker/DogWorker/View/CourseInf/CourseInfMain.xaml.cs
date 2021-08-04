using DogWorker.Helper;
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
using System.Windows.Media.Imaging;

namespace DogWorker.View.CourseInf
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CourseInfMain : Page
    {
        public CourseInfMain()
        {
            InitializeComponent();
        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Model.USERTBL> user = Logic.DataAccess.Getusers();
            this.DataContext = user;
            wb.Address = "http://127.0.0.1:8080"; //여기서 리프레쉬를 해주면 될듯            
            //다시 커밋용
        }


        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            wb.Address = "http://127.0.0.1:8080"; //여기서 리프레쉬를 해주면 될듯            

        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
           
        }
    }
}
