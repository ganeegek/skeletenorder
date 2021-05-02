using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class clsOrder
    {
        public clsOrder()
        {

        }
        public string error = "";
        private SqlConnection con;

        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Quantity { get; set; }

        public string Valid(string mDescription)
        {
            if (mDescription.Length < 1)
            {
                return "Description cannot be blank";
            }
            if (mDescription.Length > 50)
            {
                return "Description cannot be more than 50 characters";
            }
            else
            {
                return "";

            }
        }

        public string LoginValid(string username, string password)
        {
            if(username.Length <= 0 &&  password.Length <= 0)
            {
                return "Please Enter Your Credentials";
            }

            if (username.Length <= 0)
            {
                return "Please Enter you Email";
            }

            if (password.Length <= 0)
            {
                return "Please Enter you Password";                
            }
            else
            {
                return "";
            }
        }

        public string RegisterValid(string name, string address, string city, string postcode, string mobile, string email, string password)
        {
            
            if (name.Length <= 0 && address.Length <= 0 && city.Length <= 0 && postcode.Length <= 0 && mobile.Length <= 0 && email.Length <= 0 && password.Length <=0)
            {
                 return "Please Enter Your Credentials";
            }        
                return error;
        }

        public bool GetStudent(string email)
        {
            return true;
        }

        public string RegName(string name)
        {
            if (name.Length <= 0)
            {
                return  "Please Enter you Name ";
            }

            int myDec;
            var Result = int.TryParse(name, out myDec);

            if (!Result)
            {
                if (name.Length >= 3 && name.Length <= 20)
                {
                    return "";
                }

                if (name.Length < 3)
                {
                    return "Please Enter atleast 3 Character Name";
                }
                if (name.Length > 20)
                {
                    return "Please Enter Must be 20 character Name";
                }
                return "";
            }
            else
            {
                return "Please Enter Character only";
            }
        }

        public string RegAddress(string address)
        {
            if (address.Length <= 0)
            {
                return "Please Enter you Address ";
            }


            int myDec;
            var Result = int.TryParse(address, out myDec);

            if (!Result)
            {
                if (address.Length >= 6 && address.Length <= 50)
                {
                    return "";
                }

                if (address.Length < 6)
                {
                    return "Please Enter atleast 6 Character Address";
                }
                if (address.Length > 51)
                {
                    return "Please Enter Must be 50 character Address";
                }
                return "";
            }
            else
            {
                return "Please Enter Character only";
            }
        }
        public string RegCity(string city)
        {

            if (city.Length <= 0)
            {
                return "Please Enter you City ";
            }


            int myDec;
            var Result = int.TryParse(city, out myDec);

            if (!Result)
            {
                if (city.Length >= 4 && city.Length <= 15)
                {
                    return "";
                }

                if (city.Length < 4)
                {
                    return "Please Enter atleast 4 Character City";
                }
                if (city.Length > 15)
                {
                    return "Please Enter Must be 15 Character City";
                }
                return "";
            }
            else
            {
                return "Please Enter Character only";
            }
        }
        public string RegPostCode(string postcode)
        {
            if (postcode.Length <= 0)
            {
                return "Please Enter you Pincode ";
            }

            int myDec;
            var Result = int.TryParse(postcode, out myDec);

            if (Result)
            {
                if (postcode.Length >= 5 && postcode.Length <= 7)
                {
                    return "";
                }

                if (postcode.Length < 5)
                {
                    return "Please Enter atleast 5 Digit PinCode";
                }
                if (postcode.Length > 7)
                {
                    return "Please Enter Must be 7 Digit PinCode";
                }
                return "";
            }
            else
            {
                return "Please Enter Digit only";
            }
        }
        public string RegMobile(string mobile)
        {
            if (mobile.Length <= 0)
            {
                return "Please Enter you Mobile ";

            }
            decimal myDec;
            var Result = decimal.TryParse(mobile, out myDec);

            if (Result)
            {
                if (mobile.Length >= 9 && mobile.Length <= 12)
                {
                    return "";
                }

                if (mobile.Length < 9)
                {
                    return "Please Enter atleast 9 Digit Mobile Number";
                }
                if (mobile.Length > 12)
                {
                    return "Please Enter Must be 12 Digit Mobile Number";
                }
                return "";
            }
            else
            {
                return "Please Enter Digit only";
            }
        }
        public string RegPassword(string password)
        {
            if (password.Length <= 0)
            {
                return "Please Enter you Password ";

            }

            int myDec;
            var Result = int.TryParse(password, out myDec);

            if (!Result)
            {
                if (password.Length >= 5 && password.Length <= 15)
                {
                    return "";
                }

                if (password.Length < 5)
                {
                    return "Please Enter atleast 5 Character Password";
                }
                if (password.Length > 15)
                {
                    return "Please Enter Must be 15 character Password";
                }
                return "";
            }
            else
            {
                return "Please Enter Character only";
            }
        }
        public string RegEmail(string email)
        {
            if (email.Length <= 0)
            {
               return "Please Enter you Email ";
            }

            int myDec;
            var Result = email.Contains("@gmail.com");

            if (Result)
            {
                return "";
            }
            else
            {
                return "Please Enter Email format only";
            }
        }

        public bool CheckQuantityValid(string quantity)
        {
            int myQuant;
            var Result = int.TryParse(quantity, out myQuant);
            if (Result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }


}