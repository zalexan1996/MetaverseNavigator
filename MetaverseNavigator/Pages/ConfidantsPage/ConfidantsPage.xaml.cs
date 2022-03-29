using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using MetaverseNavigator.Data;

namespace MetaverseNavigator
{
    /// <summary>
    /// Interaction logic for ConfidantsPage.xaml
    /// </summary>
    public partial class ConfidantsPage : Page, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = (sender, a)=> { };



        public ConfidantsPage()
        {
            InitializeComponent();
            tbArcana.DataContext = this;
            tbCharacter.DataContext = this;
            lvBenefits.DataContext = this;
            lvResponses.DataContext = this;
            Confidants = new ObservableCollection<Confidant>(SqlHelper.GetConfidants());

            tStack.ItemsSource = Confidants;


            // Set the selected confidant to be the first one.
            SelectedConfidant = Confidants[0];
            lvBenefits.ItemsSource = SelectedBenefits;
            lvResponses.ItemsSource = SelectedResponses;


            imageConfidant.DataContext = SelectedConfidant;
            tbObtaining.DataContext = SelectedConfidant;
        }


        public ObservableCollection<Data.Confidant> Confidants { get; set; }

        public Confidant SelectedConfidant
        {
            get
            {
                return _selectedConfidant;
            }
            set
            {
                _selectedConfidant = value;

                // Notify bindings that the value was changed.
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedConfidant)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCharacter)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedArcana)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedBenefits)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedResponses)));


                lvBenefits.ItemsSource = SelectedBenefits;
                lvResponses.ItemsSource = SelectedResponses;
                imageConfidant.DataContext = SelectedConfidant;
                tbObtaining.DataContext = SelectedConfidant;

            }
        } private Confidant _selectedConfidant;




        /// <summary>
        /// The function that is called when the user opens a Confidant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                SelectedConfidant = button.DataContext as Confidant;
            }
        }




        public string SelectedArcana { get { return SelectedConfidant.Arcana; } }
        public string SelectedCharacter { get { return SelectedConfidant.Character; } }

        public List<ConfidantBenefit> SelectedBenefits { get { return SelectedConfidant.Benefits; } }
        public List<ConfidantRankResponse> SelectedResponses { get { return SelectedConfidant.Responses; } }
    }
}
