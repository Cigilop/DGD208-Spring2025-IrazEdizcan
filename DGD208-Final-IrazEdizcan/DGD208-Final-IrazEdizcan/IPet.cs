using Programming2final;

namespace DGD208_Final_IrazEdizcan
{
    public interface IPet
    {
        string Name { get; }
        string Type { get; }
        int Hunger { get; }
        int Energy { get; }
        int Happiness { get; }

        void StartPetGame(PlayerInventory inventory);
    }
}
