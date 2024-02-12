
namespace Organiser.ObjectClasses
{
    public interface IActivity
    {
        Project AssociatedProject { get; set; }
        DateTime DateAccepted { get; set; }
        DateTime DateEnd { get; set; }
        DateTime DateStart { get; set; }
        string Description { get; set; }
        Folder Folder { get; set; }
        bool IsFinished { get; set; }
        Member Member { get; set; }
        string Name { get; set; }
    }
}