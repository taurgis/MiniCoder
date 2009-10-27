using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;
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
                    string registrySubKey = "";
                    string registrySubpath = "";
                    string localVersion = "";
                    Boolean complete = false;
                    XmlTextReader xmlReader = new XmlTextReader(Application.StartupPath + "\\applications.xml");

                   // // LogBook.addLogLine(""Custom Paths", 0);

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
                                case "registrySubKey":
                                    xmlReader.Read();
                                    registrySubKey = xmlReader.Value;
                                    break;
                                case "registrySubpath":
                                    xmlReader.Read();
                                    registrySubpath = xmlReader.Value;
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
                                    customPath = xmlReader.Value.Replace("\r\n    ","");
                                    break;
                                case "LocalVersion":
                                    xmlReader.Read();
                                    localVersion = xmlReader.Value;
                                    complete = true;
                                    break;
                            }

                            if (complete)
                            {
                                if (!String.IsNullOrEmpty(name))
                                {
                                    switch (appType)
                                    {
                                        case "exe":
                                            tools.Add(name, new RegistryApp(name, appType, registrySubpath,registrySubKey, downloadPath, category, customPath, localVersion));
                                            break;
                                        case "zip":
                                            tools.Add(name, new Zip(name, appType, downloadPath, category, customPath, localVersion));
                                            break;
                                        case "plugin":
                                            tools.Add(name, new AvsPlugin(name, downloadPath, category, tools["avs"], localVersion));
                                            break;
                                        case "Core":
                                            tools.Add(name, new Core(name, appType, downloadPath, category, customPath, localVersion));
                                            break;
                                    }

                                    if (!tools[name].isInstalled() && name != "BAAA")
                                    {
                                       // // LogBook.addLogLine(""Found custom path for " + name + ".", 1);
                                       // // LogBook.addLogLine(""Custom path invalid! Resetting to default.", 2);
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
            defaultPackages.Add("Core", new Core("Core", "Core", "http://www.gamerzzheaven.be/core.zip", "core", "", Assembly.GetExecutingAssembly().GetName().Version.ToString()));
            defaultPackages.Add("Library", new Core("Library", "Core", "http://www.gamerzzheaven.be/Library.zip", "core", "", "First Time"));
            defaultPackages.Add("CoreUpdater", new Core("CoreUpdater", "Core", "http://www.gamerzzheaven.be/CoreUpdater.zip", "core", "", "First Time"));
            
            defaultPackages.Add("ffmpeg", new Zip("ffmpeg", "zip", "http://www.gamerzzheaven.be/ffmpeg.zip", "audio", "","First Time"));
            defaultPackages.Add("mkvtoolnix", new Zip("mkvtoolnix", "zip", "http://www.gamerzzheaven.be/mkvtoolnix.zip", "muxer", "","First Time"));
            defaultPackages.Add("x264", new Zip("x264", "zip", "http://www.gamerzzheaven.be/x264.zip", "video", "","First Time"));
            defaultPackages.Add("mkv2vfr", new Zip("mkv2vfr", "zip", "http://www.gamerzzheaven.be/mkv2vfr.zip", "muxer", "","First Time"));
            defaultPackages.Add("avs", new RegistryApp("avs", "exe", "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/Avisynth_258.exe", "other", "","First Time"));
            defaultPackages.Add("mp4box", new Zip("mp4box", "zip", "http://www.gamerzzheaven.be/mp4box.zip", "muxer", "", "First Time"));
            defaultPackages.Add("besweet", new Zip("besweet", "zip", "http://www.gamerzzheaven.be/BeSweet.zip", "audio", "", "First Time"));
            defaultPackages.Add("ogmtools", new Zip("ogmtools", "zip", "http://www.gamerzzheaven.be/OGMTools.zip", "muxer", "", "First Time"));
            defaultPackages.Add("VirtualDubMod", new Zip("VirtualDubMod", "zip", "http://www.gamerzzheaven.be/VirtualDubMod.zip", "muxer", "", "First Time"));
            defaultPackages.Add("madplay", new Zip("madplay", "zip", "http://www.gamerzzheaven.be/madplay.zip", "audio", "", "First Time"));
            defaultPackages.Add("flac", new Zip("flac", "zip", "http://www.gamerzzheaven.be/flac.zip", "audio", "", "First Time"));
            defaultPackages.Add("valdec", new Zip("valdec", "zip", "http://www.gamerzzheaven.be/valdec.zip", "audio", "", "First Time"));
            defaultPackages.Add("faad", new Zip("faad", "zip", "http://www.gamerzzheaven.be/faad.zip", "audio", "", "First Time"));
            defaultPackages.Add("oggdec", new Zip("oggdec", "zip", "http://www.gamerzzheaven.be/oggdec.zip", "audio", "", "First Time"));
            defaultPackages.Add("Deen", new AvsPlugin("Deen", "http://www.gamerzzheaven.be/Deen.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("VSFilter", new AvsPlugin("VSFilter", "http://www.gamerzzheaven.be/VSFilter.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("Decomb", new AvsPlugin("Decomb", "http://www.gamerzzheaven.be/Decomb.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("UnDot", new AvsPlugin("UnDot", "http://www.gamerzzheaven.be/UnDot.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("FluxSmooth", new AvsPlugin("FluxSmooth", "http://www.gamerzzheaven.be/FluxSmooth.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("HQDN3D", new AvsPlugin("HQDN3D", "http://www.gamerzzheaven.be/HQDN3D.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("ColorMatrix", new AvsPlugin("ColorMatrix", "http://www.gamerzzheaven.be/ColorMatrix.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("DGDecode", new AvsPlugin("DGDecode", "http://www.gamerzzheaven.be/DGDecode.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("UnFilter", new AvsPlugin("UnFilter", "http://www.gamerzzheaven.be/UnFilter.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("Toon-v1.0-lite", new AvsPlugin("Toon-v1.0-lite", "http://www.gamerzzheaven.be/Toon-v1.0-lite.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("aWarpSharp", new AvsPlugin("aWarpSharp", "http://www.gamerzzheaven.be/aWarpSharp.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("MSharpen", new AvsPlugin("MSharpen", "http://www.gamerzzheaven.be/MSharpen.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("DGAVCDecode", new AvsPlugin("DGAVCDecode", "http://www.gamerzzheaven.be/DGAVCDecode.zip", "plugin", defaultPackages["avs"], "First Time"));
            defaultPackages.Add("xvid_encraw", new Zip("xvid_encraw", "zip", "http://www.gamerzzheaven.be/xvid_encraw.zip", "video", "", "First Time"));
            defaultPackages.Add("DGAVCIndex", new Zip("DGAVCIndex", "zip", "http://www.gamerzzheaven.be/DGAVCIndex.zip", "video", "", "First Time"));
            defaultPackages.Add("DGIndex", new Zip("DGIndex", "zip", "http://www.gamerzzheaven.be/dgindex.zip", "muxer", "", "First Time"));
            defaultPackages.Add("theora", new Zip("theora", "zip", "http://www.gamerzzheaven.be/theora.zip", "video", "", "First Time"));
            defaultPackages.Add("lame", new Zip("lame", "zip", "http://www.gamerzzheaven.be/lame.zip", "audio", "", "First Time"));
            defaultPackages.Add("DtsEdit", new Zip("DtsEdit", "zip", "http://www.gamerzzheaven.be/DtsEdit.zip", "video", "", "First Time"));
            defaultPackages.Add("BAAA", new AvsPlugin("BAAA", "http://www.gamerzzheaven.be/AAA.zip", "plugin", defaultPackages["avs"], "First Time"));
            
            
            foreach (string key in defaultPackages.Keys)
            {
                if (!tools.ContainsKey(key))
                    tools.Add(key, defaultPackages[key]);
            }

            //set online versions
            XmlDocument doc = new XmlDocument();
            if (MiniOnline.checkInternet())
            {
                doc.Load("http://www.gamerzzheaven.be/applications.xml");
                foreach (string key in tools.Keys)
                {
                    tools[key].getOnlineVersion(doc);
                }
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
               
                    xmlWriter.WriteStartElement("Application");
                    xmlWriter.WriteElementString("Name", key);
                    xmlWriter.WriteElementString("Type", tempTool.getAppType());
                    if (tempTool.getAppType().Equals("exe"))
                    {
                        xmlWriter.WriteElementString("registrySubpath", tempTool.registrySubpath);
                        xmlWriter.WriteElementString("registrySubKey", tempTool.registrySubKey);
                    }
                        xmlWriter.WriteElementString("Download", tempTool.getDownloadPath());
                    xmlWriter.WriteElementString("Category", tempTool.getCategory());
                    xmlWriter.WriteElementString("Custom_Path", tempTool.getCustomPath());
                    xmlWriter.WriteElementString("LocalVersion", tempTool.localVersion);
                    xmlWriter.WriteEndElement();
                
            }
            xmlWriter.WriteEndElement();
            //  xmlWriter.WriteFullEndElement();
            xmlWriter.Close();


        }
    }
}
