using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace MetaverseNavigator
{
    /// <summary>
    /// A special type of text block that generates Persona text. Very fancy.
    /// </summary>
    public class PersonaTextBlock : TextBlock
    {
        #region Callback Functions
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PersonaTextBlock block = (PersonaTextBlock)d;
            block.ReloadText();
        }
        #endregion



        #region Contructors
        /// <summary>
        /// Step 2 - Define the Dependency Property in the static contructor.
        /// Static Constructor for defining DependencyProperties. This is because DependencyProperties do not have
        /// a public constructor. They must be created from the DependencyProperty.Register static method.
        /// </summary>
        static PersonaTextBlock()
        {

            if (PersonaTextProperty == null)
            {
                // The metadata tells WPF that the default value should be empty string.
                //  The AffectsRender flag tells WPF that the TextBlock will need to be re-rendered if this
                //   dependency property changes.
                FrameworkPropertyMetadata meta = new FrameworkPropertyMetadata(
                    "",
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    new PropertyChangedCallback(OnTextChanged));

                // Register the Dependency Property. This creates it.
                PersonaTextProperty = DependencyProperty.Register("PersonaText", typeof(string), typeof(FrameworkElement), meta);
            }
            
        }

        
        #endregion


        #region Methods
        protected void ReloadText()
        {
            Inlines.Clear();
           
            foreach (char c in PersonaText.ToCharArray())
            {
                Run run = new Run(c.ToString().ToUpper());

                // Set vowels to be lowercase.
                if (UseLowercaseVowels && Vowels.Contains(c.ToString().ToLower()[0]))
                {
                    run.Text = c.ToString().ToLower();
                }
                



                // Set a random font size.
                run.FontSize = ranGen.Next((int)FontSize - FontSizeDeviation, (int)FontSize + FontSizeDeviation);

                // Set a random Font Family
                run.FontFamily = FontFamilies[ranGen.Next(0, FontFamilies.Count)];


                // Random boldness.
                if (ranGen.NextDouble() <= BoldProbability)
                {
                    run.FontWeight = FontWeights.Bold;
                }
                

                // Invert the colors occasionally.
                if (ranGen.NextDouble() <= InvertedProbability)
                {
                    run.Foreground = Brushes.Black;
                    run.Background = Brushes.White;
                    run.FontWeight = FontWeights.Black;
                }
                else
                {
                    run.Foreground = Brushes.White;
                    // run.Background = Brushes.Black;
                }
                

                Inlines.Add(run);
            }
        }
        #endregion

        #region DependencyProperties
        /// <summary>
        /// Step 1 - Declare the Dependency Property
        /// Hide the Text DependencyProperty that was inherited from TextBlock.
        /// We do this so that we have control over how the Property's value is handled.
        /// </summary>
        public static readonly DependencyProperty PersonaTextProperty;
        #endregion



        #region Properties
        /// <summary>
        /// The C# property for the dependency property.
        /// This hides the existing Text property.
        /// </summary>
        public string PersonaText
        {
            get
            {
                return (string)GetValue(PersonaTextProperty);
            }
            set
            {
                SetValue(PersonaTextProperty, value);
            }
        }


        public bool UseLowercaseVowels { get; set; }
        #endregion



        #region Member Variables
        /// <summary>
        /// The probability that the Run will be black with white background.
        /// </summary>
        protected float InvertedProbability = 0.1f;

        /// <summary>
        /// The probability that the Run will be bold.
        /// </summary>
        protected float BoldProbability = 0.05f;

        /// <summary>
        /// The probability that the Run will be bold.
        /// </summary>
        protected float ItalicsProbability = 0.05f;

        /// <summary>
        /// How far the font size will randomly deviate from the Average.
        /// </summary>
        protected int FontSizeDeviation = 2;

        /// <summary>
        /// A collection of allowed. font families.
        /// </summary>
        protected List<FontFamily> FontFamilies = new List<FontFamily> {
            new FontFamily("Times New Roman"),
            new FontFamily("Franklin Gothic"),
            new FontFamily("Cooper Black"),
            new FontFamily("Segoe UI Semibold"),
            new FontFamily("Malgun Gothic"),
            new FontFamily("Franklin Gothic Book")
        };

        /// <summary>
        /// A random number generator to make the font randomly fancy.
        /// </summary>
        protected Random ranGen
        {
            get
            {
                return (Application.Current as App).RandGen;
            }
        }


        protected List<char> Vowels = new List<char>
        {
            'a', 'e', 'i', 'o', 'u', 'y'
        };


        #endregion



    }
}
