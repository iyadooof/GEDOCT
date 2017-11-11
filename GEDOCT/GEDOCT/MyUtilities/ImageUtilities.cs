using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GEDOCT.Forms;

namespace GEDOCT.MyUtilities
{
    public static class ImageUtilities
    {
        public static void savePhotoDoctorant(PictureBox pbDoctorant , string cin)
        {
            if ((pbDoctorant.Image != null) && (pbDoctorant.ImageLocation != @"images\photo.png"))
            {
                string new_dir = @"images\";
                string extension = System.IO.Path.GetExtension(pbDoctorant.ImageLocation);
                string renamed_name = cin + extension;
                string fName = System.IO.Path.Combine(new_dir, renamed_name);
                if (pbDoctorant.ImageLocation != fName)
                {
                    deletePhoto(cin);
                    System.IO.File.Copy(pbDoctorant.ImageLocation, fName);
                }
            }
        }

        public static void deletePhoto(string Cin)
        {
            string dir_name = @"images\";
            string[] ext = new string[] { ".png", ".jpg", ".gif", ".jpeg" };
            int i = 0;
            string file_name = dir_name + Cin;

            while ((i < 4) && (!File.Exists(file_name + ext[i])))
            {
                i++;
            }
            if (i < 4)
                File.Delete(file_name + ext[i]);
        }

        public static void getPhoto(PictureBox pbDoctorant, string Cin)
        {
            string dir_name = @"images\";
            string[] ext = new string[] { ".png", ".jpg", ".gif", ".jpeg" };
            int i = 0;
            string file_name = dir_name + Cin;

            while ((i < 4) && (!File.Exists(file_name + ext[i])))
            {
                i++;
            }
            if (i < 4)
                pbDoctorant.ImageLocation = file_name + ext[i];
            else
                pbDoctorant.ImageLocation = @"images\photo.png";

        }
    }
}
