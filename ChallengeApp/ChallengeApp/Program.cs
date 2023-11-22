long number = 98010245678;

string numberInString = number.ToString();
int[] digitsInNumber = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
foreach (var digit in numberInString)
{
    if (digit == '0') { digitsInNumber[0]++; }
    else if (digit == '1') { digitsInNumber[1]++; }
    else if (digit == '2') { digitsInNumber[2]++; }
    else if (digit == '3') { digitsInNumber[3]++; }
    else if (digit == '4') { digitsInNumber[4]++; }
    else if (digit == '5') { digitsInNumber[5]++; }
    else if (digit == '6') { digitsInNumber[6]++; }
    else if (digit == '7') { digitsInNumber[7]++; }
    else if (digit == '8') { digitsInNumber[8]++; }
    else if (digit == '9') { digitsInNumber[9]++; }
}

Console.WriteLine("Result for count: " + number);

for (var i = 0; i < digitsInNumber.Length; i++)
{
    Console.WriteLine(i + " => " + digitsInNumber[i]);
}