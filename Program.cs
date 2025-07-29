using Business_Layer;
using System;
using System.Data;
using System.Globalization;

namespace Presentation_Data_Layer
{
    internal class Program
    {
        public static void Print(int ID)
        {
            ClsBusiness_layer contact = ClsBusiness_layer.Find_Contact(ID);
            if (contact != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Contact ID         : {0}", contact.ID);
                Console.WriteLine("First Name         : {0}", contact.FiratName);
                Console.WriteLine("Last Name          : {0}", contact.LatName);
                Console.WriteLine("Email              : {0}", contact.Email);
                Console.WriteLine("Phone              : {0}", contact.PhoneNumber);
                Console.WriteLine("Address            : {0}", contact.Address);
                Console.WriteLine("Date of Birth      : {0:dd-MM-yyyy}", contact.DateOfBirth);
                Console.WriteLine("Country ID         : {0}", contact.CountryID);
                Console.WriteLine("Image Path         : {0}", contact.ImagPath);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("❌ Contact not found.");
            }
        }

        public static ClsBusiness_layer Get_Data()
        {
            ClsBusiness_layer data = new ClsBusiness_layer();

            Console.Write("Enter First Name: ");
            data.FiratName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            data.LatName = Console.ReadLine();

            Console.Write("Enter Email: ");
            data.Email = Console.ReadLine();

            Console.Write("Enter Phone: ");
            data.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Address: ");
            data.Address = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter Date of Birth (dd-MM-yyyy): ");
                string input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "d-M-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob))
                {
                    data.DateOfBirth = dob;
                    break;
                }
                Console.WriteLine("❌ Invalid date format.");
            }

            Console.Write("Enter Country ID: ");
            data.CountryID = int.Parse(Console.ReadLine());

            Console.Write("Enter Image Path: ");
            data.ImagPath = Console.ReadLine();

            return data;
        }

        public static void Test_Add_Contact()
        {
            ClsBusiness_layer data = Get_Data();

            if (data != null && data.Save())
            {
                Console.WriteLine("✅ Data saved successfully.");
                Print(data.ID);
            }
        }

        public static void Start_To_Update_data(int ID)
        {
            ClsBusiness_layer oldData = ClsBusiness_layer.Find_Contact(ID);

            if (oldData != null)
            {
                Console.WriteLine("⚠️ Current contact data:");
                Print(ID);

                ClsBusiness_layer newData = Get_Data();
                newData.ID = ID;

                if (newData.Save())
                {
                    Console.WriteLine("✅ Contact updated successfully.");
                    Print(ID);
                }
                else
                {
                    Console.WriteLine("❌ Update failed.");
                }
            }
            else
            {
                Console.WriteLine("❌ Contact with ID not found.");
            }
        }

        public static int GetContactID()
        {
            int contactID;
            do
            {
                Console.Write("Enter Contact ID: ");
            } while (!int.TryParse(Console.ReadLine(), out contactID) || contactID <= 0);

            return contactID;
        }
        public static void  Delete_Contact(int  Contact_ID)
        {
            if (ClsBusiness_layer.Delete_Contact(Contact_ID))
            {
                Console.WriteLine("Deleted Sucsful "); 
            }
            else
            {
                Console.WriteLine("deleted feild  "); 
            }
        }


        public static void Get_All_Data()
        {
            DataTable dt = ClsBusiness_layer.Get_All_Data();
            Console.WriteLine("Data  Contact ");
            Console.WriteLine(new string('_', 20)); 
            foreach (DataRow row in dt.Rows)
            {

                Console.WriteLine($"{row["ContactID"]} |{row["FirstName"]}|{row["LastName"]}|{row["Email"]}|{row["Phone"]}|{row["Address"]} | {row["DateOFBirth"]} | {row["CountryID"]}|{row["ImagePath"]} \n");
            }

        }

        public static void Is_Exsit(int  ContactID)
        {
            if (ClsBusiness_layer.IS_exists(ContactID))
            {
                Console.WriteLine("Yes  Is found "); 
            }
            else
            {
                Console.WriteLine("Not  Found  "); 
            }
        }
        static void Main(string[] args)
        {

        }
    }
}
