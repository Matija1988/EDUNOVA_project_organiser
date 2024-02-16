
using System.ComponentModel.DataAnnotations;

namespace Organiser.ObjectClasses
{
    public interface IProject 
    {
        [Key]
        public int id { get; set; }
        DateTime DateEnd { get; set; }
        DateTime DateStart { get; set; }
        bool IsFinished { get; set; }
        string Name { get; set; }
        string UniqueID { get; set; }
            
    }
}