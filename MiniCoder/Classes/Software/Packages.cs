using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using MiniCoder;
using System.Globalization;
namespace MiniCoder
{
    public class Packages
    {
        Hashtable htPackages = new Hashtable();
        ApplicationSettings appSettings;

        public Packages(ApplicationSettings appSettings)
        {
            this.appSettings = appSettings;
            fillPackages();
        }

        public Hashtable FetchPackageHT()
        {
            return htPackages;
        }

        private void fillPackages()
        {
            if(File.Exists(appSettings.getAppPath() + "\\apps.txt"))
            {
                try
                {
                StreamReader streamReader = new StreamReader(appSettings.getAppPath() + "\\apps.txt");
                
                   
                    while (!streamReader.EndOfStream)
                    {
                        String[] appInfo = streamReader.ReadLine().Split(Convert.ToChar(";", Provider.getProvider()));
                        htPackages.Add(appInfo[0], newPackage(appInfo[0], appInfo[1], Convert.ToBoolean(appInfo[2], Provider.getProvider()), appInfo[3], appInfo[4], appInfo[5], appInfo[6], appInfo[7]));

                    }

                    streamReader.Close();
                }
                catch  (IOException)
                {
                   
                   
                }
            }
            Hashtable defaultPackages = new Hashtable();
            defaultPackages.Add("Core", newPackage("Core", "Core", false, "", "", "http://www.gamerzzheaven.be/core.zip", "core", ""));
            defaultPackages.Add("ffmpeg", newPackage("ffmpeg", "zip", false, "", "", "http://www.gamerzzheaven.be/ffmpeg.zip", "audio",""));
            defaultPackages.Add("mkvtoolnix", newPackage("mkvtoolnix", "zip", false, "", "", "http://www.gamerzzheaven.be/mkvtoolnix.zip", "muxer", ""));
            defaultPackages.Add("x264", newPackage("x264", "zip", false, "", "", "http://www.gamerzzheaven.be/x264.zip", "video", ""));
            defaultPackages.Add("mkv2vfr", newPackage("mkv2vfr", "zip", false, "", "", "http://www.gamerzzheaven.be/mkv2vfr.zip", "muxer", ""));
            defaultPackages.Add("avs", newPackage("avs", "exe", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/Avisynth_258.exe","other", ""));
            defaultPackages.Add("mp4box", newPackage("mp4box", "zip", false, "", "", "http://www.gamerzzheaven.be/mp4box.zip", "muxer", ""));
            defaultPackages.Add("besweet", newPackage("besweet", "zip", false, "", "", "http://www.gamerzzheaven.be/BeSweet.zip", "audio", ""));
            defaultPackages.Add("ogmtools", newPackage("ogmtools", "zip", false, "", "", "http://www.gamerzzheaven.be/OGMTools.zip", "muxer", ""));
            defaultPackages.Add("VirtualDubMod", newPackage("VirtualDubMod", "zip", false, "", "", "http://www.gamerzzheaven.be/VirtualDubMod.zip", "muxer", ""));
            defaultPackages.Add("avs2yuv", newPackage("avs2yuv", "zip", false, "", "", "http://www.gamerzzheaven.be/avs2yuv.zip", "other", ""));
            defaultPackages.Add("madplay", newPackage("madplay", "zip", false, "", "", "http://www.gamerzzheaven.be/madplay.zip", "audio",""));
            defaultPackages.Add("flac", newPackage("flac", "zip", false, "", "", "http://www.gamerzzheaven.be/flac.zip", "audio", ""));
            defaultPackages.Add("valdec", newPackage("valdec", "zip", false, "", "", "http://www.gamerzzheaven.be/valdec.zip", "audio", ""));
            defaultPackages.Add("faad", newPackage("faad", "zip", false, "", "", "http://www.gamerzzheaven.be/faad.zip", "audio",""));
            defaultPackages.Add("oggdec", newPackage("oggdec", "zip", false, "", "", "http://www.gamerzzheaven.be/oggdec.zip","audio", ""));
            defaultPackages.Add("Deen", newPackage("Deen", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/Deen.zip", "plugin", ""));
            defaultPackages.Add("VSFilter", newPackage("VSFilter", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/VSFilter.zip", "plugin", ""));
            defaultPackages.Add("Decomb", newPackage("Decomb", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/Decomb.zip","plugin", ""));
            defaultPackages.Add("UnDot", newPackage("UnDot", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/UnDot.zip", "plugin",""));
            defaultPackages.Add("FluxSmooth", newPackage("FluxSmooth", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/FluxSmooth.zip", "plugin", ""));
            defaultPackages.Add("HQDN3D", newPackage("HQDN3D", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/HQDN3D.zip", "plugin", ""));
            defaultPackages.Add("UnFilter", newPackage("UnFilter", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/UnFilter.zip", "plugin", ""));
            defaultPackages.Add("Toon-v1.0-lite", newPackage("Toon-v1.0-lite", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/Toon-v1.0-lite.zip", "plugin", ""));
            defaultPackages.Add("aWarpSharp", newPackage("aWarpSharp", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/aWarpSharp.zip", "plugin", ""));
            defaultPackages.Add("MSharpen", newPackage("MSharpen", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/MSharpen.zip", "plugin", ""));
            defaultPackages.Add("xvid_encraw", newPackage("xvid_encraw", "zip", false, "", "", "http://www.gamerzzheaven.be/xvid_encraw.zip", "video", ""));
            defaultPackages.Add("DGAVCIndex", newPackage("DGAVCIndex", "zip", false, "", "", "http://www.gamerzzheaven.be/DGAVCIndex.zip", "video", ""));
            defaultPackages.Add("DGAVCDecode", newPackage("DGAVCDecode", "dll", true, "Avisynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/DGAVCDecode.zip", "plugin", ""));
            defaultPackages.Add("DGIndex", newPackage("DGIndex", "zip", false, "", "", "http://www.gamerzzheaven.be/dgindex.zip", "muxer", ""));
          
            foreach(string key in defaultPackages.Keys)
            {
                if (!htPackages.Contains(key))
                    htPackages.Add(key, defaultPackages[key]);
            }
        
        }

        private Package newPackage(string appName, string appType, Boolean isRegistry, string registrySubPath, string registrySubKey, string downloadurl, string category, string customPath)
        {
            return new Package(appName, appType, isRegistry, registrySubPath, appSettings, registrySubKey, downloadurl, category, customPath);
        }

        public void SavePackages()
        {
            StreamWriter streamWriter = new StreamWriter(appSettings.getAppPath() + "\\apps.txt", false);
           
            foreach(string key in htPackages.Keys)
            {
                Package package = (Package)htPackages[key];
                if(!String.IsNullOrEmpty(package.getCustomPath()))
                streamWriter.WriteLine(key + ";" + package.getAppType() + ";" + package.getIsRegistry() + ";" + package.getRegistrySubPath() + ";" + package.getRegistrySubKey() + ";" + package.getDownloadUrl() + ";" + package.getCategory() + ";" + package.getCustomPath());

               
            }
            streamWriter.Close();

        }

    }
}
