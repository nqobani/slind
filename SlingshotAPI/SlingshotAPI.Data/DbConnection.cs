using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SlingshotAPI.Data.Models;

namespace SlingshotAPI.Data
{
    

    public class DbConnection
    {
        private DataClasses1DataContext con = new DataClasses1DataContext();


        public IEnumerable<UserModel> createUser(string email, string password)
        {
            var userC = (from user in con.tblUsers
                                    where user.email == email
                                    select new UserModel
                                    {
                                        id = user.Id,
                                       email = user.email,
                                       password=user.password
                                   }).ToList();

            Boolean userExist = false;
            

            if (userC.Count>0)
            {
                throw new ErrorMessage {
                    message="Registration Failed",
                    course="User with the same email addres already exists"
                };
                //User with the same email address already exist, try another one or sign in
            }
            else
            {
                tblUser newUser = new tblUser();
                newUser.email = email;
                newUser.password = password;

                con.tblUsers.InsertOnSubmit(newUser);
                con.SubmitChanges();
                int ids = newUser.Id;

                var newUsers = (from user in con.tblUsers
                             where user.Id == ids
                                select new UserModel
                             {
                                 id = user.Id,
                                 email = user.email,
                                 password = user.password
                             }).ToList();
                return newUsers;
            }
           
        }

        public CampaingModel createCampain(string name,string thumbnail,string status="public")
        {
            tblCampaign newCampaign = new tblCampaign();
            newCampaign.name = name;
            newCampaign.thumbnail = thumbnail;
            newCampaign.status = status;
            con.tblCampaigns.InsertOnSubmit(newCampaign);
            con.SubmitChanges();

            int campaignId = newCampaign.Id;

            var newCampaignData = (from c in con.tblCampaigns
                                  where c.Id == campaignId
                                  select new CampaingModel
                                  {
                                      id = c.Id,
                                      name = c.name,
                                      status = c.status,
                                      thumbnails = c.thumbnail
                                  }).FirstOrDefault();

            return newCampaignData;
        }
        public EmailModel createEmail(int campaignId, string subject,string HTML)
        {
            tblEmail newEmail = new tblEmail();
            newEmail.campaignId = campaignId;
            newEmail.subject = subject;
            newEmail.html = HTML;

            con.tblEmails.InsertOnSubmit(newEmail);
            con.SubmitChanges();
            int emailId = newEmail.Id;

            var newEmailData = (from e in con.tblEmails
                               where e.Id == emailId
                               select new EmailModel
                               {
                                   id=e.Id,
                                   campaignId=e.campaignId,
                                   subject=e.subject,
                                   html=e.html
                               }).FirstOrDefault();
            return newEmailData;
        }
        public AttechmentsModel createAttecment(int emailId, string name, string file/*Path*/)
        {
            tblAttachment newAttechment = new tblAttachment();
            newAttechment.emailId = emailId;
            newAttechment.name = name;
            newAttechment.file = file;
            con.tblAttachments.InsertOnSubmit(newAttechment);
            con.SubmitChanges();
            int attID = newAttechment.Id;

            var newAttechmentData = (from a in con.tblAttachments
                                     where a.Id == attID
                                     select new AttechmentsModel
                                     {
                                         id = a.Id,
                                         emailId = a.emailId,
                                         name = a.name,
                                         file = a.file
                                     }).FirstOrDefault();
            return newAttechmentData;
        }
        public IEnumerable<HistoryModel> createHistory(int userId, int campaignId, string toEMail, int imageId=0)
        {
            tblHistory newHistory = new tblHistory();
            newHistory.userId = userId;
            newHistory.imageId = imageId;
            newHistory.campaignId = campaignId;
            newHistory.toEMail = toEMail;
            con.tblHistories.InsertOnSubmit(newHistory);
            con.SubmitChanges();
            int histID = newHistory.Id;

            var newHistoryData = (from h in con.tblHistories
                                  where h.Id == histID
                                  select new HistoryModel
                                  {
                                      id=h.Id,
                                      userId=h.userId,
                                      campaignId=h.campaignId,
                                      sentDateTime=Convert.ToDateTime(h.sentDateTime),
                                      toMail=h.toEMail
                                  }).ToList();
            return newHistoryData;
        }
    }
}
