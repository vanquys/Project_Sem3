using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project_Sem3.Models
{
    public class ImageProcessViewModel
    {
        public bool IsPngImage(byte[] imageBytes)
        {
            if (imageBytes.Length < 8) return false;
            return imageBytes[0] == 0x89 && imageBytes[1] == 0x50 && imageBytes[2] == 0x4E && imageBytes[3] == 0x47
                   && imageBytes[4] == 0x0D && imageBytes[5] == 0x0A && imageBytes[6] == 0x1A && imageBytes[7] == 0x0A;
        }
        public bool IsJpgImage(byte[] imageBytes)
        {
            if (imageBytes.Length < 3) return false;
            return imageBytes[0] == 0xFF && imageBytes[1] == 0xD8 && imageBytes[imageBytes.Length - 2] == 0xFF
                   && imageBytes[imageBytes.Length - 1] == 0xD9;
        }
        public string getImageUrl(byte[] imgByte) {
            string base64String = Convert.ToBase64String(imgByte);
            string url = null;
            if (IsPngImage(imgByte))
            {
                url = string.Format("data:image/png;base64,{0}", base64String);

            }
            if (IsJpgImage(imgByte)) { 
                 url = string.Format("data:image/jpeg;base64,{0}", base64String);

            }
            return url ;
        }
    }
}