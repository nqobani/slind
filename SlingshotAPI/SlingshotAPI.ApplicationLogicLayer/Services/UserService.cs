using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlingshotAPI.Data;
using System.Data;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using SlingshotAPI.Data.Models;

namespace SlingshotAPI.ApplicationLogicLayer.Services
{
    public class UserService
    {
        DbConnection dbCon = new DbConnection();
        public IEnumerable<UserModel> createUser(string email, string password)
        {
            try
            {
                return dbCon.createUser(email, password);
            }
            catch (ErrorMessage c)
            {
                throw c;
            }

        }
        public CompleteCampaign createCampaign(string campaignName, string thumbnail, string subject, string HTML, string fileName, string file, string status = "public")
        {
            
            var campaign = dbCon.createCampain(campaignName, thumbnail, status);

            int campID = campaign.id;

            var email = dbCon.createEmail(campID, subject, HTML);
            int eID = email.id;
            var attechments = dbCon.createAttecment(eID, fileName, file);

            return new CompleteCampaign {
                campiagn = campaign,
                email = email,
                attechment = attechments
            };
        }
    }
}
