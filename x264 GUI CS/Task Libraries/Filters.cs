using System;
using System.Collections.Generic;

using System.Text;

using x264_GUI_CS;

namespace x264_GUI_CS.Task_Libraries
{
    class Filters
    {
        ApplicationSettings dir;

        public Filters(ApplicationSettings dir)
        {
            this.dir = dir;
        }

        Package filter;
        public string addField(int ID)
        {
            switch (ID)
            {
                case 1:
                    filter = (Package)dir.htRequired["Decomb"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "FieldDeinterlace()";
                default:
                    return "";
            }
        }

        public string addResize(int ID, int width, int height)
        {
            switch (ID)
            {
                case 1:
                    return "BilinearResize(" + width.ToString() + "," + height.ToString() + ")";
                case 2:
                    return "BicubicResize(" + width.ToString() + "," + height.ToString() + ")";
                case 3:
                    return "LanczosResize(" + width.ToString() + "," + height.ToString() + ")";
                case 4:
                    return "Lanczos4Resize(" + width.ToString() + "," + height.ToString() + ")";
                case 5:
                    return "Spline36Resize(" + width.ToString() + "," + height.ToString() + ")";
                default:
                    return "";
            }
        }

        public string addNoise(int ID)
        {
            switch (ID)
            {
                case 1:
                    filter = (Package)dir.htRequired["UnDot"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "UnDot()";
                case 2:
                    filter = (Package)dir.htRequired["FluxSmooth"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "FluxSmoothST()";
                case 3:
                    filter = (Package)dir.htRequired["HQDN3D"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "HQDN3D()";
                case 4:
                    filter = (Package)dir.htRequired["UnDot"];
                    if (!filter.isInstalled())
                        filter.download();
                    filter = (Package)dir.htRequired["Deen"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "UnDot.Deen()";
                default:
                    return "";
            }
        }

        public string addSharp(int ID)
        {
            switch (ID)
            {
                case 1:
                    filter = (Package)dir.htRequired["UnFilter"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "UnFilter(20,20)";
                case 2:
                    filter = (Package)dir.htRequired["Toon-v1.0-lite"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "ToonLite(strength=0.75)";
                case 3:
                    filter = (Package)dir.htRequired["aWarpSharp"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "aWarpSharp()";
                case 4:
                    filter = (Package)dir.htRequired["MSharpen"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "MSharpen()";
                default:
                    return "";
            }
        }

        public string addSub(string sub)
        {
            switch (sub)
            {
                case "Select Subtitle file to use":
                    return "";
                default:
                    filter = (Package)dir.htRequired["VSFilter"];
                    if (!filter.isInstalled())
                        filter.download();
                    return "TextSub(\"" + sub + "\")";
            }
        }
                
    }
}
