using System.Collections.Generic;

namespace CoderFoundry.Models
{
    public class SelectCarGridModels
    {
        public SelectCarGridModels()
        {
            SelectCarModels = new List<CarModel>();
        }

        /// <summary>
        ///     Gets or sets the select location search models.
        /// </summary>
        /// <value>
        ///     The select location search models.
        /// </value>
        public List<CarModel> SelectCarModels { get; set; }

        /// <summary>
        ///     Gets or sets the total rows.
        /// </summary>
        /// <value>
        ///     The total rows.
        /// </value>
        public int TotalRows { get; set; }
    }
}