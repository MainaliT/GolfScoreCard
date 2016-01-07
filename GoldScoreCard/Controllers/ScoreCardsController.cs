using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoldScoreCard.Models;

namespace GoldScoreCard.Controllers
{
    public class ScoreCardsController : Controller
    {
        private ScoreCardDBContext db = new ScoreCardDBContext();


        // GET: ScoreCards
        public ActionResult Index()
        {           
            return View(db.scores.ToList());
        }

        // GET: ScoreCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreCard scoreCard = db.scores.Find(id);
            if (scoreCard == null)
            {
                return HttpNotFound();
            }
            return View(scoreCard);
        }

        // GET: ScoreCards/Create
        public ActionResult Create()
        {
            PopulateTeesDropDownList();

            return View();
        }

        // POST: ScoreCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlayerName,Tees,Par,Total,holeOne,holeTwo,holeThree,holeFour,holeFive,holeSix,holeSeven,holeEight,holeNine")] ScoreCard scoreCard)
        {

            if (ModelState.IsValid)
            {
                db.scores.Add(scoreCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
         
            return View(scoreCard);
        }

        // GET: ScoreCards/Edit/5
        public ActionResult Edit(int? id)
        {
            PopulateTeesDropDownList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreCard scoreCard = db.scores.Find(id);
            if (scoreCard == null)
            {
                return HttpNotFound();
            }

            return View(scoreCard);
        }


        // POST: ScoreCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlayerName,Tees,Par,Total,holeOne,holeTwo,holeThree,holeFour,holeFive,holeSix,holeSeven,holeEight,holeNine")] ScoreCard scoreCard)
        {
           
            if (ModelState.IsValid)
            {
                db.Entry(scoreCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scoreCard);
        }

        // GET: ScoreCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreCard scoreCard = db.scores.Find(id);
            if (scoreCard == null)
            {
                return HttpNotFound();
            }
            return View(scoreCard);
        }

        // POST: ScoreCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScoreCard scoreCard = db.scores.Find(id);
            db.scores.Remove(scoreCard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       //Creating the List of the Tees including its value and text
        private void PopulateTeesDropDownList(string selectedTees = null)
        {

            List<SelectListItem> TeesLst = new List<SelectListItem>();

            TeesLst.Add(new SelectListItem()
            {
                Value = "Blue",
                Text = "Blue"
            });
            TeesLst.Add(new SelectListItem()
            {
                Value = "White",
                Text = "White"
            });

            TeesLst.Add(new SelectListItem()
            {
                Value = "Yellow",
                Text = "Yellow",

            });

            TeesLst.Add(new SelectListItem()
            {
                Value = "Red",
                Text = "Red",

            });

            ViewBag.Tees = new SelectList(TeesLst, "Value", "Text");           
        }


    }
}
