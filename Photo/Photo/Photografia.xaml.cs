using Photo.DataPhoto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Photo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Photografia : ContentPage
    {
        readonly PhotoCopy phot;

        public Photografia(PhotoCopy phot)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.phot = phot;
            name.Text = phot.Name;
            img.Source = phot.Imagepath;
        }
    }
}