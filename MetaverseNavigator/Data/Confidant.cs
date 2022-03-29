using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaverseNavigator.Data
{
    /// <summary>
    /// A data object representing a confidant.
    /// </summary>
    public class Confidant : DataObject, INotifyPropertyChanged
    {
        /// <summary>
        /// Inherited event for INotifyPropertyChanged.
        /// Fired any time a property is changed. Go figure.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, a) => { };





        /// <summary>
        /// The Id of this confidant in the sqlite database.
        /// </summary>
        public long Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        } private long _id;

        /// <summary>
        /// The Arcana of this Confidant. Used heavily in linq.
        /// </summary>
        public string Arcana
        {
            get
            {
                return _arcana;
            }
            set
            {

                _arcana = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Arcana)));

                Benefits = SqlHelper.GetConfidantBenefits(_arcana);
                Responses = SqlHelper.GetConfidantRankResponses(_arcana);

            }
        }
        private string _arcana;


        /// <summary>
        /// The Arcana of this Confidant. Used heavily in linq.
        /// </summary>
        public string Obtaining
        {
            get
            {
                return _obtaining;
            }
            set
            {
                _obtaining = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Obtaining)));
            }
        }
        private string _obtaining;

        /// <summary>
        /// The path to an icon for this Confidant / Arcana.
        /// </summary>
        public string IconPath
        {
            get
            {
                return "/Resources/Icons/" + _iconPath;
            }
            set
            {
                _iconPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IconPath)));
            }
        }
        private string _iconPath;

        /// <summary>
        /// The name of the Character for this Confidant.
        /// </summary>
        public string Character
        {
            get
            {
                return _character;
            }
            set
            {
                _character = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Character)));
            }
        }
        private string _character;


        public override string ToString()
        {
            return $"Confidant({Id}): {Arcana} {Character}";
        }

        /// <summary>
        /// A list of abilities that you get at the different ranks of the Confidant.
        /// </summary>
        public List<ConfidantBenefit> Benefits
        {
            get
            {
                return _benefits;
            }
            set
            {
                _benefits = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Benefits)));
            }
        } private List<ConfidantBenefit> _benefits;


        public List<ConfidantRankResponse> Responses
        {
            get
            {
                return _responses;
            }
            set
            {
                _responses = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Responses)));
            }
        } private List<ConfidantRankResponse> _responses;
    }
}
