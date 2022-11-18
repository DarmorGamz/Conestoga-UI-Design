Console.Write("What is the current day? (Monday=1 -> Friday=5)? "); // Satuday=6 
byte byCurrentDay = Convert.ToByte(Console.ReadLine()); // Byte 0-255
Console.WriteLine("Days left until the weekend: " + (6 - byCurrentDay));