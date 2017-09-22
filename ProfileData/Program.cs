using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfileData.Classes;

namespace ProfileData
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetMembers();
            GetMembership();

        }


        public static void GetMembers()
        {
            //string memberID, memberName, userName, password, email = string.Empty;

            TableObjects.Member atran = new TableObjects.Member();

            try
            {
                Console.Write("Enter your Name: ");
                atran.MemberName = Console.ReadLine();

                Console.Write("Enter your UserName: ");
                atran.UserName = Console.ReadLine();

                Console.Write("Enter your Password: ");
                atran.Password = Console.ReadLine();

                Console.Write("Enter your Email: ");
                atran.Email = Console.ReadLine();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("==============================Details for " + atran.MemberName + "======================");
                Console.ResetColor();

                //Generate MemberID
                atran.MemberID = SharedFunctions.GenerateMemberID();

                //Hash Password
                SharedFunctions.Hash(atran.Password);

                //Print Details
                
                Console.WriteLine(" MemberID: {0} \n Name: {1} \n UserName: {2} \n Password(Hashed): {3} \n Email: {4}", atran.MemberID, atran.MemberName, atran.UserName, SharedFunctions.Hash(atran.Password), atran.Email);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new Exception(e.Message));
            }

            //As a member, you have discount and perform some functions on the portal
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===================================Your Operations ==================================");
            Console.ResetColor();

            //Handle Member Operations
            MemberOperations();

            Console.WriteLine();
            Console.ReadLine();
        }

        //Operations a member can perform
        public static void MemberOperations()
        {
            try
            {
                Console.WriteLine("As a member, you have discount and can perform some functions on the portal");

                Console.WriteLine();
                //create an array of the function you can perform
                string[] functions = { "Browse Gallery", "Buy Artwork", "Make Enquiry", "Leave Feedback", "Do you want to know when your membership expires?" };

                Console.WriteLine("This is a list of what you can do on our portal Select one at a time. \n 1 >> {0} \n 2 >> {1} \n 3 >> {2} \n 4 >> {3} \n 5 >> {4}", functions[0], functions[1], functions[2], functions[3], functions[4]);
                Console.WriteLine();

                while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.Write("Select an opertion by the number: ");
                    Console.WriteLine();

                    int selectedValue;
                    bool IsNumber = int.TryParse(Console.ReadLine(), out selectedValue); //Int32.Parse(Console.ReadLine());

                    if (IsNumber && (selectedValue > 0 && selectedValue <= 5))
                    {
                        switch (selectedValue)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Please wait while we load the atrworks...");
                                Console.WriteLine("Hey! This is a list of our artwork");
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Buy Artwork");
                                Console.WriteLine("You will be redirected to ur payment page.\nThanks for purchasing this item.");
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Please leave your message: ");
                                string msg = Console.ReadLine();
                                Console.WriteLine("Your message has been sent to the admin. We will get back to you shortly. Thanks");
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("Please leave your feedback: ");
                                string msgfeedback = Console.ReadLine();
                                Console.WriteLine("Your message has been sent to the admin. We will get back to you shortly.  \n Thanks for your feeback");
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("This will be sent to your mail. Thanks");
                                break;
                            default:
                                return;
                        }  
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Please your selection is out of range or is not a number");
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new Exception(e.Message));
                Console.ResetColor();
            }
        }

        public static void GetMembership()
        {
            TableObjects.MembershipProfile atran = new TableObjects.MembershipProfile();

            try
            {
                string memID = SharedFunctions.GenerateMemberID();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please type the MemberID as your memberID: {0}", memID);
                Console.WriteLine();
                Console.ResetColor();

                Console.Write("Enter your MemberID: ");
                atran.MemberID = Console.ReadLine();

                //Search the database for the number: We will use a static number generated by our MemberIDGenerator
                if (atran.MemberID == memID)
                {
                    //Handle MemberExpiryDate
                    var atran1 = SetMembershipExpiryDate(atran);


                    Console.Write("Enter your Phone: ");
                    atran.Phone = Console.ReadLine();

                    Console.Write("Enter your Address: ");
                    atran.Address = Console.ReadLine();

                    atran.Addedbyadmin = Environment.UserName;

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("==============================Membership Details for " + atran.MemberID + "======================");
                    Console.ResetColor();

                    //Print Details
                    Console.WriteLine(" MemberID: {0} \n Membership Validity: {1} --- {2} \n Membership Subscription: {3} year(s) \n Address: {4} \n Phone: {5}  \n AddedBy: {6}", atran.MemberID, atran1.MembershipStartDate, atran1.MembershipExpiryDate, atran1.OneYearPass, atran.Address, atran.Phone, atran.Addedbyadmin);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Incorrect MemberID");
                    Console.ResetColor();
                }
                
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine( new Exception(e.Message) );
                Console.ResetColor();
            }
            Console.ReadLine();
        }

        //Handle MemberExpiryDate
        public static TableObjects.MembershipProfile SetMembershipExpiryDate(TableObjects.MembershipProfile atran)
        {
            try
            {

                DateTime membershipStartDate = DateTime.Now;
                DateTime membershipExpiryDate = membershipStartDate.AddYears(1);

                
                int StartYear = membershipStartDate.Year;
                int ExpiryYear = membershipExpiryDate.Year;

                atran.OneYearPass = (ExpiryYear - StartYear).ToString();

                atran.MembershipStartDate = DateTime.Now.ToShortDateString();
                atran.MembershipExpiryDate = membershipStartDate.AddYears(1).ToShortDateString();

                return atran;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new Exception(e.Message));
                Console.ResetColor();
                return null;
            }
        }
    }
}
