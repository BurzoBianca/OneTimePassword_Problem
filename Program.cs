using System;

public class OneTimePassword
{
    private const int validSeconds = 30;

    public string generatePassword(string userID, DateTime dateTime)
    {
        string oneTimePassword = userID + dateTime.ToString("ddMMyyyyHHmm");
    
        return oneTimePassword;
    }

    public bool verifyPassword(string userID, DateTime dateTime, string oneTimePassword)
    {
        string password = generatePassword(userID, dateTime);
        bool isValid = string.Equals(password, oneTimePassword, StringComparison.OrdinalIgnoreCase);

        DateTime currentTime = DateTime.Now;
        TimeSpan validPeriod = TimeSpan.FromSeconds(validSeconds);
        bool passwordIsValid = (currentTime - dateTime) <= validPeriod;

        return isValid && passwordIsValid;
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        string userID = "exampleUser";
        DateTime dateTime = DateTime.Now;

        OneTimePassword generator = new OneTimePassword();
        string oneTimePassword = generator.generatePassword(userID, dateTime);
        Console.WriteLine($"Generated one-time password: {oneTimePassword}");

        DateTime verifyDateTime = dateTime.AddSeconds(30);
        bool isValid = generator.verifyPassword(userID, verifyDateTime, oneTimePassword);
        Console.WriteLine($"One-time password verification : {isValid}");
    }
}