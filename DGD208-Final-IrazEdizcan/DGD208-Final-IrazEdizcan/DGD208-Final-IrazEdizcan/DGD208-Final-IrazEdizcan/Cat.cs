using DGD208_Final_IrazEdizcan;

public class Cat : IPet
{
    public string Type => "Cat";
    public void Speak() => Console.WriteLine("Meow");
}
