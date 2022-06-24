using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies.BlobService
{
    public interface IBlobStorageService
    {
        Task<BlobInfo> GetBlobAsync(string name, string containerName);
        Task<IEnumerable<string>> ListBlobMoviesAsync(string containerName);
        Task UploadFileBlobAsync(string filePath, string fileName, string containerName);
        Task UploadContentBlobAsync(string content, string fileName, string containerName);
        Task DeleteBlobAsync(string blobName, string containerName);
        Task UploadFileContent(IFormFile file, string containerName, string fileName);
        Task UploadTest(string fileName, string containerName, MemoryStream content);
    }
}
