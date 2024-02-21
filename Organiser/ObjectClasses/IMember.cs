using System.ComponentModel.DataAnnotations;

namespace Organiser.ObjectClasses
{
    public interface IMember
    {
        [Key]
        public int id { get; set; }
        bool IsTeamLeader { get; set; }
        string LastName { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        string Username { get; set; }
    }
}