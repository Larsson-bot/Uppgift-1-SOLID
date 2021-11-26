namespace Uppgift_1_SOLID_Ny.Interfaces
{
    public interface IAnimal
    {
        int Id { get; set; }
        string Name { get; set; }
        bool IsAnimalHere { get; set; }
    }
}