using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retech.Core.Models
{
    public class UserSubscription
    {
        [Key]
        public Guid SubscriptionId { get; set; }
        public Guid UserId { get; set; }
        public Guid PlanId { get; set; }
        public int RemainingPost {  get; set; }
        public bool IsActive { get; set; } = false;
        //relationships
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public User User { get; set; }
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();
    }
}
