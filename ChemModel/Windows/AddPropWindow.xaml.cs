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
using System.Windows.Shapes;

namespace ChemModel.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPropWindow.xaml
    /// </summary>
    public partial class AddPropWindow : Window
    {
        public AddPropWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.PropertiesTabViewModel();
        }
    }
}
