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
    /// Логика взаимодействия для PageAddEditScore.xaml
    /// </summary>
    public partial class PageAddEditScore : Page
    {
        Scores _currentScore = new Scores();
        Users objUser;
        public PageAddEditScore(Scores _selectedScore, Users userObj)
        {
            InitializeComponent();
            objUser = userObj;
            if(_selectedScore != null )
            {
                _currentScore = _selectedScore;
            }
            cmbPredm.ItemsSource = DBClass.entObj.Disciplines.ToList();
            cmbStud.ItemsSource = DBClass.entObj.Students.ToList();
            cmbTeac.ItemsSource = DBClass.entObj.Teachers.ToList();
            DataContext = _currentScore;
            
            
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_currentScore.Id == 0)
                {
                    DBClass.entObj.Scores.Add(_currentScore);
                    
                }
                DBClass.entObj.SaveChanges();
                FrameClass.frmObj.Navigate(new PageScores(objUser));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bckBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageScores(objUser));
        }
    }
}
