namespace Uppgift_1_SOLID_Ny.Interfaces.Animal
{
    public interface IAnimal
    {
        int Id { get; set; }
        string Name { get; set; }
        bool CheckedIn { get; set; }
        int OwnerId { get; set; }
    }
}