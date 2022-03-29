using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.Data.Sqlite;

namespace MetaverseNavigator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            window.DataContext = this;
            
        
            MainMenuPage page = new MainMenuPage();
            page.MenuButtonClicked += Page_MenuButtonClicked;
            CurrentPage = page;
        }

        private void Page_MenuButtonClicked(Button sender)
        {
            switch (sender.Tag)
            {
                case "Confidants":
                    CurrentPage = new ConfidantsPage();
                    break;
                case "Compedium":

                    break;
                case "Skills":

                    break;
                default:
                    CurrentPage = new MainMenuPage();
                    break;
            }
        }

        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPage)));

            }
        } private Page _currentPage;



        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
