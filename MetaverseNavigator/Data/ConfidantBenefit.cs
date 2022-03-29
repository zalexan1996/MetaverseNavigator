using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaverseNavigator.Data
{
    /// <summary>
    /// A data object representing the benefits you get at a given rank of a Confidant.
    /// </summary>
    public class ConfidantBenefit : DataObject
    {

        /// <summary>
        /// The Id of this Benefit in the sqlite database.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the Confidant that this Benefit applies to.
        /// </summary>
        public string Confidant { get; set; }

        /// <summary>
        /// The Rank you have to be to earn this Benefit.
        /// </summary>
        public long Rank { get; set; }

        /// <summary>
        /// The name of the ability.
        /// </summary>
        public string Ability { get; set; }

        /// <summary>
        /// The description for the ability.
        /// </summary>
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Benefit({Id}) {Confidant}:{Rank} - {Ability}";
        }
    }
}
