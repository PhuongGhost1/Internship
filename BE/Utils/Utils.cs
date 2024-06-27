using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

namespace BE.Utils
{
    public static class Utils
    {


        static Utils()
        {
            // Initialize FirebaseApp if not already initialized
            if (FirebaseApp.DefaultInstance == null)
            {
                string credentialPath = "config/firebase.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile(credentialPath)
                });
            }
        }
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

        public static string GetNameUnderscore(string input)
        {
            // Replace spaces with underscores
            string output = input.Replace(" ", "_");
            return output;
        }


        public static async Task<string> UploadImgToFirebase(IFormFile file, string CourseName, string Type)
        {
            try
            {
                var storageClient = StorageClient.Create();

                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                string bucketName = "courseonline-fee78.appspot.com";
                var objectUploadOptions = new UploadObjectOptions
                {
                    PredefinedAcl = PredefinedObjectAcl.PublicRead
                };
                string fileExtension = Path.GetExtension(file.FileName);
                string objectName = $"images/{CourseName}/{Type}{fileExtension}";

                await storageClient.UploadObjectAsync(bucketName, objectName, null, memoryStream, objectUploadOptions);

                // Construct the public URL to access the uploaded file
                string objectPublicUrl = $"https://storage.googleapis.com/{bucketName}/{objectName}";

                return objectPublicUrl;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while uploading the image: {ex.Message}");
                return null;
            }
        }
    }
}