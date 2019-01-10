using CruxMonies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CruxMonies.Controllers
{
    public class PaymentController : Controller
    {
        CruxInterestEntities Db = new CruxInterestEntities();
        //
        // GET: /Payment/
        public ActionResult PaymentIndex(Membership member)
        {

            PaymentModel model = new PaymentModel();

            model.MembershipList = Db.Memberships.ToList();
            model.MemberId = member.MemberId;

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult PaymentIndex(PaymentModel model)
        {
            if (ModelState.IsValid)
            {
               
                InterestInfo interestinfo = new InterestInfo();
                      
                interestinfo.MemberId = model.MemberId;
                interestinfo.Date = DateTime.Today;

                model.InterestDate = interestinfo.Date.AddDays(1.0);
               
                interestinfo.InterestDate = model.InterestDate;

                interestinfo.UserId = User.Identity.GetUserId().ToString();
                if (model.MemberId == 1)
                {
                    model.Deposit =25000 ;    
                }
                else if(model.MemberId== 2){
                    model.Deposit = 50000;
                }
                else if (model.MemberId == 3)
                {
                    model.Deposit = 100000;
                }

                interestinfo.Deposit = model.Deposit;

                //if (interestinfo.InterestDate.Equals(DateTime.Today) && interestinfo.MemberId == 1)
                //{
                //    model.InterestDue = (interestinfo.Deposit * (10 / 100)).Value;
                //    interestinfo.InterestDue = model.InterestDue;
                //}
                //else if (interestinfo.InterestDate.Equals(DateTime.Today) && interestinfo.MemberId == 2)
                //{
                //    model.InterestDue = (interestinfo.Deposit * (15 / 100)).Value;
                //    interestinfo.InterestDue = model.InterestDue;
                //}
                //else if (interestinfo.InterestDate.Equals(DateTime.Today) && interestinfo.MemberId == 3)
                //{
                //    model.InterestDue = (interestinfo.Deposit * (20 / 100)).Value;
                //    interestinfo.InterestDue = model.InterestDue;
                //}
                //if (interestinfo.InterestDue != null)
                //{

                //    decimal x = interestinfo.InterestDue.Value;
                //    decimal y = interestinfo.Deposit.Value;
                //    decimal z = x + y;
                //    model.Total = z;
                //    interestinfo.Total = model.Total;

                //}

                //else
                //{
                //    interestinfo.Total = interestinfo.Deposit;
                //}

                Db.InterestInfoes.Add(interestinfo);
                Db.SaveChanges();

                return RedirectToAction("PaymentIndex");
            }
            return RedirectToAction("PaymentIndex");
        }
    }
}