using DGD208_Final_IrazEdizcan;

public class Dog : IPet
{
    public string Type => "Dog";
    public void Speak() => Console.WriteLine("Woof!");
}
