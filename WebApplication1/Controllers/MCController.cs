using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using MailChimp.Net;
using MailChimp.Net.Core;
using MailChimp.Net.Models;
using System.Net;

namespace Falshstarts.Controllers
{
    public class DefaultController : Controller
    {
        private static readonly MailChimpManager Manager = new MailChimpManager();

        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.ListId = "78dd03f02e";
                var model = await Manager.Members.GetAllAsync("78dd03f02e", new MemberRequest { Limit = 500, Status = Status.Subscribed });
                return View(model);
            }
            catch (MailChimpException mce)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway, mce.Message);

            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.ServiceUnavailable, ex.Message);

            }


        }
    }
}