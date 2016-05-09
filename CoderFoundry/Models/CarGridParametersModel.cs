namespace CoderFoundry.Models
{
    public class CarGridParametersModel
    {
        public string FilteredMake { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [include test territories].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [include test territories]; otherwise, <c>false</c>.
        /// </value>
        public string FilteredModel { get; set; }

        /// <summary>
        ///     Gets or sets the maximum rows.
        /// </summary>
        /// <value>
        ///     The maximum rows.
        /// </value>
        public int? MaxRows { get; set; }

        /// <summary>
        ///     Gets or sets the sort column.
        /// </summary>
        /// <value>
        ///     The sort column.
        /// </value>
        public string SortColumn { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [sort descending].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [sort descending]; otherwise, <c>false</c>.
        /// </value>
        public bool SortDescending { get; set; }
    }
}