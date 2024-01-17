﻿namespace Library.Web.Controllers
{
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Home;
    using Services;
    using Services.Html;
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Threading.Tasks;

    using static WebConstants;

    public class HomeController : Controller
    {
        private const string AskModelName = AskBgModelName;
        private const string ExtendPeriodModelName = ExtendPeriodBgModelName;

        private readonly IEmailSender emailSender;
        private readonly IHtmlService html;
        private readonly IHomeService home;

        public HomeController(IEmailSender emailSender, IHtmlService html, IHomeService home)
        {
            this.emailSender = emailSender;
            this.html = html;
            this.home = home;
        }
      
        public async Task<IActionResult> Index()
        => View(new ArticleListingHomeViewModel
        {
            Articles = await home.LatestFourArticlesAsync(CultureInfo.CurrentCulture.Name)
        });

        public IActionResult Ask()
            => View();

        [HttpPost]
        [ValidateModelState]
        public IActionResult Ask(AskFormModel model)
        {
            model.Description = this.html.Sanitize(model.Description);

            this.TempData.AddSuccessMessage(string.Format(TempDataSendEmailText, AskModelName, ""));

            var email = EmailReceiverForAsk;

            var htmlString = string.Format(EmailReceiverHtmlTextAsk, model.Description, model.Phone, model.Email, model.UserInfo);

            emailSender.SendEmailWithQuestionAsync(email, htmlString, EmailHeadingForAsk);

            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult ExtendPeriod()
            => View();

        [HttpPost]
        [ValidateModelState]
        public IActionResult ExtendPeriod(ExtendPeriodFormModel model)
        {
            var email = EmailReceiverForAsk;

            var htmlString = string.Format(EmailReceiverHtmlTextExtendPeriod, model.BookInfo, model.CardNumber, model.Email, model.UserName);

            emailSender.SendEmailWithQuestionAsync(email, htmlString, EmailHeadingForExtendPeriod);

            this.TempData.AddSuccessMessage(string.Format(TempDataSendEmailText, ExtendPeriodModelName, EndingLetterA));

            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult SetLanguage(string id)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(id)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult ViewPdf(string name)
         => View(new PdfViewModel
         {
             Name = name
         });

        public IActionResult PriceList()
        {
            var rawHtml = FormFileExtensions.ReadTxtFile(PriceListPagePath);

            return View(new RawHtmlViewModel
            {
                Html = rawHtml
            });
        }

        public IActionResult ProgramForKids()
        {
            var rawHtml = FormFileExtensions.ReadTxtFile(ProgramForKidsPagePath);

            return View(new RawHtmlViewModel
            {
                Html = rawHtml
            });
        }

        public IActionResult Contact()
            => View();

        public IActionResult History()
            => View();

        //[ValidateLocalization("bg")]
        public IActionResult MihalakiGeorgiev()
            => View();

        public IActionResult Functions()
            => View();

        public IActionResult Structure()
            => View();

        public IActionResult WorkTime()
            => View();
           
        public IActionResult Staff()
            => View();

        public IActionResult Faq()
            => View();

        public IActionResult Partners()
            => View();

        public IActionResult Contributors()
            => View();

        public IActionResult Services()
            => View();

        public IActionResult Vidin()
            => View();

        public IActionResult ForTheStudents()
            => View();

        public IActionResult ForTheEnthusiasts()
            => View();

        public IActionResult Internet()
            => View();

        public IActionResult Editions()
            => View();

        public IActionResult Links()
            => View();

        public IActionResult LibraryPost()
            => View();

        public IActionResult BecomeVolunteer()
            => View();

        public IActionResult Covid()
            => View();

        public IActionResult Library()
            => View();

        public IActionResult Map()
            => View();

        //Departments static pages

        public IActionResult Art()
            => View();

        public IActionResult BookBorrowing()
            => View();

        public IActionResult Children()
            => View();

        public IActionResult Homeland()
            => View();

        public IActionResult InformationCenter()
            => View();

        public IActionResult ReadingRooms()
            => View();

        public IActionResult ForeignReadingRoom()
            => View();

        public IActionResult SrcDepartment()
            => View();

        public IActionResult Methodological()
            => View();

        public IActionResult EventsRoom()
            => View();

        public IActionResult Donations()
            => View();

        public IActionResult Donatebook()
            => View();

        public IActionResult Donate()
            => View();

        public IActionResult Privacy()
            => View();

        public IActionResult SiteMap()
            => this.Content(SitemapPath, TextOrXmlFileType);

        public IActionResult Robots()
            => this.Content(RobotsPath, TextOrXmlFileType);

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}