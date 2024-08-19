using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationExercise.App_Code.Data;

namespace WebApplicationExercise
{
    public partial class Admin : System.Web.UI.Page
    {
        // Declaring the DBO object.
        private DatabaseOperations databaseOperations;

        /// <summary>
        /// On page load we are initializing the DBO (Database operations) object, so we can use it later.
        /// If the page is NOT postback, so we are visiting it for first time we are calling
        /// the bindforms() method which is used to load the information on the page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            databaseOperations = new DatabaseOperations("DBConnection");
            if (!Page.IsPostBack)
            {
                BindForms();
            }
        }

        /// <summary>
        /// This method binds data from a database to a Repeater 
        /// control named "rptForms" for displaying forms on a web page. 
        /// It loads all forms from the database into a DataTable, 
        /// sets the DataTable as the data source for the Repeater control, 
        /// and then binds the data to the control for display.
        /// </summary>
        private void BindForms()
        {
            
            DataTable dataTable = databaseOperations.loadAllForms();
            rptForms.DataSource = dataTable;
            rptForms.DataBind();
        }

        /// <summary>
        /// Button used to redirect the user back to the contact form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        /// <summary>
        /// This method handles the command event triggered by each LinkButton created by the repeater.
        /// It extracts the ID of a form from the command argument, converts it to an integer,
        /// and redirects the user to "EditForm.aspx" with the form ID as a query parameter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> Used to send the id of the form, so we can know which form we are editing.</param>
        protected void lnkEdit_Command(object sender, CommandEventArgs e)
        {
            int formId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect($"EditForm.aspx?formId={formId}");
        }

        /// <summary>
        /// This method handles the command event triggered by a LinkButton named "lnkDelete".
        /// It retrieves the form ID from the command argument, attempts to delete 
        /// the corresponding form from the database, and redirects to "Admin.aspx" if successful.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> Used to know which form we need to delete by formId. </param>
        protected void lnkDelete_Command(object sender, CommandEventArgs e)
        {
            int formId = Convert.ToInt32(e.CommandArgument);
            if (databaseOperations.deleteFormById(formId)) {
                Response.Redirect("Admin.aspx");
            }
        }
    }
}