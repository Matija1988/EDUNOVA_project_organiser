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
        //[ForeignKey]
        public int? ProofOfDelivery { get; set; }
        public DateTime? DateAccepted { get; set; }

        public bool IsFinished { get; set; }
        [ForeignKey("Project")]
        public int AssociatedProject { get; set; }
        [ForeignKey("Member")]
        public int? MemberID { get; set; }
        
        

        public override string ToString()
        {
            return "ID: " + id + " - " + "NAME: " + Name +
                   "\n   " + "DESCRPITION: " + Description +
                   //  "\n   " + "ASSOCIATED PROJECT: ID " + AssociatedProject.id + " NAME " + AssociatedProject.Name + 
                   "\n   " + "START DATE: " + DateStart + " - DEADLINE: " + DateEnd +
                   //    "\n   " + "FOLDER LOCATION: " + ProofOfDelivery +
                   "\n   " + "IS FINISHED: " + IsFinished +
                   "\n   " + DateAccepted +
                   "\n   " + "Delegated to: " + MemberID;
        }
    }
}
