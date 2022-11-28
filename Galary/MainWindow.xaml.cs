using Galary.Models;
using Galary.UserControls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Galary;



public partial class MainWindow : Window
{
    public List<GalaryImage> GalaryImages { get; set; }
    public BitmapImage CurrentPicture { get; set; }


    public MainWindow()
    {
        InitializeComponent();
        GalaryImages = new();
        GalaryImages = Repository.FakeRepo.GetGalaryImages();


        foreach (var image in GalaryImages)
        {
            BitmapImage picture = new BitmapImage(new Uri(image!.ImageUrl!, UriKind.Relative));
            CurrentPicture = picture;


            UserControl_Photos photo = new(picture, image);
            wrapPanel.Children.Add(photo);

            photo.MouseDoubleClick += Photo_MouseDoubleClick;
        }


    }


    private void Photo_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        var uc = sender as UserControl_Photos;


        Windows.PhotoWindow window = new(uc.CurrentImageSource, uc.Photo, GalaryImages);

        window.ShowDialog();

    }

}