using System;
using System.Collections.Generic;

using System.Text;
using MediaInfoLib;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using x264_GUI_CS;

namespace x264_GUI_CS.Task_Libraries
{
    public class MediaDetails32 : IfMediaDetails
    {
        MediaInfo32 media = new MediaInfo32();

        public string completeInfo(string file)
        {
            media.Open(file);
            string details = media.Inform();
            media.Close();
            return details;
        }

        public string fileName(string file)
        {
            media.Open(file);
            string fileN = media.Get(0, 0, "CompleteName");
            media.Close();
            return fileN;
        }

        public string name(string file)
        {
            media.Open(file);
            string fileName = media.Get(0, 0, "CompleteName");
            media.Close();
            string onlyName = Path.GetFileNameWithoutExtension(fileName);
            return onlyName;
        }

              
        public string fileSize(string file)
        {
            media.Open(file);
            string fileS = media.Get(0, 0, "FileSize");
            media.Close();
            return fileS;
        }

        public string fileFormat(string file)
        {
            media.Open(file);
            string fileF = media.Get(0,0,"Format");
            media.Close();
            return fileF;
        }

        public string fileExt(string file)
        {
            string ext = Path.GetExtension(file);
            return ext;
        }

        public string vidFormat(string file)
        {
            media.Open(file);
            string vidFor = media.Get(StreamKind.Video, 0, "Format");
            media.Close();
            return vidFor;
        }

        public string vidCodec(string file)
        {
            media.Open(file);
            string vidCod = media.Get(StreamKind.Video, 0, "CodecID");
            media.Close();
            return vidCod;
        }

        public string frameRateType(string file)
        {
            media.Open(file);
            string frameratetype = media.Get(StreamKind.Video, 0, "FrameRateMode");
            media.Close();
            return frameratetype;
        }

        public int width(string file)
        {
            media.Open(file);
            int w = int.Parse(media.Get(StreamKind.Video, 0, "Width"));
            media.Close();
            return w;
        }

        public int height(string file)
        {
            media.Open(file);
            int h = int.Parse(media.Get(StreamKind.Video, 0, "Height"));
            media.Close();
            return h;
        }

        public string chapters(string file)
        {
            media.Open(file);
            string asp = (media.Get(StreamKind.Chapters, 0, "1")).ToString();
            media.Close();
            return asp;
        }
        public float dar(string file)
        {
            media.Open(file);
            float asp = float.Parse(media.Get(StreamKind.Video, 0, "DisplayAspectRatio"));
            media.Close();
            return asp;
        }

        public int streamCount(string file)
        {
            media.Open(file);
            int cnt = media.Count_Get(StreamKind.Video) + media.Count_Get(StreamKind.Text) + media.Count_Get(StreamKind.Audio);
            media.Close();
            return cnt;
        }

        public float fps(string file)
        {
            media.Open(file);
            float fp = float.Parse(media.Get(StreamKind.Video, 0, "FrameRate"));
            media.Close();
            return fp;
        }

        public string audFormat(string file)
        {
            media.Open(file);
            string audFor = media.Get(StreamKind.Audio, 0, "Format");
            media.Close();
            return audFor;
        }

        public string[] audCodec(string file)
        {
            media.Open(file);
            string temp = media.Get(StreamKind.General, 0, "Audio_Format_List");
            media.Close();
            string[] temp1 = Regex.Split(temp, "/");
            return trim(temp1);

        }

        public int channels(string file)
        {
            media.Open(file);
            int ch = int.Parse(media.Get(StreamKind.Audio, 0, "Channels"));
            media.Close();
            return ch;
        }

        public int[] audBitrate(string file)
        {
            media.Open(file);
            int[] temp = new int[media.Count_Get(StreamKind.Audio)];

            for (int i = 0; i < media.Count_Get(StreamKind.Audio); i++)
                temp[i] = Convert.ToInt32(media.Get(StreamKind.Audio, i, "BitRate"));

            media.Close();
            return temp;
        }

