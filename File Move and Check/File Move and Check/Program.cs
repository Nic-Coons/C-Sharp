using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Configuration;

using System.IO;

namespace File_Move_and_Check
{
    
    
    public class Program
    {

        public class FileMoving
        {
            public string from { get; set; }
            public string to { get; set; }

            public void fileMove(string[] files)
            {
                foreach (string s in files)
                {
                    System.IO.FileInfo fil = new System.IO.FileInfo(s);
                    bool check2 = (DateTime.Now - fil.CreationTime).TotalHours < 24;
                    if (check2 == true)
                    {
                        string ss = Path.GetFileName(s);
                        string destination = to + "\\" + ss;
                        File.Copy(s, destination);
                        Console.WriteLine("Moved " + ss + " to " + destination);
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            FileMoving fm = new FileMoving();
            //string to = "C:\\Users\\Nic\\Desktop\\Drops";
            //string from = "C:\\Users\\Nic\\Desktop\\Holds";
            string from = ConfigurationManager.AppSettings["from"].ToString();
            string to = ConfigurationManager.AppSettings["to"].ToString();
            fm.from = from;
            fm.to = to;
            string[] files = Directory.GetFiles(from);

            fm.fileMove(files);
            //foreach (string s in files)
            //{
            //    System.IO.FileInfo fil = new System.IO.FileInfo(s);
            //    bool check2 = (DateTime.Now - fil.CreationTime).TotalHours < 24;
            //    if (check2 == true)
            //    {
            //        try
            //        {
            //            string ss = Path.GetFileName(s);
            //            string destination = to + "\\" + ss;
            //            File.Copy(s, destination);
            //            Console.WriteLine("Moved " + ss + " to " + destination);
            //        }
            //        catch (IOException ex)
            //        {
            //            Console.WriteLine(ex); // Write error
            //        }
            //    }                                       
            //}
            Console.ReadLine();

            if (!System.IO.Directory.Exists(to))
            {
                System.IO.Directory.CreateDirectory(to);
            }


        }

        
    }
    
    
    
    
}
