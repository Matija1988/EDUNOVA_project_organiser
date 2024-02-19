namespace Organiser.ObjectClasses
{
    public interface IMember
    {
        bool IsTeamLeader { get; set; }
        string LastName { get; set; }
        string Name { get; set; }
        char[] Password { get; set; }
        char[] Username { get; set; }
    }
}