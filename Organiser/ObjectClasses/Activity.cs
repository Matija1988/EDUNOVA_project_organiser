using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.ObjectClasses
{
    public  class Activity : IActivity
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
        [ForeignKey("ProofOfDeliveryID")]
        public ProofOfDelivery ProofOfDelivery { get; set; }
        public int? ProofOfDeliveryID { get; set; }
        public DateTime? DateAccepted { get; set; }

        public bool IsFinished { get; set; }
        [ForeignKey("ProjectID")]
        public Project AssociatedProject { get; set; }
        public int? ProjectID { get; set; }
        [ForeignKey("Member")]
        public int? MemberID { get; set; }



        public override string ToString ()
        {
            return "ID: " + id + " - " + "NAME: " + Name +
                   "\n   " + "DESCRPITION: " + Description +
                   "\n   " + "ASSOCIATED PROJECT: ID " + AssociatedProject.ProjectID + " NAME " + AssociatedProject.Name + 
                   "\n   " + "START DATE: " + DateStart + " - DEADLINE: " + DateEnd +
                   "\n   " + "PROOF OF DELIVERY: " + ProofOfDelivery.DocumentName +
                   "\n   " + "IS FINISHED: " + IsFinished +
                   "\n   " + DateAccepted +
                   "\n   " + "Delegated to: " + MemberID;
        }
    }
}
