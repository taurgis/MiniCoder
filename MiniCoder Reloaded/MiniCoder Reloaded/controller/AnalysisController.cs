using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using be.miniTech.minicoder.model.inputfile;
using be.miniTech.minicoder.model.information;

namespace be.miniTech.minicoder.controller
{
    public class AnalysisController
    {
        public static InputFile fetchFileInfo(String fileName)
        {
            MediaInfoWrapper.MediaInfo info = new MediaInfoWrapper.MediaInfo(fileName);
            InputFile file = new InputFile();
           
            file.audioTracks = fetchAudioTracks(info);

            return file;
        }

        private static List<AudioTrack> fetchAudioTracks(MediaInfoWrapper.MediaInfo info)
        {
            List<AudioTrack> audioTracks = new List<AudioTrack>();
            for (int i = 0; i < info.AudioCount; i++)
            {
                MediaInfoWrapper.AudioTrack tempAudioTrack = info.Audio[i];
                InputFile infputFile = new InputFile();
                AudioTrack audioTrack = new AudioTrack();

                audioTrack.audioID = Int32.Parse(tempAudioTrack.ID);
                audioTrack.codec = new model.information.Codec(tempAudioTrack.CodecIDInfo, tempAudioTrack.CodecID);
                audioTrack.duration = long.Parse(tempAudioTrack.Duration);
                audioTrack.language = new Language(tempAudioTrack.LanguageString, tempAudioTrack.Language);
                audioTrack.title = tempAudioTrack.Title;

                audioTracks.Add(audioTrack);
            }
            return audioTracks;
        }

    }
}
