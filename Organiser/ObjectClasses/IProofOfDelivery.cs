
namespace Organiser.ObjectClasses
{
    public interface IProofOfDelivery
    {
        public int id { get; set; }
        DateTime DateCreated { get; set; }
        string DocumentName { get; set; }
        string Location { get; set; }
        Member Member { get; set; }
    }
}