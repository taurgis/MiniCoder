using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using be.miniTech.minicoder.model.inputfile;
using be.miniTech.minicoder.model.information;

namespace be.miniTech.minicoder.controller
{
    public class EncodingController
    {
        public Boolean startEncode(String fileName)
        {
            fetchFileInfo(fileName);
            return true;
        }

        private Boolean fetchFileInfo(String fileName)
        {
            MediaInfoWrapper.MediaInfo info = new MediaInfoWrapper.MediaInfo(fileName);
            InputFile file = new InputFile();
            List<AudioTrack> audioTracks = new List<AudioTrack>();
            for (int i = 0; i < info.AudioCount;i++)
            {
                MediaInfoWrapper.AudioTrack tempAudioTrack = info.Audio[i];
                InputFile infputFile = new InputFile();
                AudioTrack audioTrack = new AudioTrack();

                audioTrack.audioID = Int32.Parse(tempAudioTrack.ID);
                audioTrack.codec = new model.information.Codec(tempAudioTrack.CodecIDInfo, tempAudioTrack.CodecID);
                audioTrack.duration =long.Parse(tempAudioTrack.Duration);
                audioTrack.language = new Language(tempAudioTrack.LanguageString,tempAudioTrack.Language);
                audioTrack.title = tempAudioTrack.Title;

                audioTracks.Add(audioTrack);

            }
            file.audioTracks = audioTracks;

          String temp = file.ToString();
            return true;
        }

    }
}
