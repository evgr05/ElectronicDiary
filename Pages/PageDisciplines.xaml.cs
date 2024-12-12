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
    /// Логика взаимодействия для PageDisciplines.xaml
    /// </summary>
    public partial class PageDisciplines : Page
    {
        Users objUser;
        public PageDisciplines(Users userObj)
        {
            InitializeComponent();
            objUser = userObj;
            disGrid.ItemsSource = DBClass.entObj.Disciplines.ToList();
        }

        private void exit1Btn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageMain(objUser));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageAddEditDis(objUser, (sender as Button).DataContext as Disciplines));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы точно хотите удалить этот предмет?",
                    "Удаление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBClass.entObj.Disciplines.Remove((sender as Button).DataContext as Disciplines);
                    DBClass.entObj.SaveChanges();
                }
                disGrid.ItemsSource = DBClass.entObj.Disciplines.ToList();
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
            FrameClass.frmObj.Navigate(new PageAddEditDis(objUser, null));
        }
    }
}
