var name = "Greg";
var gender = "male";
var age = 33;

if (gender == "female" && age < 30)
{
    Console.WriteLine("Female under 30 yo.");
}
else if(name == "Eva" && age == 33)
{
    Console.WriteLine("Eva, age 33.");
}
else if(gender == "male" && age < 18)
{
    Console.WriteLine("Male under 18 yo.");
}
else if(name == "Greg" && !(gender == "female") && age > 30)
{
    Console.WriteLine("Greg, male, over 30 yo.");
}
else
{
    Console.WriteLine("Someone else.");
}