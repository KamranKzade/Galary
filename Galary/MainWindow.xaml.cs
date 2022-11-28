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
    public MainWindow()
    {
        InitializeComponent();
        GalaryImages = new();
        GalaryImages = Repository.FakeRepo.GetGalaryImages();

        foreach (var image in GalaryImages)
        {
            var picture = new BitmapImage(new Uri(image!.ImageUrl!, UriKind.Relative));


            UserControl_Photos photo = new(picture, image);
            wrapPanel.Children.Add(photo);

        }
    }
}
