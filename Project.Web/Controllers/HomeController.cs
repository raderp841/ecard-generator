using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Web.DAL;
using Project.Web.Models;


namespace Project.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CardTemplateSqlDAL dal = new CardTemplateSqlDAL();
            List<CardTemplate> model = dal.GetAllTemplates();
            return View("Index", model);
        }

        public ActionResult GreetingCard(int id = 0)
        {
            GreetingCard gc = new GreetingCard();
            CardTemplateSqlDAL dal = new CardTemplateSqlDAL();
            CardTemplate temp = dal.GetTemplate(id);
            FullCard model = new FullCard(temp, gc);
            
            
            return View("GreetingCard", model);
        }

        [HttpPost]
        public ActionResult SavedCard(GreetingCard card, int templateId)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("GreetingCard", new { id = templateId });
            }

   
            else
            {
                CardTemplateSqlDAL Cdal = new CardTemplateSqlDAL();
                CardTemplate temp = Cdal.GetTemplate(templateId);
                GreetingCardSqlDal Gdal = new GreetingCardSqlDal();
                card.TemplateId = templateId;
                Gdal.SaveCard(card);
                FullCard fullCard = new FullCard(temp, card);
                return View("SavedCard", fullCard);
            }
        }

        public ActionResult ViewCard(FullCard card)
        {
            return View("ViewCard", card);
        }
    }
}