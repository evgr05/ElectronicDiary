using ElectronicDiary.DataFiles;
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

namespace ElectronicDiary.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        Users objUser;
        public PageMain(Users userObj)
        {
            InitializeComponent();
            objUser = userObj;
        }

        private void btnScores_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageScores(objUser));
        }

        private void btnStud_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageStud(objUser));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageLogin());
        }

        private void btnDis_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageDisciplines(objUser));
        }

        private void btnTeac_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageTeac(objUser));
        }

        private void btnClasses_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageClasses(objUser));
        }
    }
}
