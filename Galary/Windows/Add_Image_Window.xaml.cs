using Galary.Models;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Galary.Windows;


public partial class Add_Image_Window : Window
{
    public GalaryImage Image { get; set; }
    public string filePath { get; set; }


    public Add_Image_Window()
    {
        InitializeComponent();
        Image = new GalaryImage();
    }



    private void Add_Image_Button(object sender, RoutedEventArgs e)
    {
        OpenFileDialog op = new OpenFileDialog();

        op.Title = "Select a picture";
        op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

        if (op.ShowDialog() == true)
        {
            filePath = op.FileName;
 
            Picture.ImageSource = new BitmapImage(new Uri(op.FileName));
            Picture.Stretch = Stretch.Uniform;
        }
    }

    private void Profile_Photo_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            string[] filenames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

            foreach (string fileName in filenames!)
            {
                Picture.ImageSource = new BitmapImage(new Uri(fileName));
            
                filePath = fileName;
            }
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Image.Name = image_name.Text;
        Image.Author = author_name.Text;
        Image.ImageUrl = filePath;
        try
        {
            Image.Time = DateTime.Parse(creation_name.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        DialogResult = true;
    }
}