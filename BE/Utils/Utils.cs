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
            string randomString = Guid.NewGuid().ToString("N").Substring(0, 10);

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


        public static async Task<string> UploadImgCourseToFirebase(IFormFile file, string CourseName, string Type)
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
                string objectName = $"images/courses/{CourseName}/{Type}{fileExtension}";

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

        public static async Task<string> UploadImgUserToFirebase(IFormFile file, string UserId, string Type)
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
                string objectName = $"images/users/{UserId}/{Type}{fileExtension}";

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

        public static async Task<string> UploadVideoToFirebase(IFormFile video, string CourseName, int indexChapter, int indexLecture)
        {
            string videoStoreDirectory = Path.Combine(Directory.GetCurrentDirectory(), "VideoStore");

            // Ensure the /VideoStore directory exists
            if (!Directory.Exists(videoStoreDirectory))
            {
                Directory.CreateDirectory(videoStoreDirectory);
            }

            // Save the uploaded video to a file in the /VideoStore directory
            string videoFilePath = Path.Combine(videoStoreDirectory, video.FileName);
            using (var fileStream = new FileStream(videoFilePath, FileMode.Create))
            {
                await video.CopyToAsync(fileStream);
            }
            ConvertVideoToHls(videoFilePath, videoStoreDirectory);
            if (File.Exists(videoFilePath))
            {
                File.Delete(videoFilePath);
            }
            var storageClient = StorageClient.Create();
            string bucketName = "courseonline-fee78.appspot.com";
            var objectUploadOptions = new UploadObjectOptions
            {
                PredefinedAcl = PredefinedObjectAcl.PublicRead
            };

            foreach (var filePath in Directory.GetFiles(videoStoreDirectory))
            {
                using var memoryStream = new MemoryStream();
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    await fileStream.CopyToAsync(memoryStream);
                }
                memoryStream.Position = 0;

                string fileName = Path.GetFileName(filePath);
                string objectName = $"videos/{CourseName}/Chapter{indexChapter}/Lecture{indexLecture}/{fileName}";

                await storageClient.UploadObjectAsync(bucketName, objectName, null, memoryStream, objectUploadOptions);
            }
            string[] files = Directory.GetFiles(videoStoreDirectory);

            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting file {file}: {ex.Message}");
                }
            }
            return $"https://storage.googleapis.com/{bucketName}/videos/{CourseName}/Chapter{indexChapter}/Lecture{indexLecture}/index.m3u8";
        }

        public static void ConvertVideoToHls(string inputPath, string outputPath)
        {
            string arguments = $"-i {inputPath} -codec: copy -start_number 0 -hls_time 2 -hls_list_size 0 -f hls {Path.Combine(outputPath, "index.m3u8")}";
            var process = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "ffmpeg",
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            process.WaitForExit();
        }
    }
}