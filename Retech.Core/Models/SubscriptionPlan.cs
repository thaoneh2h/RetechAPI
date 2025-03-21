using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.Models
{
     public class SubscriptionPlan
    {
        [Key]
        public Guid PlanId { get; set; }
        public string PlanName { get; set; }
        public decimal price { get; set; }
        public string PlanDescription { get; set; }//enum('5','15','30')
        public string Benefit { get; set; } 
        //relationship
        public ICollection<UserSubscription> UserSubscription {  get; set; }=new List<UserSubscription>();

    }
}
