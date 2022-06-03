using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Photo.DataPhoto;
using System.Diagnostics;
using System.IO;
using Xamarin.Essentials;


namespace Photo
{
    public partial class MainPage : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string impath;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        async void gallery_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                impath = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        async void camera_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });
                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                Debug.WriteLine($"Путь фото {photo.FullPath}");
                impath = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Update();
        }

        public void Update()
        {
            imageList.ItemsSource = null;
            imageList.ItemsSource = App.Db.GetProjects();
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.db.SaveItem(new PhotoCopy(name.Text, impath));
                DisplayAlert("", "Обьект успешно добавлен", "Ok");
                Update();
            }
            catch
            {
                DisplayAlert("", "Не удалось добавить обьект", "Ok");
            }
        }

        private void SwipeItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var id = ((SwipeItem)sender).CommandParameter.ToString();
                App.Db.DeleteItem(int.Parse(id));
                Update();
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "ok");
            }
        }

        private void image_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new Photografia((PhotoCopy)e.Item));
        }

        
    }
}
