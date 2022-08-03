using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromCSVLinqExample
{
    class Program
    {
        static void Main(string[] args)
        {
         
            IEnumerable<PatientInfo> resultlist = Program.GetAllPatients().Where(m => m.Age > 36);

            foreach(PatientInfo p in resultlist)
            {
                Console.WriteLine($"{p.MRN}, {p.Name}, {p.Age}, {p.ContactNumber}, {p.Email}");
            }

            Console.ReadKey();
        }

        public static List<PatientInfo> GetAllPatients()
        {
            string[] readcsvlines = System.IO.File.ReadAllLines(@"C:\Users\320019984\source\repos\CSV\CsharpThoughtProcess\patients.csv");
           
            List<PatientInfo> resultpatientinfo = new List<PatientInfo>();

            for (int i = 1; i < readcsvlines.Length; i++)
            {
                //Program.GetAllPatients(readcsvlines[i]);
                PatientInfo info = new PatientInfo();
                string rawcsvdata = readcsvlines[i];
                string[] data = rawcsvdata.Split(',');
                for (int p = 0; p < data.Length; p++)
                {     
                    info.MRN = Convert.ToString(data[0]);
                    info.Name = data[1];
                    info.Age = Convert.ToInt32(data[2]);
                    info.ContactNumber = Convert.ToString(data[3]);
                    info.Email = data[4];

                    
                }

                resultpatientinfo.Add(info);
            }
            return resultpatientinfo;
            
           
        }
    }

    public class PatientInfo
    {
        public string MRN { get; set; }
        //Auto implemented Properties
        public string Name { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }


}