        public int audioCount(string file)
        {
            media.Open(file);
            int audCnt = media.Count_Get(StreamKind.Audio);
            media.Close();
            return audCnt;
        }

        public float sampleRate(string file)
        {
            media.Open(file);
            float sample = float.Parse(media.Get(StreamKind.Audio, 0, "SamplingRate"));
            media.Close();
            return sample;
        }

        public string subFormat(string file)
        {
            media.Open(file);
            string subFor = media.Get(StreamKind.Text, 0, "Format");
            media.Close();
            return subFor;
        }

        public string[] subCodec(string file)
        {
            media.Open(file);
            string temp = media.Get(StreamKind.General, 0, "Text_Format_List");
            media.Close();
            string[] temp1 = Regex.Split(temp, "/");
            return trim(temp1);

        }

        public int subCount(string file)
        {
            media.Open(file);
            string temp = media.Get(StreamKind.General, 0, "TextCount");
            string[] split = Regex.Split(temp, "/");
            int subCnt;
            if (split[0] != "")
                subCnt = int.Parse(split[0].Trim());
            else
                subCnt = 0;
            media.Close();
            return subCnt;
        }

        public string[] audLanguage(string file)
        {
            media.Open(file);
            string temp = media.Get(StreamKind.General, 0, "Audio_Language_List");
            media.Close();
            string[] temp1 = Regex.Split(temp, "/");
            return trim(temp1);

        }

        public string[] subLang(string file)
        {
            media.Open(file);
            string temp = media.Get(StreamKind.General, 0, "Text_Language_List");
            media.Close();
            string[] temp1 = Regex.Split(temp, "/");
            return trim(temp1);

        }

        public string[] subCaption(string file)
        {
            media.Open(file);
            string[] temp = new string[media.Count_Get(StreamKind.Text)];

            for (int i = 0; i < media.Count_Get(StreamKind.Text); i++)
            {
                temp[i] = media.Get(StreamKind.Text, i, "Title");
            }
            media.Close();
            return temp;

        }

        public string[] audTitle(string file)
        {
            media.Open(file);
            string[] temp = new string[media.Count_Get(StreamKind.Audio)];

            for (int i = 0; i < media.Count_Get(StreamKind.Audio); i++)
                temp[i] = media.Get(StreamKind.Audio, i, "Title");

            media.Close();
            return temp;
        }

        public int[] audID(string file)
        {
            try
            {
                media.Open(file);
                int j = media.Count_Get(StreamKind.Audio);
                int[] temp = new int[2];

                for (int i = 0; i < j; i++)
                {
                    int trackID = int.Parse(media.Get(StreamKind.Audio, i, "ID"));
                    temp.SetValue(trackID, i);
                }
                media.Close();
                return temp;
            }
            catch
            {
                int[] temp = new int[2];
                return temp;
            }
        }

        public int[] subID(string file)
        {
            media.Open(file);
            int j = media.Count_Get(StreamKind.Text);
            int[] temp = new int[j];
            
            for (int i = 0; i < j; i++)
            {
                int trackID = int.Parse(media.Get(StreamKind.Text, i, "ID"));
                temp.SetValue(trackID, i);
            }
            media.Close();
            return temp;
        }

        public int audLength(string file)
        {
            media.Open(file);
            int length = int.Parse(media.Get(StreamKind.Audio, 0, "Duration"));
            media.Close();
            return length;
        }

        public int frameCount(string file)
        {
            media.Open(file);
            string temp = media.Get(StreamKind.Video, 0, "FrameCount");

            if (temp == "")
            {
                float fps = float.Parse(media.Get(StreamKind.Video, 0, "FrameRate"));
                string temp1 = media.Get(StreamKind.General, 0, "Duration");
                float dur = int.Parse(temp1) / 1000;
                int frames = (int)(fps * dur);
                media.Close();
                return frames;
            }
            else
            {
                int frames = int.Parse(temp);
                return frames;
            }
        }

