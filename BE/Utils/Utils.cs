namespace BE.Utils
{
    public static class Utils
    {
        public static string GenerateIdModel(string model)
        {
            string randomString = Guid.NewGuid().ToString("N").Substring(0, 10); // "N" format removes the dashes

            // Return the formatted string
            return $"{model}_{randomString}";
        }
        public static DateTime GetTimeNow()
        {
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vietnamTimeZone);
            return vietnamTime;
        }
    }
}