using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaverseNavigator.Data
{
    /// <summary>
    /// A data object represent a dialogue response for leveling up a rank.
    /// </summary>
    public class ConfidantRankResponse : DataObject
    {
        /// <summary>
        /// The Id of this Response in the sqlite database.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the Confidant this response applies to.
        /// </summary>
        public string Confidant { get; set; }

        /// <summary>
        /// The Rank this Response is in.
        /// </summary>
        public long Rank { get; set; }


        public int ResponseNumber { get; set; }

        /// <summary>
        /// The actual Response.
        /// </summary>
        public string Response { get; set; }

    
    }
}