        private string[] trim(string[] temp)
        {
            string[] trimmed = new string[temp.Length];
            for (int i = 0; i < temp.Length; i++)
                trimmed[i] = temp[i].Trim();
            return trimmed;
        }

    }

    public class MediaDetails64 : IfMediaDetails
    {
        MediaInfo64 media = new MediaInfo64();

        public string completeInfo(string file)
        {
            media.Open(file);
            string details = media.Inform();
            media.Close();
            return details;
        }

        public string fileName(string file)
        {
            media.Open(file);
            string fileN = media.Get(0, 0, "CompleteName");
            media.Close();
            return fileN;
        }

        public string name(string file)
        {
            media.Open(file);
            string fileName = media.Get(0, 0, "CompleteName");
            media.Close();
            string onlyName = Path.GetFileNameWithoutExtension(fileName);
            return onlyName;
        }

        public string chapters(string file)
        {
            media.Open(file);
            string asp = (media.Get(StreamKind.Chapters, 0, "1")).ToString();
            media.Close();
            return asp;
        }
        public int[] audBitrate(string file)
        {
            media.Open(file);
            int[] temp = new int[media.Count_Get(StreamKind.Audio)];

            for (int i = 0; i < media.Count_Get(StreamKind.Audio); i++)
                temp[i] = Convert.ToInt32(media.Get(StreamKind.Audio, i, "Bit_rate"));

            media.Close();
            return temp;
        }
        public string frameRateType(string file)
        {
            media.Open(file);
            string frameratetype = media.Get(StreamKind.Video, 0, "FrameRateMode");
            media.Close();
            return frameratetype;
        }

        public string fileSize(string file)
        {
            media.Open(file);
            string fileS = media.Get(0, 0, "FileSize");
            media.Close();
            return fileS;
        }

        public string fileFormat(string file)
        {
            media.Open(file);
            string fileF = media.Get(0, 0, "Format");
            media.Close();
            return fileF;
        }

        public string fileExt(string file)
        {
            string ext = Path.GetExtension(file);
            return ext;
        }

        public string vidFormat(string file)
        {
            media.Open(file);
            string vidFor = media.Get(StreamKind.Video, 0, "Format");
            media.Close();
            return vidFor;
        }

        public string vidCodec(string file)
        {
            media.Open(file);
            string vidCod = media.Get(StreamKind.Video, 0, "CodecID");
            media.Close();
            return vidCod;
        }

        public int width(string file)
        {
            media.Open(file);
            int w = int.Parse(media.Get(StreamKind.Video, 0, "Width"));
            media.Close();
            return w;
        }

        public int height(string file)
        {
            media.Open(file);
            int h = int.Parse(media.Get(StreamKind.Video, 0, "Height"));
            media.Close();
            return h;
        }

        public float dar(string file)
        {
            media.Open(file);
            float asp = float.Parse(media.Get(StreamKind.Video, 0, "DisplayAspectRatio"));
            media.Close();
            return asp;
        }

        public int streamCount(string file)
        {
            media.Open(file);
            int cnt = media.Count_Get(StreamKind.Video) + media.Count_Get(StreamKind.Text) + media.Count_Get(StreamKind.Audio);
            media.Close();
            return cnt;
        }

        public float fps(string file)
        {
            media.Open(file);
            float fp = float.Parse(media.Get(StreamKind.Video, 0, "FrameRate"));
            media.Close();
            return fp;
        }

        public string audFormat(string file)
        {
            media.Open(file);
            string audFor = media.Get(StreamKind.Audio, 0, "Format");
            media.Close();
            return audFor;
        }

        public string[] audCodec(string file)
        {
            media.Open(file);
            string temp = media.Get(StreamKind.General, 0, "Audio_Format_List");
            media.Close();
            string[] temp1 = Regex.Split(temp, "/");
            return trim(temp1);

        }

