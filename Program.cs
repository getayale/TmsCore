string? studentRegion = null;

if (studentRegion is not null)
{
    Console.WriteLine(studentRegion.ToUpper());
}
else
{
    Console.WriteLine("Region not provided");
}