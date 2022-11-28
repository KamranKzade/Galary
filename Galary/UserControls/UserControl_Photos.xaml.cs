using Galary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Galary.UserControls;



public partial class UserControl_Photos : UserControl, INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;

    private GalaryImage photo;
    public GalaryImage Photo
    {
        get { return photo; }
        set { photo = value;OnPropertyChanged(); }
    }
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(name));
        }
    }

    public UserControl_Photos(GalaryImage image)
    {
        InitializeComponent();
        Photo = image;
        DataContext = this;
    }



}
