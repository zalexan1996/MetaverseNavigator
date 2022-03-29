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

namespace MetaverseNavigator
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {

        public delegate void MenuButtonClickedHandler(Button sender);


        public event MenuButtonClickedHandler MenuButtonClicked;


        public MainMenuPage()
        {
            InitializeComponent();

        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MenuButtonClicked(sender as Button);
        }
    }
}
