using System.Collections.Generic;
public static class RegexType
{
    public const string Email =
            @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

    public const string Phone = @"^[0-9]{10}$";
}

public static class Utility
{
    public static List<string> GetContactStatus()
    {
        List<string> status = new List<string>();
        status.Add("Active");
        status.Add("Inactive");
        return status;
    }
}