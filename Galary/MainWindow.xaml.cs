using Galary.Models;
using Galary.UserControls;
using Galary.Windows;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Galary;



public partial class MainWindow : Window
{

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null!)
    {
        PropertyChangedEventHandler handler = PropertyChanged!;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(name));
        }
    }


    private ObservableCollection<GalaryImage> galaryImages;
    public ObservableCollection<GalaryImage> GalaryImages
    {
        get { return galaryImages; }
        set
        {
            galaryImages = value;
            OnPropertyChanged();
        }
    }


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


        Windows.PhotoWindow window = new(uc!.CurrentImageSource, uc.Photo, GalaryImages);

        window.ShowDialog();

    }

    private void MenuItem_Click(object sender, RoutedEventArgs e) => wrapPanel.Columns = 4;
    private void MenuItem_Click_1(object sender, RoutedEventArgs e) => wrapPanel.Columns = 2;


    private void Add_Image(object sender, RoutedEventArgs e)
    {
        Add_Image_Window add = new();
        add.ShowDialog();

        BitmapImage picture = new BitmapImage(new Uri(add.filePath!, UriKind.Relative));
        UserControl_Photos uc = new(picture, add.Image);

        wrapPanel.Children.Add(uc);
        GalaryImages.Add(add.Image);

    }
}