var number1 = 50;
var number2 = 10;

var name = "Greg";
var age = 37;

if (name == "Liz" || age < 30)
{
    Console.WriteLine("My name is Liz or age under 30.");
}
else if (name == "Greg" && age <= 40)
{
    Console.WriteLine("My name is Greg and age equal or under 40.");
}
else
{
    Console.WriteLine("Someone older than 40.");
}