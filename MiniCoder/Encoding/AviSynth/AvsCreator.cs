using System;
using System.Collections.Generic;
using System.Text;
using MiniCoder.Encoding.AviSynth.Plugins;
using MiniCoder.Encoding.Input.Tracks;
using MiniCoder.External;
using System.Windows.Forms;
using System.IO;

namespace MiniCoder.Encoding.AviSynth
{
    class AvsCreator
    {
        SortedList<String, String[]> fileDetails;
        SortedList<String, String> EncOpts;
        SortedList<String, Tool> tools;
        Track video;

        public AvsCreator(SortedList<String, String[]> fileDetails, Track video, SortedList<String, String> EncOpts, SortedList<String, Tool> tools)
        {
            this.fileDetails = fileDetails;
            this.video = video;
            this.EncOpts = EncOpts;
            this.tools = tools;
        }

        public Boolean getAvsFile(SortedList<String, Track[]> fileTracks)
        {
            string avs = "";
            
            avs += getSourceLine() + "\r\n";
            avs += EncOpts["custom"];
            avs += getFieldLine();
            avs += getResizeLine();
            avs += getDenoiseLine();
            avs += getSharpenLine();
            if (EncOpts.ContainsKey("hardsub"))
                avs += "TextSub(\"" + EncOpts["hardsub"] + "\")";
            if (EncOpts.ContainsKey("hardsubmp4"))
                if(EncOpts["hardsubmp4"] != "0" && (EncOpts["container"] == "1" || EncOpts["container"] == "2") && fileTracks["subs"].Length > 0)
                avs += "\r\nTextSub(\"" + fileTracks["subs"][int.Parse(EncOpts["hardsubmp4"])-1].demuxPath + "\")";
            EncOpts.Add("avsfile", (Application.StartupPath + "\\temp\\" + fileDetails["name"][0] + ".avs"));
            StreamWriter streamWriter = new StreamWriter(EncOpts["avsfile"]);
            streamWriter.Write(avs);
            streamWriter.Close();

            LogBook.addLogLine(avs, fileDetails["name"][0] + "AvsCreation", "", false);
          

            return checkAvs();
        }

        private Boolean checkAvs()
        {
            try
            {
                AviSynthScriptEnvironment environment = new AviSynthScriptEnvironment();

                AviSynthClip temp = environment.OpenScriptFile(EncOpts["avsfile"]);
                return true;
               
            }
            catch (AviSynthException er)
            {
                // LogBook.addLogLine("er.Message,1);
                return false;
            }
                
        }

        private string getSourceLine()
        {
            Plugin source = new Source();
            return source.getAvsCode(fileDetails, video, EncOpts, tools);
        }

        private string getFieldLine()
        {
            Plugin field = new Field();
            return field.getAvsCode(fileDetails, video, EncOpts, tools);
        }

        private string getResizeLine()
        {
            Plugin resize = new Resize();
            return resize.getAvsCode(fileDetails, video, EncOpts, tools);
        }

        private string getDenoiseLine()
        {
            Plugin denoise = new Denoise();
            return denoise.getAvsCode(fileDetails, video, EncOpts, tools);
        }
        private string getSharpenLine()
        {
            Plugin sharpen = new Sharpen();
            return sharpen.getAvsCode(fileDetails, video, EncOpts, tools);
        }

    }
}
