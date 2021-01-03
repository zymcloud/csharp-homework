using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCloudSharp;

namespace WordCloudTestApp
{
    class MyWorldCloud
    {
        #region attributes & constructor
        private WordCloud wc;
        
        public bool drawwordcloud(List<string> Words, List<int> Frequencies,string path,string name)
        {
            String realpath = path + "\\" + name;
            this.wc = new WordCloud(1000, 800, mask: null, allowVerical: true, fontname: "YouYuan");           
           /* List<string> Words = new List<string>();

            Words.Add("温钧盛");
            Words.Add("谢瑞鹏");
            Words.Add("贾康健");
            Words.Add("张一鸣");
            List<int> Frequencies = new List<int>();

            Frequencies.Add(1);
            Frequencies.Add(1);
            Frequencies.Add(1);
            Frequencies.Add(1);*/

            Image image = wc.Draw(Words, Frequencies);
            bool a = SaveImage(image, realpath, "image/jpeg");
            return a;
        }
        public bool SaveImage(Image imgResult, string Path, string ImageType)
        {
            EncoderParameter p;
            EncoderParameters ps;
            try
            {
                ps = new EncoderParameters(1);
                p = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                ps.Param[0] = p;
                ImageCodecInfo ii = GetCodecInfo(ImageType);
                imgResult.Save(Path, ii, ps);
                imgResult.Dispose();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }
        
    }
    
}
#endregion