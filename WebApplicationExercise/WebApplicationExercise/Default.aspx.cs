using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using WebApplicationExercise.App_Code.Data;
using WebApplicationExercise.App_Code.Models;

namespace WebApplicationExercise
{
    public partial class _Default : Page
    {
        // Declaring the DBO and email sender objects.

        private DatabaseOperations databaseOpeations; 
        private EmailSender emailSender;
        protected void Page_Load(object sender, EventArgs e)
        {
            databaseOpeations = new DatabaseOperations("DBConnection");
            emailSender = new EmailSender();
        }

        /// <summary>
        /// The submitBtn_Click method handles form submission.
        /// It validates the form, creates a FormModel object with the submitted data,
        /// attempts to save it to the database, and sends an email. 
        /// If successful, it clears the form and displays a success message before
        /// redirecting to the default page. If unsuccessful, it displays an error message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            // Check if the page is valid
            if (Page.IsValid)
            {
                // Create a FormModel object with form data
                FormModel formModel = new FormModel(txtEmail.Text, txtFirstName.Text, txtLastName.Text, txtSubject.Text, txtMessage.Text);

                // Attempt to save the form data to the database and send an email
                if (databaseOpeations.SaveForm(formModel) && emailSender.sendEmail("web@goliveuk.com", formModel))
                {
                    // Clear form fields
                    txtEmail.Text = string.Empty;
                    txtFirstName.Text = string.Empty;
                    txtLastName.Text = string.Empty;
                    txtSubject.Text = string.Empty;
                    txtMessage.Text = string.Empty;

                    // Display success message and redirect after a delay
                    txtResult.CssClass = "alert alert-success";
                    txtResult.Text = "Your form was successfully submited! We will contact you ASAP! Redirecting ...";
                    txtResult.Visible = true;


                    ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", "setTimeout(function(){ window.location.href = 'Default.aspx'; }, 2500);", true);
                }
                else
                {
                    // Display error message if form submission fails
                    txtResult.CssClass = "alert alert-danger";
                    txtResult.Text = "Something failed your form was not send. :(";
                    txtResult.Visible = true;
                }
                
            }
        }

        /// <summary>
        /// Button used to redirect the user to the admin panel where
        /// the received forms can be edited or deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdminPanel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}