using System.Collections.Generic;

namespace CoderFoundry.Web.Controllers
{
    /// <summary>
    /// Strongly typed class for JQGrid data return;  Specifically to Unit Test the controllers
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class JqGridData<TModel>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="JqGridData{TModel}"/> class.
            /// </summary>
            public JqGridData()
            {
                Rows = new List<TModel>();
            }
            // add in whatever other properties you want for JQGrid 
            // --CASE SENSITIVE to the jquery control--
            /// <summary>
            /// Gets or sets the total.
            /// </summary>
            /// <value>
            /// The total.
            /// </value>
            public int Total {get; set; }
            /// <summary>
            /// Gets or sets the page.
            /// </summary>
            /// <value>
            /// The page.
            /// </value>
            public int Page { get; set; }
            /// <summary>
            /// Gets or sets the records.
            /// </summary>
            /// <value>
            /// The records.
            /// </value>
            public int Records { get; set; }
            /// <summary>
            /// Gets or sets the rows.
            /// </summary>
            /// <value>
            /// The rows.
            /// </value>
            public List<TModel> Rows { get; set; }

        }
}