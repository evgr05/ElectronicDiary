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
    /// Логика взаимодействия для PageStud.xaml
    /// </summary>
    public partial class PageStud : Page
    {
        Users objUser;
        public PageStud(Users userObj)
        {
            InitializeComponent();
            objUser = userObj;
            studGrid.ItemsSource = DBClass.entObj.Students.ToList();
        }

        private void exit1Btn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageMain(objUser));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы точно хотите удалить этого ученика?",
                    "Удаление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBClass.entObj.Students.Remove((sender as Button).DataContext as Students);
                    DBClass.entObj.SaveChanges();
                }
                studGrid.ItemsSource = DBClass.entObj.Students.ToList();
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

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageAddEditStud((sender as Button).DataContext as Students, objUser));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageAddEditStud(null, objUser));
        }
    }
}
