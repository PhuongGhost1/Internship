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
    }
}