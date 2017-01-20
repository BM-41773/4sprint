using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace mysrves
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
       [OperationContract]
        string Login(string X_emailaddress, string X_passwd);
        [OperationContract]
        string Signupmethod(string X_Firstname, string X_Surname, string X_propic, string X_Email, string X_supPassword, DateTime DT_SUPdob, string X_Gender);
        [OperationContract]
        void loginId(string X_Email, string X_password,out string X_logginid,  out string temp, out string X_F, out string X_Snme, out string X_prop );
        [OperationContract]
        string serchtype(string X_Firstname);
        [OperationContract]
        void frnds(string X_reciverid, string X_senderid);

        [OperationContract]
        string approvelfrnd( string X_senderid,string X_reciverid);
        [OperationContract]
        void conform(string X_senderid, string X_reciverid);
        [OperationContract]
        void mailconform(string X_reciverid);
        [OperationContract]
        void dlete(string X_reciverid, string X_senderid);
        [OperationContract]
        string frndsrch(string loginid);
         [OperationContract]
        void unfrnd(string X_reciverid, string X_senderid);
 }

    public class Logginuser
    {
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public string Profilepic { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Emailadress { get; set; }
        [DataMember]
        public int LoginID { get; set; }
        [DataMember]
        public string X_LoginID { get; set; }
        [DataMember]
        public string Message { get; set; }

    }
    public class signup
    {
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public string Profilepic { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string supPassword { get; set; }
        [DataMember]
        public DateTime DT_dob { get; set; }
        [DataMember]
        public string Gender { get; set; }


    }
    public class serch
    {
        [DataMember]
        public string Firstname { get; set; }
    } 

}
