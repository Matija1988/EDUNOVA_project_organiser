namespace Organiser.ObjectClasses
{
    public interface IFolder
    {
        string ContractActivityName { get; set; }
        string Location { get; set; }
        ProofOfDelivery ProofOfDelivery { get; set; }
    }
}