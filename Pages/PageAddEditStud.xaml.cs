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
    /// Логика взаимодействия для PageAddEditStud.xaml
    /// </summary>
    public partial class PageAddEditStud : Page
    {
        Users objUser;
        Students _currentStud = new Students();
        public PageAddEditStud(Students _selectedStud,Users oserObj)
        {
            InitializeComponent();
            objUser = oserObj;
            cmbClass.ItemsSource = DBClass.entObj.Classes.ToList();
            if (_selectedStud != null)
            {
                _currentStud = _selectedStud;
            }
            DataContext = _currentStud;
        }

        private void bckBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageStud(objUser));
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentStud.Id == 0)
                {
                    DBClass.entObj.Students.Add(_currentStud);

                }
                DBClass.entObj.SaveChanges();
                FrameClass.frmObj.Navigate(new PageStud(objUser));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
