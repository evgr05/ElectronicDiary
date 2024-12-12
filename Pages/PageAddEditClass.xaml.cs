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
    /// Логика взаимодействия для PageAddEditClass.xaml
    /// </summary>
    public partial class PageAddEditClass : Page
    {
        Users objUser;
        Classes _currentClass = new Classes();
        public PageAddEditClass(Users userObj, Classes _selectedClass)
        {
            InitializeComponent();
            objUser = userObj;
            if(_selectedClass != null)
            {
                _currentClass = _selectedClass;
            }
            DataContext = _currentClass;
            cmbTeac.ItemsSource = DBClass.entObj.Teachers.ToList();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentClass.Id == 0)
                {
                    DBClass.entObj.Classes.Add(_currentClass);

                }
                DBClass.entObj.SaveChanges();
                FrameClass.frmObj.Navigate(new PageClasses(objUser));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bckBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageClasses(objUser));
        }
    }
}
