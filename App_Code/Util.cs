using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.Security;
using System.Web;


public partial class Util
{
    public static void SendMail(string sExpediteur, string sDisplayName, string lstDestCommaSeparator, string strSubject, string strMessage, bool bHTML = true, string strReplyTo = "", List<Attachment> pj = null)
    {
        MailMessage msg = new MailMessage();
        MailAddress addressFrom = new MailAddress(sExpediteur, sDisplayName);

        msg.From = addressFrom;

        string[] mailAddresses = lstDestCommaSeparator.Split(',');
        for (int i = 0; i <= mailAddresses.Length - 1; i++)
        {
            msg.To.Add(mailAddresses[i]);
        }

        if (!string.IsNullOrEmpty(strReplyTo))
        {
            msg.ReplyToList.Add(new MailAddress(strReplyTo));
        }

        msg.Subject = strSubject;
        msg.IsBodyHtml = bHTML;
        msg.Body = strMessage;
        msg.BodyEncoding = System.Text.Encoding.GetEncoding("iso-8859-15");

        if (pj != null)
        {
            foreach (Attachment a in pj)
                msg.Attachments.Add(a);
        }

        SmtpClient smtp = new SmtpClient();
        smtp.Send(msg);

    }

}
