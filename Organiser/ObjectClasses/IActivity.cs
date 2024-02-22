
using System.ComponentModel.DataAnnotations;

namespace Organiser.ObjectClasses
{
    public interface IActivity
    {
        [Key]
        int id { get; set; }
        int? ProjectID { get; set; }

        Project AssociatedProject { get; set; }

        DateTime? DateAccepted { get; set; }
        DateTime DateEnd { get; set; }
        DateTime DateStart { get; set; }
        string Description { get; set; }
       
        bool IsFinished { get; set; }
        int? MemberID { get; set; }
        string Name { get; set; }
    }
}