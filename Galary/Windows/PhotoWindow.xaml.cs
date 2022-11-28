using Galary.Models;
using Galary.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Galary.Windows;

public partial class PhotoWindow : Window
{
    public List<GalaryImage> Galaries { get; set; }
    public PhotoWindow(ImageSource source, GalaryImage image, List<GalaryImage> GalaryImages)
    {
        InitializeComponent();

        Galaries = new();
        Galaries = GalaryImages;


        UserControl_Photos photo = new(source, image);

        mygrid.Children.Add(photo);
    }

    private void Button_Click(object sender, RoutedEventArgs e) => Close();

    private void Previous_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;


        switch (btn!.Name)
        {
            case "Previous":
                MessageBox.Show("ok1");
                break;
            case "Pause":
                MessageBox.Show("ok2");
                break;
            case "Play":
                MessageBox.Show("ok3");
                break;
            case "Next":
                MessageBox.Show("ok4");
                break;
            default:
                break;
        }

    }
}