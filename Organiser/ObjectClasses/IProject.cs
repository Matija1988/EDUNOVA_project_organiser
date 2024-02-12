
namespace Organiser.ObjectClasses
{
    public interface IProject
    {
        DateTime DateEnd { get; set; }
        DateTime DateStart { get; set; }
        bool IsFinished { get; set; }
        string Name { get; set; }
        string UniqueID { get; set; }
    }
}