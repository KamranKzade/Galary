using Galary.Models;
using Galary.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Galary.Windows;



public partial class PhotoWindow : Window
{
    public DispatcherTimer Timer { get; set; }

    public UserControl_Photos user { get; set; }
    public ObservableCollection<GalaryImage> Galaries { get; set; }



    public PhotoWindow(ImageSource image, GalaryImage page, ObservableCollection<GalaryImage> GalaryImages)
    {
        InitializeComponent();
        Timer = new();


        Galaries = new();
        Galaries = GalaryImages;

        UserControl_Photos photo = new(image, page);

        user = photo;
        mygrid.Children.Add(photo);
    }

    private void Button_Click(object sender, RoutedEventArgs e) => Close();

    private void Previous_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;


        switch (btn!.Name)
        {
            case "Previous":

                try
                {
                    UserControl_Photos photo = new(new BitmapImage(new Uri(Galaries[Galaries.IndexOf(user.Photo) - 1]!.ImageUrl!, UriKind.Relative)), Galaries[Galaries.IndexOf(user.Photo) - 1]);
                    user = photo;

                    mygrid.Children.Add(photo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

                break;
            case "Pause":
                Timer.Stop();
                break;
            case "Play":

                Timer.Interval = TimeSpan.FromMilliseconds(2000);
                Timer.Tick += Timer_Tick;
                Timer.Start();

                break;
            case "Next":

                try
                {
                    UserControl_Photos photo = new(new BitmapImage(new Uri(Galaries[Galaries.IndexOf(user.Photo) + 1]!.ImageUrl!, UriKind.Relative)), Galaries[Galaries.IndexOf(user.Photo) + 1]);
                    user = photo;

                    mygrid.Children.Add(photo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

                break;

        }

    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        try
        {
            UserControl_Photos photo = new(new BitmapImage(new Uri(Galaries[Galaries.IndexOf(user.Photo) + 1]!.ImageUrl!, UriKind.Relative)), Galaries[Galaries.IndexOf(user.Photo) + 1]);
            user = photo;

            mygrid.Children.Clear();
            mygrid.Children.Add(photo);


        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Timer.Stop();
        }
    }
}