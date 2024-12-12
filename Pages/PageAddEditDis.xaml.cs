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
    /// Логика взаимодействия для PageAddEditDis.xaml
    /// </summary>
    public partial class PageAddEditDis : Page
    {
        Users objUser;
        Disciplines _currentDis = new Disciplines();
        public PageAddEditDis(Users userObj, Disciplines _selectedDis)
        {
            InitializeComponent();
            objUser = userObj;
            if (_selectedDis != null)
            {
                _currentDis = _selectedDis;
            }
            DataContext = _currentDis;
            cmbTeac.ItemsSource = DBClass.entObj.Teachers.ToList();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentDis.Id == 0)
                {
                    DBClass.entObj.Disciplines.Add(_currentDis);

                }
                DBClass.entObj.SaveChanges();
                FrameClass.frmObj.Navigate(new PageDisciplines(objUser));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bckBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageDisciplines(objUser));
        }
    }
}
