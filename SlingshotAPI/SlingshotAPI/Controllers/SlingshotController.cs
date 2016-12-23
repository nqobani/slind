using SlingshotAPI.ApplicationLogicLayer.Services;
using SlingshotAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;

namespace SlingshotAPI.Controllers
{
    [RoutePrefix("api")]
    public class SlingshotController : ApiController
    {
        UserService obj = new UserService();
        [Route("registerUser")]
        public IEnumerable<UserModel> register(string email, string password)
        {

            try
            {
                return obj.createUser(email, password);
            }
            catch (ErrorMessage c)
            {
                throw c;
            }

        }
        [Route("addCampaign")]
        public CompleteCampaign addCampaign(string campaignName="No Name", string thumbnail="HTTPS", string subject="TESTIING", string HTML="<!DOCTYPE html>", string fileName="jack.png", string file=@"dfjhkd\dgjh\dfjhghs\jack.png", string status = "public")
        {
            UserService obj = new UserService();

            return obj.createCampaign(campaignName, thumbnail, subject, HTML, fileName, file,  status);
        }
        [Route("uploadImage")]
        public void uploadImage()
        {
            Directory.CreateDirectory(@"C:\Users\User\Music\images");
            string sourceFile = Path.Combine(@"C:\Users\User\Music\", "banner.jpg");
            string destFile = Path.Combine(@"C:\Users\User\Music\images\", "banner.jpg");
            File.Copy(sourceFile, destFile, true);
        }
    }
}
