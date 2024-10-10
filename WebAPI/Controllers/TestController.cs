using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace FusionWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IConfiguration _config;
        public TestController(IConfiguration config)
        {
            _config = config;   
        }
        [HttpGet]
        [Route("GetfileInformation")]
        public string GetfileInformation()
        {
            string fileContent = "";
            string DriveMount = _config.GetSection("DriveMount").Value;
            try
            {
                string filePath = Path.Combine(DriveMount, "testfile.txt");
                fileContent = $"filepath: {filePath} - filecontent: ";
                if (System.IO.File.Exists(filePath))
                {
                    fileContent += System.IO.File.ReadAllText(filePath);
                }
                else
                {
                    fileContent += $"not fount: {filePath}";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return fileContent;
        }
    }
}
