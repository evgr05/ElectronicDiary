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
    /// Логика взаимодействия для PageAddEditTeac.xaml
    /// </summary>
    public partial class PageAddEditTeac : Page
    {
        Users objUser;
        Teachers _currentTeac = new Teachers();
        public PageAddEditTeac(Users userObj, Teachers _selectedTeac)
        {
            InitializeComponent();
            objUser = userObj;
            if (_selectedTeac != null)
            {
                _currentTeac = _selectedTeac;
            }
            DataContext = _currentTeac;
        }

        private void bckBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageTeac(objUser));
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentTeac.Id == 0)
                {
                    DBClass.entObj.Teachers.Add(_currentTeac);

                }
                DBClass.entObj.SaveChanges();
                FrameClass.frmObj.Navigate(new PageTeac(objUser)); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