        public int channels(string file)
        {
            media.Open(file);
            int ch = int.Parse(media.Get(StreamKind.Audio, 0, "Channel(s)"));
            media.Close();
            return ch;
        }

        public int audioCount(string file)
        {
            media.Open(file);
            int audCnt = media.Count_Get(StreamKind.Audio);
            media.Close();
            return audCnt;
        }

        public float sampleRate(string file)
        {
            media.Open(file);
            float sample = float.Parse(media.Get(StreamKind.Audio, 0, "SamplingRate"));
            media.Close();
            return sample;
        }

        public string subFormat(string file)
        {
            media.Open(file);
            string subFor = media.Get(StreamKind.Text, 0, "Format");
            media.Close();
            return subFor;
        }

        public string[] subCodec(string file)
        {
            media.Open(file);
            string temp = media.Get(StreamKind.General, 0, "Text_Format_List");
            media.Close();
            string[] temp1 = Regex.Split(temp, "/");
            return trim(temp1);

        }

        public int subCount(string file)
        {
            media.Open(file);
            string temp = media.Get(StreamKind.General, 0, "TextCount");
            string[] split = Regex.Split(temp, "/");
            int subCnt;
            if (split[0] != "")
                subCnt = int.Parse(split[0].Trim());
            else
                subCnt = 0;
            media.Close();
            return subCnt;
        }

        public string[] audLanguage(string file)
        {
            media.Open(file);
            string temp = media.Get(StreamKind.General, 0, "Audio_Language_List");
            media.Close();
            string[] temp1 = Regex.Split(temp, "/");
            return trim(temp1);

        }

        public string[] subCaption(string file)
        {
            media.Open(file);
            string[] temp = new string[media.Count_Get(StreamKind.Text)];

            for (int i = 0; i < media.Count_Get(StreamKind.Text); i++)
            {
                temp[i] = media.Get(StreamKind.Text, i, "Title");
            }
            media.Close();
            return temp;

        }

        public int[] audID(string file)
        {
            media.Open(file);
            int j = media.Count_Get(StreamKind.Audio);
            int[] temp = new int[2];

            for (int i = 0; i < j; i++)
            {
                int trackID = int.Parse(media.Get(StreamKind.Audio, i, "ID"));
                temp.SetValue(trackID, i);
            }
            media.Close();
            return temp;
        }

        public int[] subID(string file)
        {
            media.Open(file);
            int j = media.Count_Get(StreamKind.Text);
            int[] temp = new int[j];

            for (int i = 0; i < j; i++)
            {
                int trackID = int.Parse(media.Get(StreamKind.Text, i, "ID"));
                temp.SetValue(trackID, i);
            }
            media.Close();
            return temp;
        }

        public int audLength(string file)
        {
            media.Open(file);
            int length = int.Parse(media.Get(StreamKind.Audio, 0, "Duration"));
            media.Close();
            return length;
        }

        public int frameCount(string file)
        {
            media.Open(file);
            int frames = int.Parse(media.Get(StreamKind.Video, 0, "FrameCount"));
            media.Close();
            return frames;
        }

        public string[] audTitle(string file)
        {
            media.Open(file);
            string[] temp = new string[media.Count_Get(StreamKind.Audio)];

            for (int i = 0; i < media.Count_Get(StreamKind.Audio); i++)
                temp[i] = media.Get(StreamKind.Audio, i, "Title");

            media.Close();
            return temp;
        }

        public string[] subLang(string file)
        {
            media.Open(file);
            string temp = media.Get(StreamKind.General, 0, "Text_Language_List");
            media.Close();
            string[] temp1 = Regex.Split(temp, "/");
            return trim(temp1);

        }

        private string[] trim(string[] temp)
        {
            string[] trimmed = new string[temp.Length];
            for (int i = 0; i < temp.Length; i++)
                trimmed[i] = temp[i].Trim();
            return trimmed;
        }

        

    }
}
