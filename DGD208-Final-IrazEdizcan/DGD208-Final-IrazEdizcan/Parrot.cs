using DGD208_Final_IrazEdizcan;

public class Parrot : IPet
{
    public string Type => "Parrot";
    public void Speak() => Console.WriteLine("Gagk!");
}
