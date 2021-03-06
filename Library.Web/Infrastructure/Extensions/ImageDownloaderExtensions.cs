﻿namespace Library.Web.Infrastructure.Extensions
{
    using System.IO;
    using System.Net;

    using static WebConstants;

    public static class ImageDownloaderExtensions
    {
        public static bool Download(string imageUrl, string saveLocation)
        {
            byte[] imageBytes;

            if (imageUrl.ToLower().EndsWith(JpgType) || imageUrl.ToLower().EndsWith(GifType) || imageUrl.ToLower().EndsWith(PngType))
            {
                HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageUrl);

                imageRequest.Timeout = 1200; // miliseconds
                imageRequest.Method = GetMethodRequest;

                try
                {
                    WebResponse imageResponse = imageRequest.GetResponse();
                    Stream responseStream = imageResponse.GetResponseStream();

                    using (BinaryReader br = new BinaryReader(responseStream))
                    {
                        imageBytes = br.ReadBytes(500000);
                        br.Close();
                    }

                    responseStream.Close();
                    imageResponse.Close();

                    var pathForUpload = Path.Combine(Directory.GetCurrentDirectory(), RootFolderName, saveLocation);

                    FileStream fs = new FileStream(pathForUpload, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);

                    try
                    {
                        bw.Write(imageBytes);
                    }
                    finally
                    {
                        fs.Close();
                        bw.Close();
                    }
                }
                catch (WebException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}