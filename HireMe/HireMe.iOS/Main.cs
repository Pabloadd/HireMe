using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace HireMe.iOS
{
    using Data;
    using System.IO;

    public class Application
    {
        // This is the main entry point of the application.
        static HmDatabase database;
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }

        public static HmDatabase Database 
        {
            get
            {
                if (database == null)
                {
                    database = new HmDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "hmdbproject.db3"));
                }
                return database;
            }
        }
    }
}
