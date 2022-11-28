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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            UserControl_Photos photo = new(image);
            wrapPanel.Children.Add(photo);

        }
    }
}
