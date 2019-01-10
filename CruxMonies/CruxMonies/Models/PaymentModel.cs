using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CruxMonies.Models
{
    public class PaymentModel
    {
        public int MemberId { get; set; }
        public int IntId { get; set; }
        public DateTime Date { get; set; }
        public DateTime InterestDate { get; set; }

        public string UserId { get; set; }
        public decimal InterestDue { get; set; }
        public decimal Deposit { get; set; }
        public decimal Total { get; set; }
        public List<Membership> MembershipList { get; set; }
        public List<PaymentModel> MyAccountInfo { get; set; }
        public List<RegisterViewModel> MyAccountInfo2 { get; set; }

    }
}