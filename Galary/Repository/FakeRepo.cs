using Galary.Models;
using System;
using System.Collections.Generic;



namespace Galary.Repository;



public class FakeRepo
{

    public static List<Models.GalaryImage> GetGalaryImages()
    {
        return new List<Models.GalaryImage>()
        {
            new Models.GalaryImage()
            {
                 Author ="Leonardo da Vinçi",
                 Name = "Mono Lisa",
                 Time = new DateTime(1503,1, 1),
                 ImageUrl = "../../../Images/monoLisa.png"
            },
            new Models.GalaryImage()
            {
                 Author ="Leonardo da Vinçi",
                 Name = "Sonuncu şam yeməyi",
                 Time = new DateTime(1498,1, 1),
                 ImageUrl = "../../../Images/sonuncuSam.png"
            },
            new Models.GalaryImage()
            {
                 Author = "Vinsent van Qoq",
                 Name = "Ulduzlu gecə",
                 Time = new DateTime(1889,1, 1),
                 ImageUrl = "../../../Images/ulduzluGece.png"
            },
            new Models.GalaryImage()
            {
                 Author ="Yan Vermeer",
                 Name = "Mirvari tanalı qız",
                 Time = new DateTime(1665,1, 1),
                 ImageUrl = "../../../Images/mirvari.png"
            },
            new Models.GalaryImage()
            {
                 Author ="Mikelancelo",
                 Name = "Adəmin yaradılışı",
                 Time = new DateTime(1508,1, 1),
                 ImageUrl = "../../../Images/ademinYaradilisi.png"
            },
            new Models.GalaryImage()
            {
                 Author ="Ejen Delakrua",
                 Name = "Azadlığa aparan xalq",
                 Time = new DateTime(1830,1, 1),
                 ImageUrl = "../../../Images/azadliq.png"
            },
            new Models.GalaryImage()
            {
                 Author ="Rafael Santi",
                 Name = "Afina məktəbi",
                 Time = new DateTime(1511,1, 1),
                 ImageUrl = "../../../Images/afina.png"
            },
        };

    }
}