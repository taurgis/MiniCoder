using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

using System.Windows.Forms;
namespace MiniCoder.External
{
    public class Tools
    {

        private SortedList<String, Tool> tools = new SortedList<String, Tool>();
        private string basePath = Application.StartupPath;

        public Tools(Boolean load)
        {
            if(load)
            fillPackages();
        }

        public SortedList<String, Tool> getTools()
        {

            return tools;
        }

        private void fillPackages()
        {
            if (File.Exists(basePath + "\\applications.xml"))
            {
                try
                {
                    String name ="";
                    String downloadPath ="";
                    String appType = "";
                    String category = "";
                    string customPath ="";
                    Boolean complete = false;
                    XmlTextReader xmlReader = new XmlTextReader(Application.StartupPath + "\\applications.xml");

                    LogBook.addLogLine("Custom Paths", 0);

                   xmlReader.Read();
                
                   while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element)
                        {
                            switch (xmlReader.Name)
                            {
                                case "Name":
                                    xmlReader.Read();
                                    name = xmlReader.Value;
                                    break;
                                case "Type":
                                    xmlReader.Read();
                                    appType = xmlReader.Value;
                                    break;
                                case "Download":
                                    xmlReader.Read();
                                    downloadPath = xmlReader.Value;
                                    break;
                                case "Category":
                                    xmlReader.Read();
                                    category = xmlReader.Value;
                                    break;
                                case "Custom_Path":
                                    xmlReader.Read();
                                    customPath = xmlReader.Value;
                                    complete = true;
                                    break;
                            }

                            if (complete)
                            {
                                if (!String.IsNullOrEmpty(name))
                                {
                                    tools.Add(name, new Zip(name, appType, downloadPath, category, customPath));
                                    
                                    LogBook.addLogLine("Found custom path for " + name +".",1);
                                    if (!tools[name].isInstalled())
                                    {
                                        LogBook.addLogLine("Custom path invalid! Resetting to default.", 2);
                                        tools.Remove(name);
                                    }
                                }
                                    complete = false;
                            }

                        }

                    }
                  



                   xmlReader.Close();

                }
                catch (IOException)
                {


                }
            }
            SortedList<String, Tool> defaultPackages = new SortedList<string, Tool>();
            defaultPackages.Add("Core", new Core("Core", "Core", "http://www.gamerzzheaven.be/core.zip", "core", ""));
            defaultPackages.Add("ffmpeg", new Zip("ffmpeg", "zip", "http://www.gamerzzheaven.be/ffmpeg.zip", "audio", ""));
            defaultPackages.Add("mkvtoolnix", new Zip("mkvtoolnix", "zip", "http://www.gamerzzheaven.be/mkvtoolnix.zip", "muxer", ""));
            defaultPackages.Add("x264", new Zip("x264", "zip", "http://www.gamerzzheaven.be/x264.zip", "video", ""));
            defaultPackages.Add("mkv2vfr", new Zip("mkv2vfr", "zip", "http://www.gamerzzheaven.be/mkv2vfr.zip", "muxer", ""));
            defaultPackages.Add("avs", new RegistryApp("avs", "exe", "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/Avisynth_258.exe", "other", ""));
            defaultPackages.Add("mp4box", new Zip("mp4box", "zip", "http://www.gamerzzheaven.be/mp4box.zip", "muxer", ""));
            defaultPackages.Add("besweet", new Zip("besweet", "zip", "http://www.gamerzzheaven.be/BeSweet.zip", "audio", ""));
            defaultPackages.Add("ogmtools", new Zip("ogmtools", "zip", "http://www.gamerzzheaven.be/OGMTools.zip", "muxer", ""));
            defaultPackages.Add("VirtualDubMod", new Zip("VirtualDubMod", "zip", "http://www.gamerzzheaven.be/VirtualDubMod.zip", "muxer", ""));
            defaultPackages.Add("madplay", new Zip("madplay", "zip", "http://www.gamerzzheaven.be/madplay.zip", "audio", ""));
            defaultPackages.Add("flac", new Zip("flac", "zip", "http://www.gamerzzheaven.be/flac.zip", "audio", ""));
            defaultPackages.Add("valdec", new Zip("valdec", "zip", "http://www.gamerzzheaven.be/valdec.zip", "audio", ""));
            defaultPackages.Add("faad", new Zip("faad", "zip", "http://www.gamerzzheaven.be/faad.zip", "audio", ""));
            defaultPackages.Add("oggdec", new Zip("oggdec", "zip", "http://www.gamerzzheaven.be/oggdec.zip", "audio", ""));
            defaultPackages.Add("Deen", new AvsPlugin("Deen", "http://www.gamerzzheaven.be/Deen.zip", "plugin", defaultPackages["avs"]));
            defaultPackages.Add("VSFilter", new AvsPlugin("VSFilter", "http://www.gamerzzheaven.be/VSFilter.zip", "plugin", defaultPackages["avs"]));
            defaultPackages.Add("Decomb", new AvsPlugin("Decomb", "http://www.gamerzzheaven.be/Decomb.zip", "plugin", defaultPackages["avs"]));
            defaultPackages.Add("UnDot", new AvsPlugin("UnDot", "http://www.gamerzzheaven.be/UnDot.zip", "plugin", defaultPackages["avs"]));
            defaultPackages.Add("FluxSmooth", new AvsPlugin("FluxSmooth", "http://www.gamerzzheaven.be/FluxSmooth.zip", "plugin", defaultPackages["avs"]));
            defaultPackages.Add("HQDN3D", new AvsPlugin("HQDN3D", "http://www.gamerzzheaven.be/HQDN3D.zip", "plugin", defaultPackages["avs"]));
            defaultPackages.Add("UnFilter", new AvsPlugin("UnFilter", "http://www.gamerzzheaven.be/UnFilter.zip", "plugin", defaultPackages["avs"]));
            defaultPackages.Add("Toon-v1.0-lite", new AvsPlugin("Toon-v1.0-lite", "http://www.gamerzzheaven.be/Toon-v1.0-lite.zip", "plugin", defaultPackages["avs"]));
            defaultPackages.Add("aWarpSharp", new AvsPlugin("aWarpSharp", "http://www.gamerzzheaven.be/aWarpSharp.zip", "plugin", defaultPackages["avs"]));
            defaultPackages.Add("MSharpen", new AvsPlugin("MSharpen", "http://www.gamerzzheaven.be/MSharpen.zip", "plugin", defaultPackages["avs"]));
            defaultPackages.Add("DGAVCDecode", new AvsPlugin("DGAVCDecode", "http://www.gamerzzheaven.be/DGAVCDecode.zip", "plugin", defaultPackages["avs"]));
            defaultPackages.Add("xvid_encraw", new Zip("xvid_encraw", "zip", "http://www.gamerzzheaven.be/xvid_encraw.zip", "video", ""));
            defaultPackages.Add("DGAVCIndex", new Zip("DGAVCIndex", "zip", "http://www.gamerzzheaven.be/DGAVCIndex.zip", "video", ""));
            defaultPackages.Add("DGIndex", new Zip("DGIndex", "zip", "http://www.gamerzzheaven.be/dgindex.zip", "muxer", ""));
            defaultPackages.Add("theora", new Zip("theora", "zip", "http://www.gamerzzheaven.be/theora.zip", "video", ""));

            foreach (string key in defaultPackages.Keys)
            {
                if (!tools.ContainsKey(key))
                    tools.Add(key, defaultPackages[key]);
            }

        }



        public void SavePackages()
        {


            XmlTextWriter xmlWriter = new XmlTextWriter(Application.StartupPath + "\\applications.xml", null);
            xmlWriter.Formatting = Formatting.Indented;

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Applications");

            foreach (string key in tools.Keys)
            {
                Tool tempTool = tools[key];
                if (!String.IsNullOrEmpty(tempTool.getCustomPath()))
                {
                    xmlWriter.WriteStartElement("Application");
                    xmlWriter.WriteElementString("Name", key);
                    xmlWriter.WriteElementString("Type", tempTool.getAppType());
                    xmlWriter.WriteElementString("Download", tempTool.getDownloadPath());
                    xmlWriter.WriteElementString("Category", tempTool.getCategory());
                    xmlWriter.WriteElementString("Custom_Path", tempTool.getCustomPath());
                    xmlWriter.WriteEndElement();
                }


            }
            xmlWriter.WriteEndElement();
            //  xmlWriter.WriteFullEndElement();
            xmlWriter.Close();


        }
    }
}
