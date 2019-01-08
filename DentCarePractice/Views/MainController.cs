using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace DentCarePractice.Views
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendData(string name, string phone)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("mvctest690@yandex.ru", "Lev");
            // кому отправляем
            MailAddress to = new MailAddress("mvctest690@yandex.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Theme";
            // текст письма
            m.Body = "<h2>Имя:</h2>"+name+"<br><br><h2>Телефон:</h2>"+phone;
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("mvctest690@yandex.ru", "testmvc123");
            smtp.EnableSsl = true;
            smtp.Send(m);


            return View("index");
        }
    }
}