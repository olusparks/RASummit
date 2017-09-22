using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileData.Classes
{
    class TableObjects
    {
        public class Member
        {

            private int _id;

            public int ID
            {
                get { return _id; }
                set { _id = value; }
            }

            private string _memberID;

            public string MemberID
            {
                get { return _memberID; }
                set { _memberID = value; }
            }

            private string _memberName;

            public string MemberName
            {
                get { return _memberName; }
                set { _memberName = value; }
            }

            private string _userName;

            public string UserName
            {
                get { return _userName; }
                set { _userName = value; }
            }

            private string _password;

            public string Password
            {
                get { return _password; }
                set { _password = value; }
            }

            private int _tokenFk;

            public int TokenFk
            {
                get { return _tokenFk; }
                set { _tokenFk = value; }
            }

            private string _email;

            public string Email
            {
                get { return _email; }
                set { _email = value; }
            }

        }

        public class MembershipProfile
        {

            private int _id;

            public int ID
            {
                get { return _id; }
                set { _id = value; }
            }

            private string _memberID;

            public string MemberID
            {
                get { return _memberID; }
                set { _memberID = value; }
            }

            private string _membershipStartDate;

            public string MembershipStartDate
            {
                get { return _membershipStartDate; }
                set { _membershipStartDate = value; }
            }

            private string _membershipExpiryDate;

            public string MembershipExpiryDate
            {
                get { return _membershipExpiryDate; }
                set { _membershipExpiryDate = value; }
            }

            private string _address;

            public string Address
            {
                get { return _address; }
                set { _address = value; }
            }

            private string _oneYearPass;

            public string OneYearPass
            {
                get { return _oneYearPass; }
                set { _oneYearPass = value; }
            }

            private string _addedbyadmin;

            public string Addedbyadmin
            {
                get { return _addedbyadmin; }
                set { _addedbyadmin = value; }
            }

            private string _phone;

            public string Phone
            {
                get { return _phone; }
                set { _phone = value; }
            }

            //Phone
        }
    }
}
