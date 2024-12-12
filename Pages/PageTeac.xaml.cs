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
    /// Логика взаимодействия для PageTeac.xaml
    /// </summary>
    public partial class PageTeac : Page
    {
        Users objUser;
        public PageTeac(Users userObj)
        {
            InitializeComponent();
            objUser = userObj;
            teachGrid.ItemsSource = DBClass.entObj.Teachers.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageAddEditTeac(objUser, (sender as Button).DataContext as Teachers));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы точно хотите удалить этого учителя?",
                    "Удаление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBClass.entObj.Teachers.Remove((sender as Button).DataContext as Teachers);
                    DBClass.entObj.SaveChanges();
                }
                teachGrid.ItemsSource = DBClass.entObj.Teachers.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Критический сбой в работе приложения. " +
                    ex.Message.ToString(),
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Question);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageAddEditTeac(objUser, null));
        }

        private void exit1Btn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageMain(objUser));
        }
    }
}
