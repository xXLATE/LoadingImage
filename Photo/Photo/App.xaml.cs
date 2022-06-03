using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Photo.DB;
using System.IO;

namespace Photo
{
    public partial class App : Application
    {
        public const string DB_NAME = "clientsProj.db";
        public static CRUDOperation db;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static CRUDOperation Db
        {
            get
            {
                if (db == null)
                {
                    db = new CRUDOperation(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DB_NAME));
                }
                return db;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
