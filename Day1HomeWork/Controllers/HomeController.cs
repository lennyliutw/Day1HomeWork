﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Day1HomeWork.Models;
using MvcPaging;

namespace Day1HomeWork.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();

        // GET: AccountBooks
        public ActionResult Index(int? page)
        {

            var accbo = from ab in db.AccountBook select ab;
            accbo = accbo.OrderByDescending(s => s.Dateee);
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            return View(accbo.ToPagedList(currentPageIndex, 10));
        }

        // GET: AccountBooks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = db.AccountBook.Find(id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }
            return View(accountBook);
        }

        // GET: AccountBooks/Create
        public ActionResult Create()
        {
            List<SelectListItem> item = new List<SelectListItem>();
            item.Add(new SelectListItem() { Text = "1.收入", Value = "1", Selected = true });
            item.Add(new SelectListItem() { Text = "2.支出", Value = "2", Selected = false });
            ViewData["Categoryyy"] = item;

            return View();
        }

        // POST: AccountBooks/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Categoryyy,Amounttt,Dateee,Remarkkk")] AccountBook accountBook)
        {
            if (ModelState.IsValid)
            {
                accountBook.Id = Guid.NewGuid();
                db.AccountBook.Add(accountBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountBook);
        }

        // GET: AccountBooks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = db.AccountBook.Find(id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }

            #region DropDownListFor 
            List<SelectListItem> item = new List<SelectListItem>();
            switch (accountBook.Categoryyy.ToString())
            {
                case "1":
                    item.Add(new SelectListItem() { Text = "1.收入", Value = "1", Selected = true });
                    item.Add(new SelectListItem() { Text = "2.支出", Value = "0", Selected = false });
                    break;
                case "0":
                    item.Add(new SelectListItem() { Text = "1.收入", Value = "1", Selected = false });
                    item.Add(new SelectListItem() { Text = "2.支出", Value = "0", Selected = true });
                    break;
            }
            ViewData["CategoryList"] = item;
            #endregion

            return View(accountBook);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Categoryyy,Amounttt,Dateee,Remarkkk")] AccountBook accountBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountBook);
        }

        // GET: AccountBooks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = db.AccountBook.Find(id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }
            return View(accountBook);
        }

        // POST: AccountBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AccountBook accountBook = db.AccountBook.Find(id);
            db.AccountBook.Remove(accountBook);
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

        public ActionResult BeforeToday(DateTime date)
        {
            bool isValidate = date.Date <= DateTime.Today;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }

    }

}
