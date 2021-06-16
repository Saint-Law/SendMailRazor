using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using SendMailRazor.Models;

namespace SendMailRazor.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public void OnGet()
        {

        }

        [BindProperty]
        public Email SendMail { get; set; } 

        public async Task OnPost()
        {
            string To = SendMail.To;
            string Subject = SendMail.Subject;
            string Body = SendMail.Body;

            MailMessage mm = new MailMessage();
            mm.To.Add(To);
            mm.Subject = Subject;
            mm.Body = Body;
            mm.IsBodyHtml = false;
            mm.From = new MailAddress("your personal gmail");

            //configuring smtp of gmails
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("your personal gmail", "your email password");
            await smtp.SendMailAsync(mm);
            ViewData["Message"] = "The Mail Has Been Sent To " + SendMail.To;
            
        }
    }
}
