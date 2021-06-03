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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kakaoMapApi_SearchApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            List<MyLocale> mls = KakaoAPI.Search(tbox_query.Text);
            lbox_locale.ItemsSource = mls;
        }

        private void lbox_locale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbox_locale.SelectedIndex == -1)
            {
                return;
            }

            MyLocale ml = lbox_locale.SelectedItem as MyLocale;
            object[] ps = new object[] { ml.Lat, ml.Lng };
            wb.InvokeScript("setCenter", ps);
        }
    }
}
