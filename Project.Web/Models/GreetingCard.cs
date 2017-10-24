using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Project.Web.Models
{
    public class GreetingCard
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }

        [Required(ErrorMessage = "Enter Their Email")]
        [Display (Name = "Their Email")]
        public string ToEmail { get; set; }

        [Required(ErrorMessage = "Enter Their NAme")]
        [Display(Name = "Their Name")]
        public string ToName { get; set; }

        [Required(ErrorMessage = "Enter Your Message")]
        [Display(Name = "Your Message")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Enter Your Email")]
        [Display(Name = "Your Email")]
        public string FromEmail { get; set; }

        [Required(ErrorMessage = "Enter Your Name")]
        [Display(Name = "Your Name")]
        public string FromName { get; set; }
    }
}