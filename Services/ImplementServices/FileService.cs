using Firebase.Auth;
using Firebase.Storage;
using Microsoft.Extensions.Configuration;
using Services.Exceptions;
using Services.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.ImplementServices
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _config;
        private String ApiKey;
        private static string Bucket;
        private static string AuthEmail;
        private static string AuthPassword;
        public FileService(IConfiguration config)
        {
            _config = config;
            ApiKey = _config["Firebase:ApiKey"];
            Bucket = _config["Firebase:Bucket"];
            AuthEmail = _config["EmailUserName"];
            AuthPassword = _config["EmailPassword"];
        }
        public async Task<string> uploadFile(Stream fileStream, string fileName)
        {
            try
            {
                var cancellation = new CancellationTokenSource();

                // Upload trực tiếp mà không cần token xác thực
                var task = new FirebaseStorage(Bucket)
                    .Child(fileName)
                    .PutAsync(fileStream, cancellation.Token);

                // Đợi kết quả upload và lấy link download
                string link = await task;
                return link;
            }
            catch (CrudException cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.InternalServerError, "Lỗi hệ thống!", ex?.Message);
            }
        }

    }
}
