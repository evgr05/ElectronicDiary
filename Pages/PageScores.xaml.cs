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
    /// Логика взаимодействия для PageScores.xaml
    /// </summary>
    public partial class PageScores : Page
    {
        Users objUser;
        public PageScores(Users userObj)
        {
            InitializeComponent();
            ScoresGrid.ItemsSource = DBClass.entObj.Scores.ToList();
            objUser = userObj;
        }

        private void exit1Btn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageMain(objUser));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageAddEditScore((sender as Button).DataContext as Scores, objUser));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы точно хотите удалить эту оценку?",
                    "Удаление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBClass.entObj.Scores.Remove((sender as Button).DataContext as Scores);
                    DBClass.entObj.SaveChanges();
                }
                ScoresGrid.ItemsSource = DBClass.entObj.Scores.ToList();
            }
            catch(Exception ex)
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
            FrameClass.frmObj.Navigate(new PageAddEditScore(null, objUser));
        }
    }
}
