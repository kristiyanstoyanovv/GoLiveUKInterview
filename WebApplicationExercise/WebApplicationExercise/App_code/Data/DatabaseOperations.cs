using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WebApplicationExercise.App_Code.Models;

namespace WebApplicationExercise.App_Code.Data
{

    public class DatabaseOperations
    {

        private string connectionString;

        public DatabaseOperations(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Saves a form to the database.
        /// </summary>
        /// <param name="formModel">The FormModel object representing the form to be saved.</param>
        /// <returns>True if the form is successfully saved, otherwise false.</returns>
        public bool SaveForm(FormModel formModel)
        {
            // Get the connection string from the configuration file
            var CFC = WebConfigurationManager.ConnectionStrings[connectionString];
            try
            {
                // Establish a connection to the database
                using (SqlConnection dbConnection = new SqlConnection(CFC.ConnectionString))
                {
                    // Create a SQL command to insert the form data into the database
                    var command = new SqlCommand("INSERT INTO Forms (email, firstName, lastName, subject, message) VALUES (@email, @firstName, @lastName, @subject, @message)", dbConnection);

                    // Set parameter values for the SQL command
                    command.Parameters.AddWithValue("@email", formModel.email);
                    command.Parameters.AddWithValue("@firstName", formModel.firstName);
                    command.Parameters.AddWithValue("@lastName", formModel.lastName);
                    command.Parameters.AddWithValue("@subject", formModel.subject);
                    command.Parameters.AddWithValue("@message", formModel.message);

                    // Open the database connection
                    dbConnection.Open();

                    // Execute the SQL command to insert the form data
                    command.ExecuteNonQuery();

                    // Return true indicating successful form save
                    return true;
                }
            }
            catch { }

            // Return false indicating failure to save the form
            return false;
        }

        /// <summary>
        /// Loads all forms from the database.
        /// </summary>
        /// <returns>A DataTable containing all the forms, or null if an error occurs.</returns>
        public DataTable loadAllForms()
        {
            // Get the connection string from the configuration file
            var CFC = WebConfigurationManager.ConnectionStrings[connectionString];
            try
            {
                // Establish a connection to the database
                using (SqlConnection dbConnection = new SqlConnection(CFC.ConnectionString))
                {
                    // Create a SQL command to select all forms from the database
                    var command = new SqlCommand("SELECT * FROM Forms", dbConnection);

                    // Create a DataTable to hold the query results
                    DataTable dt = new DataTable();

                    // Create a DataAdapter to fill the DataTable with the query results
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Fill the DataTable with the query results
                    adapter.Fill(dt);

                    // Return the populated DataTable
                    return dt;
                }
            }
            catch { }
            // Return null indicating failure to load forms from the database.
            return null;
        }


        /// <summary>
        /// Deletes a form from the database by its ID.
        /// </summary>
        /// <param name="formId">The ID of the form to delete.</param>
        /// <returns>True if the form is successfully deleted, otherwise false.</returns>
        public bool deleteFormById(int formId)
        {
            // Get the connection string from the configuration file
            var CFC = WebConfigurationManager.ConnectionStrings[connectionString];
            try
            {
                // Establish a connection to the database
                using (SqlConnection dbConnection = new SqlConnection(CFC.ConnectionString))
                {
                    // Create a SQL command to delete the form from the database using its ID
                    var command = new SqlCommand("DELETE FROM Forms WHERE id = @formId", dbConnection);

                    // Set the value of the parameter @formId
                    command.Parameters.AddWithValue("@formId", formId);

                    // Open the database connection
                    dbConnection.Open();

                    // Execute the SQL command to delete the form
                    command.ExecuteNonQuery();

                    // Return true indicating successful deletion
                    return true;
                }
            }
            catch { }

            // Return false indicating failure to delete the form
            return false;
        }

        /// <summary>
        /// Loads a form from the database by its ID.
        /// </summary>
        /// <param name="formId">The ID of the form to load.</param>
        /// <returns>A FormModel object representing the loaded form, or null if the form is not found or an error occurs.</returns>
        public FormModel loadFormById(int formId)
        {
            // Initialize form to null
            FormModel form = null;

            // Get the connection string from the configuration file
            var CFC = WebConfigurationManager.ConnectionStrings[connectionString];

            try
            {
                // Establish a connection to the database
                using (SqlConnection dbConnection = new SqlConnection(CFC.ConnectionString))
                {
                    // Create a SQL command to select the form from the database by its ID
                    var command = new SqlCommand("SELECT * FROM Forms WHERE id = @formId", dbConnection);

                    // Set the value of the parameter @formId
                    command.Parameters.AddWithValue("@formId", formId);

                    // Open the database connection
                    dbConnection.Open();

                    // Execute the SQL command to retrieve the form
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        // Check if a row is found
                        if (reader.Read())
                        {
                            // Create a new FormModel object and populate it with data from the database
                            form = new FormModel
                            {
                                email = reader["email"].ToString(),
                                firstName = reader["firstName"].ToString(),
                                lastName = reader["lastName"].ToString(),
                                subject = reader["subject"].ToString(),
                                message = reader["message"].ToString(),
                                id = Convert.ToInt32(reader["id"])
                            };
                        }
                    }

                }

            }
            catch { }

            // Return the loaded form (or null if not found or an error occurs)
            return form;
        }

        /// <summary>
        /// Updates a form in the database with the provided FormModel object.
        /// </summary>
        /// <param name="formModel">The FormModel object containing updated form data.</param>
        /// <returns>True if the form is successfully updated, otherwise false.</returns>
        public bool updateFormById(FormModel formModel)
        {
            // Get the connection string from the configuration file
            var CFC = WebConfigurationManager.ConnectionStrings[connectionString];

            try
            {
                // Establish a connection to the database
                using (SqlConnection dbConnection = new SqlConnection(CFC.ConnectionString))
                {
                    // Create a SQL command to update the form in the database
                    var command = new SqlCommand("UPDATE Forms SET email = @email, firstName = @firstName, lastName = @lastName, subject = @subject, message = @message WHERE id = @formId", dbConnection);

                    // Set parameter values for the SQL command
                    command.Parameters.AddWithValue("@email", formModel.email);
                    command.Parameters.AddWithValue("@firstName", formModel.firstName);
                    command.Parameters.AddWithValue("@lastName", formModel.lastName);
                    command.Parameters.AddWithValue("@subject", formModel.subject);
                    command.Parameters.AddWithValue("@message", formModel.message);
                    command.Parameters.AddWithValue("@formId", formModel.id);

                    // Open the database connection
                    dbConnection.Open();

                    // Execute the SQL command to update the form
                    command.ExecuteNonQuery();
                }

                // Return true indicating successful update
                return true;
            }
            catch { }

            // Return false indicating failure to update the form
            return false;
        }
    }
}