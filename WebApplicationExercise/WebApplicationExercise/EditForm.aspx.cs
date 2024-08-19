using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationExercise.App_Code.Data;
using WebApplicationExercise.App_Code.Models;

namespace WebApplicationExercise
{
    public partial class EditForm : System.Web.UI.Page
    {
        // Declaring the DBO object.
        private DatabaseOperations databaseOperations;

        /// <summary>
        /// Handles the page load event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize database operations
            databaseOperations = new DatabaseOperations("DBConnection");

            // Check if the page is loaded for the first time
            if (!IsPostBack)
            {
                // Check if a formId query parameter is present in the URL
                if (int.TryParse(Request.QueryString["formId"], out int id))
                {
                    // Attempt to load the form from the database based on the formId
                    FormModel form = databaseOperations.loadFormById(id);

                    // If the form is found
                    if (form != null)
                    {
                        // Store the formId in session for future reference
                        Session["formId"] = id;

                        // Populate form fields with data from the loaded form
                        txtEmail.Text = form.email;
                        txtFirstName.Text = form.firstName;
                        txtLastName.Text = form.lastName;
                        txtSubject.Text = form.subject;
                        txtMessage.Text = form.message;
                    }
                    else
                    {
                        // Display error message if the form with the specified id does not exist
                        txtResult.Text = "A form with this id does not exist.";
                        txtResult.Visible = true;
                        txtResult.CssClass = "alert alert-danger";
                    }
                }
                else
                {
                    // Display error message if the formId query parameter is not valid
                    txtResult.Text = "Failed to load the form, probably wrong query parameter.";
                    txtResult.Visible = true;
                    txtResult.CssClass = "alert alert-danger";
                }
            }
        }

        /// <summary>
        /// Handles the click event of the edit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Check if the page is valid
            if (Page.IsValid)
            {
                // Check if a formId is stored in the session
                if (Session["formId"] != null)
                {
                    // Retrieve the formId from the session
                    int formId = (int)Session["formId"];

                    // Create a new FormModel object with updated data
                    FormModel newFormModel = new FormModel(txtEmail.Text, txtFirstName.Text, txtLastName.Text, txtSubject.Text, txtMessage.Text, formId);

                    // Attempt to update the form in the database
                    if (databaseOperations.updateFormById(newFormModel))
                    {
                        // If update is successful, remove formId from session
                        Session.Remove("formId");

                        // Display success message and redirect to Admin.aspx after a delay
                        txtResult.CssClass = "alert alert-success";
                        txtResult.Text = "Form was successfully edited! Redirecting ...";
                        txtResult.Visible = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", "setTimeout(function(){ window.location.href = 'Admin.aspx'; }, 2500);", true);
                    }
                    else
                    {
                        // Display error message if update fails
                        txtResult.CssClass = "alert alert-danger";
                        txtResult.Text = "Something failed your form was not edited. :(";
                        txtResult.Visible = true;
                    }
                }
            }
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
        /// Button used to redirect the user to the admin panel where
        /// the received forms can be edited or deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}