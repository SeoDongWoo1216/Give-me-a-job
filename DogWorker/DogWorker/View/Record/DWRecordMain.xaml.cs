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

namespace DogWorker.View.Record
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DWRecordMain : Page
    {
        public DWRecordMain()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
                // Store 테이블 데이터 읽어와야 함
                //List<Model.Store> stores = new List<Model.Store>();
                //List<Model.StockStore> stockStores = new List<Model.StockStore>();
                //stores = Logic.DataAccess.GetStores(); // 수영1 ...

                //// TODO : stores 데이터를 stockStores로 복사
                //foreach (Model.Store item in stores)
                //{
                //    var store = new Model.StockStore()
                //    {
                //        StoreID = item.StoreID,
                //        StoreName = item.StoreName,
                //        StoreLocation = item.StoreLocation,
                //        ItemStatus = item.ItemStatus,
                //        TagID = item.TagID,
                //        BarcodeID = item.BarcodeID,
                //        StockQuantity = 0
                //    };
                //    // 
                //    store.StockQuantity = Logic.DataAccess.GetStocks().Where(t => t.StoreID.Equals(store.StoreID)).Count();

                //    stockStores.Add(store);
                //}

                //this.DataContext = stockStores;
           // }
            //catch (Exception ex)
            //{
            //    Commons.LOGGER.Error($"예외발생 StoreList Loaded : {ex}");
            //    throw ex;
            //}
        }

        //private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        //{
        //    //try
        //    //{
        //    //    //NavigationService.Navigate(new EditUser());
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Commons.LOGGER.Error($"예외발생 BtnEditUser_Click : {ex}");
        //    //    throw ex;
        //    //}
        //}

        //private void BtnAddStore_Click(object sender, RoutedEventArgs e)
        //{
        //    //try
        //    //{
        //    //    NavigationService.Navigate(new AddStore());
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Commons.LOGGER.Error($"예외발생 BtnAddStore_Click : {ex}");
        //    //    throw ex;
        //    //}
        //}

        //private void BtnEditStore_Click(object sender, RoutedEventArgs e)
        //{
        //    //if (GrdData.SelectedItem == null)
        //    //{
        //    //    Commons.ShowMessageAsync("창고수정", "수정할 창고를 선택하세요");
        //    //    return;
        //    //}

        //    //try
        //    //{
        //    //    //var storeId = (GrdData.SelectedItem as Model.Store).StoreID;
        //    //    //NavigationService.Navigate(new EditStore(storeId));
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Commons.LOGGER.Error($"예외발생 BtnEditStore_Click : {ex}");
        //    //    throw ex;
        //    //}
        //}

        private void BtnAddDog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditInf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeleteInf_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
