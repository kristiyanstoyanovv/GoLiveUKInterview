using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationExercise.App_Code.Models
{
    public class FormModel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string subject { get; set; }
        public string message { get; set; }

        public FormModel() { }

        public FormModel(string email, string firstName, string lastName, string subject, string message, int id)
        {
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.subject = subject;
            this.message = message;
            this.id = id;
        }

        public FormModel(string email, string firstName, string lastName, string subject, string message)
        {
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.subject = subject;
            this.message = message;
        }
        public FormModel(string email, string firstName, string subject, string message)
        {
            this.email = email;
            this.firstName = firstName;
            this.subject = subject;
            this.message = message;
        }
    }
}