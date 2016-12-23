﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlingshotAPI.Models
{

    public class UserModel
    {
        public int id { set; get; }
        public string email { set; get; }
        public string password { set; get; }
    }
    public class CampaingModel
    {
        public int id { set; get; }
        public string name { set; get; }
        public string thumbnails { set; get; }
        public string status { set; get; }
    }
    public class EmailModel
    {
        public int id { set; get; }
        public int campaignId { get; set; }
        public string subject { set; get; }
        public string html { get; set; }
    }
    public class AttechmentsModel
    {
        public int id { set; get; }
        public int emailId { set; get; }
        public string name { get; set; }
        public string file { get; set; }
    }
    public class VCardModel
    {
        public int id { set; get; }
        public int UserId { set; get; }
        public string profilePicturePath { get; set; }
        public string firstName { set; get; }
        public string lastName { get; set; }
        public string company { get; set; }
        public string jobTitle { get; set; }
        public string fileAs { get; set; }
        public string email { get; set; }
        public string twitter { get; set; }
        public string webPageAddress { set; get; }
        public string businessPhoneNumber { set; get; }
        public string mobilePhoneNumber { set; get; }
        public string country { set; get; }
        public string city { set; get; }
        public int code { set; get; }
    }
    public class ClientVCardModel
    {
        public int id { set; get; }
        public int UserId { set; get; }
        public int clientId { set; get; }
        public string profilePicturePath { get; set; }
        public string firstName { set; get; }
        public string lastName { get; set; }
        public string company { get; set; }
        public string jobTitle { get; set; }
        public string fileAs { get; set; }
        public string email { get; set; }
        public string twitter { get; set; }
        public string webPageAddress { set; get; }
        public string businessPhoneNumber { set; get; }
        public string mobilePhoneNumber { set; get; }
        public string country { set; get; }
        public string city { set; get; }
        public int code { set; get; }
    }
    public class EventModel
    {
        public int id { get; set; }
        public string title { set; get; }
        public DateTime startDateTime { set; get; }
        public DateTime endDateTime { set; get; }
    }
    public class HistoryModel
    {
        public int id { get; set; }
        public int userId { set; get; }
        public int imageId { set; get; }
        public string campaignId { set; get; }
        public DateTime sentDateTime { set; get; }
        public string toMail { set; get; }
    }
}