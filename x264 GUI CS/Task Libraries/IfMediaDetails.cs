using System;
using System.Collections.Generic;

using System.Text;

namespace x264_GUI_CS
{
    interface IfMediaDetails
    {
        string completeInfo(string file);
        string fileName(string file);
        string name(string file);
        string fileSize(string file);
        string fileFormat(string file);
        string fileExt(string file);
        string vidFormat(string file);
        string vidCodec(string file);
        int width(string file);
        string chapters(string file);
        int height(string file);
        float dar(string file);
        int streamCount(string file);
        float fps(string file);
        string audFormat(string file);
        string[] audCodec(string file);
        int channels(string file);
        int audioCount(string file);
        float sampleRate(string file);
        string subFormat(string file);
        string[] subCodec(string file);
        int subCount(string file);
        string[] audLanguage(string file);
        string[] subCaption(string file);
        int[] audID(string file);
        int[] subID(string file);
        int audLength(string file);
        int frameCount(string file);
        string[] audTitle(string file);
        string[] subLang(string file);
        string frameRateType(string file);

    }
}
