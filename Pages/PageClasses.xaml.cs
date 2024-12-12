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
    /// Логика взаимодействия для PageClasses.xaml
    /// </summary>
    public partial class PageClasses : Page
    {
        Users objUser;
        public PageClasses(Users userObj)
        {
            InitializeComponent();
            objUser = userObj;
            classGrid.ItemsSource = DBClass.entObj.Classes.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageAddEditClass(objUser, null));
        }

        private void exit1Btn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageMain(objUser));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы точно хотите удалить этот класс?",
                    "Удаление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBClass.entObj.Classes.Remove((sender as Button).DataContext as Classes);
                    DBClass.entObj.SaveChanges();
                }
                classGrid.ItemsSource = DBClass.entObj.Classes.ToList();
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
            FrameClass.frmObj.Navigate(new PageAddEditClass(objUser, (sender as Button).DataContext as Classes));
        }
    }
}
