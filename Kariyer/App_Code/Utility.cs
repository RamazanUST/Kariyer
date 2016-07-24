using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Kariyer.App_Code
{
    public class Utility
    {
        public static string UyariVer(HataTip? tip, string mesaj)
        {
            string style = "alert-info";

            if (tip.HasValue)
            {
                switch (tip)
                {
                    case HataTip.bilgi: style = "alert-info"; break;
                    case HataTip.uyar: style = "alert-warning"; break;
                    case HataTip.hata: style = "alert-danger"; break;
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='form-msg alert " + style + "'>");
            sb.Append("<i class='fa fa-info-circle'></i><span>" + mesaj + "</span>");
            sb.Append("</div>");

            return sb.ToString();
        }

        private static string MailTemplateOlustur(string alici, string mesaj, bool linkVarmi, string link, string linkAciklama)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div style='margin:0px;padding:0px' dir='ltr'>");
            sb.Append("<table cellpadding='0' cellspacing='0' border='0' style='width:98%;background-color:#557eb0'>");
            sb.Append("<tbody>");
            sb.Append("<tr>");
            sb.Append("<td align='left' style='padding:2px 0 4px 8px'><a href='" + Prop.WebSiteUrl + "' style='text-decoration:none;color:#f8f8f8;font-family:Trebuchet MS,Arial' target='_blank'><span style='font-size:18px;font-weight:bold'>Prism Akademi</span></a></td>");
            sb.Append("</tr>");
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("<table cellpadding='0' cellspacing='0' border='0' style='width:98%;border-bottom:1px solid #3b5998;border-left:1px solid #ccc;border-right:1px solid #ccc' bgcolor='#ffffff'>");
            sb.Append("<tbody>");
            sb.Append("<tr>");
            sb.Append("<td bgcolor='white' width='*' align='left' valign='top' style='padding:18px 18px 18px 18px;font-size:9pt;font-family:Trebuchet MS,Arial;line-height:20px;letter-spacing:.2pt'>");
            sb.Append("Sayın <b>" + alici + "</b><br>");
            sb.Append("<br>");
            sb.Append(mesaj + "<br>");
            sb.Append("<br>");

            if (linkVarmi)
            {
                sb.Append("<table width='100%' cellspacing='0' cellpadding='0'>");
                sb.Append("<tbody>");
                sb.Append("<tr>");
                sb.Append("<td style='background-color:#fff8cc;border:1px solid #ffe222;padding:10px'>");
                sb.Append("<div style='font-weight:bold;margin-bottom:8px;font-size:11px'>" + linkAciklama + "</div>");
                sb.Append("<a href='" + link + "' style='color:#3b5998;font-size:11px' target='_blank'>" + link + "</a></td>");
                sb.Append("</tr>");
                sb.Append("</tbody>");
                sb.Append("</table>");
            }

            sb.Append("<div style='padding:12px 0 4px 0'><a href='" + Prop.WebSiteUrl + "' style='color:blue;text-decoration:none' target='_blank'>Prism Akademi</a></div>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</div>");

            return sb.ToString();
        }

        public static void EmailGonder(string alici, string eposta, string konu, string mesaj, bool linkVarmi, string link, string linkAciklama)
        {
            string gonderen = Prop.MailGonderen;

            if (String.IsNullOrEmpty(alici) || String.IsNullOrEmpty(gonderen))
            {
                return;
            }

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(gonderen);
                    mail.To.Add(eposta);
                    mail.Subject = konu;
                    mail.Body = MailTemplateOlustur(alici, mesaj, linkVarmi, link, linkAciklama);
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient();
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com";
                    string sifre = Prop.MailGonderenSifre;
                    smtp.Credentials = new NetworkCredential(gonderen, sifre);

                    smtp.Send(mail);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public enum HataTip
    {
        bilgi = 0,
        uyar = 1,
        hata = 2
    }
}