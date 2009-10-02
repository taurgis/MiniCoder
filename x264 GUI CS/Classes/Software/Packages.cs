using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.IO;
namespace x264_GUI_CS
{
    class Packages
    {
        Hashtable htPackages = new Hashtable();
        ApplicationSettings appSettings;

        public Packages(ApplicationSettings appSettings)
        {
            this.appSettings = appSettings;
            fillPackages();
        }

        public Hashtable getPackages()
        {
            return htPackages;
        }

        private void fillPackages()
        {
            if(File.Exists(appSettings.getAppPath() + "\\apps.txt"))
            {
                StreamReader streamReader = new StreamReader(appSettings.getAppPath() + "\\apps.txt");
                while (!streamReader.EndOfStream)
                {
                    String[] appInfo = streamReader.ReadLine().Split(Convert.ToChar(";"));
                    htPackages.Add(appInfo[0], newPackage(appInfo[0], appInfo[1],Convert.ToBoolean(appInfo[2]),appInfo[3],appInfo[4],appInfo[5],appInfo[6]));
                
                }
                streamReader.Close();
            }
            else
            {
            htPackages.Add("mkvtoolnix", newPackage("mkvmerge", "exe", true, "mkvmergeGUI\\GUI\\", "installation_path", "http://www.gamerzzheaven.be/mkvtoolnix.exe",""));
            htPackages.Add("x264", newPackage("x264", "zip", false, "", "", "http://www.gamerzzheaven.be/x264.zip", ""));
            htPackages.Add("mkv2vfr", newPackage("mkv2vfr", "zip", false, "", "", "http://www.gamerzzheaven.be/mkv2vfr.zip", ""));
            htPackages.Add("avs", newPackage("avs", "exe", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/Avisynth_258.exe", ""));
            htPackages.Add("mp4box", newPackage("mp4box", "zip", false, "", "", "http://www.minitheatre.org/x264prog/mp4box.zip", ""));
            htPackages.Add("besweet", newPackage("besweet", "zip", false, "", "", "http://www.gamerzzheaven.be/BeSweet.zip", ""));
            htPackages.Add("ogmtools", newPackage("ogmtools", "zip", false, "", "", "http://www.gamerzzheaven.be/OGMTools.zip", ""));
            htPackages.Add("VirtualDubMod", newPackage("VirtualDubMod", "zip", false, "", "", "http://www.gamerzzheaven.be/VirtualDubMod.zip", ""));
            htPackages.Add("avs2yuv", newPackage("avs2yuv", "zip", false, "", "", "http://www.gamerzzheaven.be/avs2yuv.zip", ""));
            htPackages.Add("madplay", newPackage("madplay", "zip", false, "", "", "http://www.gamerzzheaven.be/madplay.zip", ""));
            htPackages.Add("flac", newPackage("flac", "zip", false, "", "", "http://www.gamerzzheaven.be/flac.zip", ""));
            htPackages.Add("valdec", newPackage("valdec", "zip", false, "", "", "http://www.gamerzzheaven.be/valdec.zip", ""));
            htPackages.Add("faad", newPackage("faad", "zip", false, "", "", "http://www.gamerzzheaven.be/faad.zip", ""));
            htPackages.Add("oggdec", newPackage("oggdec", "zip", false, "", "", "http://www.gamerzzheaven.be/oggdec.zip", ""));
            htPackages.Add("Deen", newPackage("Deen", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/Deen.dll", ""));
            htPackages.Add("VSFilter", newPackage("VSFilter", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/VSFilter.dll", ""));
            htPackages.Add("Decomb", newPackage("Decomb", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/Decomb.dll", ""));
            htPackages.Add("UnDot", newPackage("UnDot", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/UnDot.dll", ""));
            htPackages.Add("FluxSmooth", newPackage("FluxSmooth", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/FluxSmooth.dll", ""));
            htPackages.Add("HQDN3D", newPackage("HQDN3D", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/HQDN3D.dll", ""));
            htPackages.Add("UnFilter", newPackage("UnFilter", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/UnFilter.dll", ""));
            htPackages.Add("Toon-v1.0-lite", newPackage("Toon-v1.0-lite", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/Toon-v1.0-lite.dll", ""));
            htPackages.Add("aWarpSharp", newPackage("aWarpSharp", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/aWarpSharp.dll", ""));
            htPackages.Add("MSharpen", newPackage("MSharpen", "dll", true, "AviSynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/MSharpen.dll", ""));
            htPackages.Add("xvid_encraw", newPackage("xvid_encraw", "zip", false, "", "", "http://www.gamerzzheaven.be/xvid_encraw.zip", ""));
            htPackages.Add("DGAVCIndex", newPackage("DGAVCIndex", "zip", false, "", "", "http://www.gamerzzheaven.be/DGAVCIndex.zip", ""));
            htPackages.Add("DGAVCDecode", newPackage("DGAVCDecode", "dll", true, "Avisynth\\", "plugindir2_5", "http://www.gamerzzheaven.be/DGAVCDecode.dll", ""));
            htPackages.Add("DGIndex", newPackage("DGIndex", "zip", false, "", "", "http://www.gamerzzheaven.be/dgindex.zip", ""));
          
        }
        }

        private Package newPackage(string appName, string appType, Boolean isRegistry, string registrySubPath, string registrySubKey, string downloadurl, string customPath)
        {
             Package tempPackage;
             return tempPackage = new Package(appName, appType, isRegistry, registrySubPath, appSettings, registrySubKey, downloadurl, customPath);
        }

        public void savePackages()
        {
            StreamWriter streamWriter = new StreamWriter(appSettings.getAppPath() + "\\apps.txt", false);
           
            foreach(string key in htPackages.Keys)
            {
                Package package = (Package)htPackages[key];
                streamWriter.WriteLine(key + ";" + package.getAppType() + ";" + package.getIsRegistry() + ";" + package.getRegistrySubPath() + ";" + package.getRegistrySubKey() + ";" + package.getDownloadUrl() + ";" + package.getCustomPath());

               
            }
            streamWriter.Close();

        }

    }
}
