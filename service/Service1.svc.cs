using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;



namespace mysrves
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void DoWork()
        {
        }
        public string Login(string X_emailaddress, string X_passwd)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-46KB8VH\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from loginuser where Email='" + X_emailaddress + "' and supPassword='"+X_passwd+"'";
            //  cmd.Dispose();
            //con.Close();
            SqlDataReader rdr = cmd.ExecuteReader();
            Logginuser logg = new Logginuser();
            logg.Emailadress = X_emailaddress;
            logg.Password = X_passwd;
            try
            {
                while (rdr.Read())
                {
                    if ((logg.Emailadress.Equals(rdr["Email"].ToString())) && (logg.Password.Equals(rdr["supPassword"].ToString())))
                    {
                        logg.Firstname = rdr["Firstname"].ToString();
                        logg.Lastname = rdr["Surname"].ToString();
                        logg.Emailadress = rdr["Email"].ToString();
                        logg.LoginID = Convert.ToInt32(rdr["LogginId"].ToString());
                        logg.X_LoginID = logg.LoginID.ToString();
                        logg.Profilepic = rdr["Profilepic"].ToString();
                        string str = "LoginId:" + logg.LoginID + "Firstname:" + logg.Firstname + "Surname:" + logg.Lastname + "Profilpic:" + logg.Profilepic + "Responsecode:200 Message:success";
                        return str;


                    }

                    else if ((logg.Emailadress.Equals(rdr["Email"].ToString())) && (!(logg.Password.Equals(rdr["suppassword"].ToString()))))
                    {
                        logg.Firstname = rdr["Firstname"].ToString();
                        logg.Lastname = rdr["Surname"].ToString();
                        logg.Emailadress = rdr["Email"].ToString();
                        logg.LoginID = Convert.ToInt32(rdr["LogginId"].ToString());
                        logg.X_LoginID = logg.LoginID.ToString();
                        logg.Profilepic = rdr["Profilepic"].ToString();
                        string str = "Responsecode;404 Message;Password incorrect";
                        return str;
                    }
                    else if (!(logg.Emailadress.Equals(rdr["Email"].ToString())) && ((logg.Password.Equals(rdr["supPassword"].ToString()))))
                    {
                        logg.Firstname = rdr["Firstname"].ToString();
                        logg.Lastname = rdr["Surname"].ToString();
                        logg.Emailadress = rdr["Email"].ToString();
                        logg.LoginID = Convert.ToInt32(rdr["LogginId"].ToString());
                        logg.X_LoginID = logg.LoginID.ToString();
                        logg.Profilepic = rdr["Profilepic"].ToString();

                        string str = "\"Username:\"" + logg.Emailadress + " Responsecode;500 Message;Email id doesnot exist";
                        return str;
                    }
                }
            }
            catch (Exception ec)
            {

                // SendError(ec);
            }

            return null;

        }
        public void loginId(string X_Email, string X_password, out string temp, out string X_logginid, out string X_F, out string X_Snme, out string X_prop)
        {
            temp = "";
            X_F = "";
            X_Snme = "";
            X_prop = "";
            X_password = "";
            X_logginid = "";

            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-46KB8VH\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            cn.Open();
            SqlCommand md = cn.CreateCommand();
            md.CommandText = "select LogginId,Firstname,Surname,Profilepic from loginuser  where Email= '" + X_Email + "'";
            SqlDataReader rdr = md.ExecuteReader();


            while (rdr.Read())
            {
                X_logginid = rdr["LogginId"].ToString();
                X_F = rdr["Firstname"].ToString();
                X_Snme = rdr["Surname"].ToString();
                X_prop = rdr["Profilepic"].ToString();


            }

        }




        public string Signupmethod(string X_Firstname, string X_Surname, string X_propic, string X_Email, string X_supPassword, DateTime DT_SUPdob, string x_Gender)
        {
            FileUpload FL1 = new FileUpload();
            String myprofpic = "D:\\profpic\\" + X_propic;
            FL1.SaveAs(myprofpic);

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-46KB8VH\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            string str;
            con.Open();
            signup sign = new signup();
            sign.Firstname = X_Firstname;
            sign.Lastname = X_Surname;

            sign.Profilepic = myprofpic;
            sign.Email = X_Email;

            sign.supPassword = X_supPassword;
            sign.DT_dob = DT_SUPdob;
            sign.Gender = x_Gender;
            str = "insert into loginuser(Firstname,Surname,Profilepic,Message,supPassword,Email,DT_dob,Gender,Accountstatus) values('" + sign.Firstname + "', '" + sign.Lastname + "','" + sign.Profilepic + "','hi', '" + sign.supPassword + "' ,'" + sign.Email + "','" + sign.DT_dob + "', '" + sign.Gender + "',0)";
            SqlCommand snd = new SqlCommand(str, con);
            int res = snd.ExecuteNonQuery();
            if (res > 0)
            {


                sendmail();



                return ("success");
            }
            else
            {
                return ("fail");
            }
            con.Close();
            snd.Dispose();
            return null;
        }

        public void sendmail()
        {



            //string mail = Frommail.Text;
            // string fun = Tomail.Text;
            //string sub = Subjectmail.Text;
            // string bdy = documail.Text;


            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("snehasne517@gmail.com");
            msg.To.Add("snehasne517@gmail.com");
            //msg.Subject = sub;
            // msg.Body = bdy;
            msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential("snehasne517@gmail.com", "snehaanil");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(msg);
            }



            catch (Exception ex)
            {

            }
        }
        public string serchtype(string X_Firstname)
        {
            // int N_loginid = Convert.ToInt32(x_logginid);
            SqlConnection co = new SqlConnection("Data Source=DESKTOP-46KB8VH\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            co.Open();
            SqlCommand cn = co.CreateCommand();
            //cn.CommandText="select Accountstatus from loginuser   where N_logginid ='"+N_loginid+"'" ;
            //SqlDataReader sdr = cn.ExecuteReader();
            //int Accountstatus = 0;
            //while(sdr.Read())
            //{
            //    Accountstatus = Convert.ToInt32(sdr["N_logginid"].ToString());

            //}
            cn.CommandText = "select  loginuser.LogginId,loginuser.Firstname,loginuser.Surname,loginuser.Profilepic,frndconform.N_logginid,frndconform.relation,frndconform.sender,frndconform.FCFirstname,frndconform.FCSurname,frndconform.FCProfilepic,frndconform.reciver from loginuser LEFT OUTER JOIN    on loginuser.LogginId=frndconform.reciver where loginuser.Firstname like '" + X_Firstname + "%' order by frndconform.reciver desc ";
            //cn.CommandText = "select Firstname,Surname,Profilepic from loginuser where  Firstname like'" + X_Firstname + "%'";
            //  cn.CommandText = "select loginuser.LogginId,loginuser.Firstname,loginuser.Surname,loginuser.Profilepic,frndconform.N_logginid,frndcomform.relation,frndconform.sender,frondconform.FCFirstname,frndconform.FCSurname,frndconform.FCProfilepic,frndconform,reciver from loginuser LEFT OUTER JOIN frndcoform on loginuser.LogginId=frndconform.reciver where loginuser.Firtname like '" + X_Firstname + "%' order by frndconform.reciver desc";
            SqlDataReader rdr = cn.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            string str = datatabletojson(dt);
            return str;

            //string f1 = rdr["Firstname"].ToString();
            //string s1 = rdr["Surname"].ToString();
            //string p1 = rdr["Profilepic"].ToString();
            // return "select Firstname,Surname,Profilepic from Userlogin where  Firstname='" + X_Firstname + "'";


        }

        public string datatabletojson(DataTable table)
        {
            return JsonConvert.SerializeObject(table);
        }

        public void frnds(string X_reciverid, string X_senderid)
        {
             int N_reciverid = Convert.ToInt32(X_reciverid);
            int N_senderid = Convert.ToInt32(X_senderid);
           
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-46KB8VH\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");

            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandText = "update  loginuser set  Accountstatus=2 where LogginId=" + N_senderid;
            cnd.ExecuteNonQuery();
            cnd.CommandText = "select Firstname,Surname,Profilepic from  loginuser where LogginId='" + N_reciverid + "'";
            SqlDataReader rdr = cnd.ExecuteReader();
            string fname = "";
            string sname = "";
            string propic = "";
            while (rdr.Read())
            {
                fname = rdr["Firstname"].ToString();
                sname = rdr["Surname"].ToString();
                propic = rdr["Profilepic"].ToString();
            }
            rdr.Close();
            cnd.CommandText = "insert into frndconform (N_logginid,relation,sender,FCFirstname,FCSurname,FCProfilepic,reciver,FCstatus)values('" + X_senderid + "' ,'" + 0 + "','" + X_senderid + "','" + fname + "','" + sname + "','" + propic + "','" + X_reciverid + "','" + "" + "')";
           cnd.ExecuteNonQuery();


        }
        public void  conform(string X_senderid,string X_reciverid)
        {
            int N_senderid=Convert.ToInt32(X_senderid);
            int N_reciverid=Convert.ToInt32(X_reciverid);
             SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-46KB8VH\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
             con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandText = "update  frndconform set FCstatus=1 where sender=" + N_senderid + " and reciver=" + N_reciverid;
            cnd.ExecuteNonQuery();
            
        //public string delt(string X_reciverid)
        //{
        //   // int N_senderid = Convert.ToInt32(X_senderid);
        //    int N_reciverid = Convert.ToInt32(X_reciverid);
        //    SqlConnection con = new SqlConnection("Data Source=DESKTOP-46KB8VH\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
        //    con.Open();
        //    SqlCommand cnd = con.CreateCommand();
        //    cnd.CommandText = "update frndconform set FCstatus=1 where reciver=" + X_reciverid;
        //    cnd.ExecuteNonQuery();
           
            mailconform( X_reciverid);
        }
        public string approvelfrnd( string X_senderid,string X_reciverid)
        {
            int N_reciverid = Convert.ToInt32(X_reciverid);
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-46KB8VH\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandText = "select loginuser.LogginId,loginuser.Firstname,loginuser.Surname,loginuser.Profilepic,frndconform.relation,frndconform.FCstatus from loginuser LEFT OUTER JOIN frndconform on frndconform.reciver= " + N_reciverid + " where loginuser.LogginId=frndconform.sender order by frndconform.reciver desc";
           SqlDataReader sdr = cnd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            string str = datatabletojson(dt);
            return str;

        }
        string fname, sname, propics;
        public void mailconform(string X_reciverid)
        {
            int N_reciverid = Convert.ToInt32(X_reciverid);
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-46KB8VH\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandText = "select Firstname,Surname, Profilepic from loginuser where LogginId=" + N_reciverid;
            SqlDataReader sdr = cnd.ExecuteReader();
            while(sdr.Read())
            {
                fname = sdr["Firstname"].ToString();
                sname = sdr["Surname"].ToString();
                propics = sdr["Profilepic"].ToString();
                 MailMessage msg = new MailMessage();
            msg.From = new MailAddress("snehasne517@gmail.com");
            msg.To.Add("harishmahari1502@gmail.com");
            //msg.Subject = sub;
            // msg.Body = bdy;
            msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential("snehasne517@gmail.com", "snehaanil");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(msg);
            }



            catch (Exception ex)
            {

            }
        }

            }
        public void dlete(string X_reciverid,string X_senderid)
        {
            int N_reciverid = Convert.ToInt32(X_reciverid);
            int N_senderid = Convert.ToInt32(X_senderid);
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-46KB8VH\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandText = "delete from frndconform where reciver=" + N_reciverid + " and sender=" + N_senderid;

            cnd.ExecuteNonQuery();
        }
        public string frndsrch(string loginid)
        {
            int Nloginid = Convert.ToInt32(loginid);
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-46KB8VH\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandText = "select loginuser.LogginId,loginuser.Firstname,loginuser.Surname,loginuser.Profilepic,frndconform.relation,frndconform.sender,frndconform.reciver, frndconform.FCFirstname,frndconform.FCSurname,frndconform.FCProfilepic from loginuser LEFT OUTER JOIN frndconform on loginuser.LogginId = frndconform.reciver where frndconform.reciver=" + Nloginid + "   order by frndconform.reciver desc";
           // cnd.Connection = con; //SqlDataReader sdr = cnd.ExecuteReader();
            SqlDataAdapter adr = new SqlDataAdapter(cnd);
            DataTable dt = new DataTable();
            adr.Fill(dt);
            string str = datatabletojson(dt);
            return str;
        }
        public void unfrnd(string X_reciverid,string X_senderid)
        {
            int Nreciverid = Convert.ToInt32(X_reciverid);
            int Nsenderid = Convert.ToInt32(X_senderid);
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-46KB8VH\\SQLEXPRESS;Initial Catalog=facebooklogin;Integrated Security=True");
            con.Open();
            SqlCommand cnd = con.CreateCommand();
            cnd.CommandText = "delete from frndconform where reciver=" + Nreciverid + " and sender=" + Nsenderid;

            cnd.ExecuteNonQuery();

        }

        }
        }


    


