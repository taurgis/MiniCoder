using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using x264_GUI_CS;

namespace MiniCoder
{
    public class EncodingOptions
    {
        public int vidBR = 300;
        public int vidCodec = 0;
        public int vidQual = 1;
        public int sizeOpt = 0;
        public int fileSize = 60;
        public string type = "bitrate";
        public bool advert = false;
        public int audBR = 40;
        public int audCodec = 0;

        public int containerFormat = 0;
        public int hardSub = 0;
        public string hardSubLocation;
        public int filtField = 0;
        public int filtResize = 0;
        public int resizeWidth;
        public int resizeHeight;

        public int filtNoise = 0;
        public int filtSharp = 0;
        public string subtitle;
        public string customFilter;
        public string templateName;
        

        public void save()
        {

            StreamWriter strTemplate = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\x264Encoder\\Templates\\" + templateName + ".tpl", false);
            strTemplate.WriteLine(vidBR);
            strTemplate.WriteLine(fileSize);
            strTemplate.WriteLine(sizeOpt);
            strTemplate.WriteLine(vidCodec);
            strTemplate.WriteLine(vidQual);
            strTemplate.WriteLine(audBR);
            strTemplate.WriteLine(audCodec);
            strTemplate.WriteLine(containerFormat);
            strTemplate.WriteLine(filtField);
            strTemplate.WriteLine(filtResize);
            strTemplate.WriteLine(resizeWidth);
            strTemplate.WriteLine(resizeHeight);
            strTemplate.WriteLine(filtNoise);
            strTemplate.WriteLine(filtSharp);
            strTemplate.WriteLine(subtitle);
                  
          
            strTemplate.Write(customFilter);
            
            strTemplate.Close();
        }

        public void delete()
        {
            File.Delete(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\x264Encoder\\Templates\\" + templateName + ".tpl");
        }

        public void load(string templatename)
        {
            
            StreamReader strTemplate = new StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\x264Encoder\\Templates\\" + templatename + ".tpl");
            this.templateName = templatename;
           
            vidBR =  Convert.ToInt32(strTemplate.ReadLine());
            fileSize = Convert.ToInt32(strTemplate.ReadLine());
            sizeOpt = Convert.ToInt32(strTemplate.ReadLine());
            vidCodec = Convert.ToInt32(strTemplate.ReadLine());
            vidQual = Convert.ToInt32(strTemplate.ReadLine());
            audBR = Convert.ToInt32(strTemplate.ReadLine());
            audCodec = Convert.ToInt32(strTemplate.ReadLine());
            containerFormat = Convert.ToInt32(strTemplate.ReadLine());
            filtField = Convert.ToInt32(strTemplate.ReadLine());
            filtResize = Convert.ToInt32(strTemplate.ReadLine());
            resizeWidth = Convert.ToInt32(strTemplate.ReadLine());
            resizeHeight = Convert.ToInt32(strTemplate.ReadLine());
            filtNoise = Convert.ToInt32(strTemplate.ReadLine());
            filtSharp = Convert.ToInt32(strTemplate.ReadLine());
            subtitle = strTemplate.ReadLine();
            customFilter = strTemplate.ReadToEnd();

            strTemplate.Close();
        }
     }
}
