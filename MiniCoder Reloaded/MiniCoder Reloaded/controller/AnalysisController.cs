using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using be.miniTech.minicoder.model.inputfile;
using be.miniTech.minicoder.model.information;
using be.miniTech.minicoder.dao;

namespace be.miniTech.minicoder.controller
{
    public class AnalysisController
    {
        private CodecDao codecDao;

        public AnalysisController()
        {
            this.codecDao = new CodecDao();
        }


        public InputFile fetchFileInfo(String fileName)
        {
            MediaInfoWrapper.MediaInfo info = new MediaInfoWrapper.MediaInfo(fileName);
            InputFile file = new InputFile();

            file.audioTracks = fetchAudioTracks(info);
            file.videoTracks = fetchVideoTracks(info);
            file.subtitleTracks = fetchSubtitleTracks(info);
            file.hasChapters = (info.ChaptersCount > 0 ? true : false);

            return file;
        }

        private List<SubtitleTrack> fetchSubtitleTracks(MediaInfoWrapper.MediaInfo info)
        {
            List<SubtitleTrack> subtitleTracks = new List<SubtitleTrack>();
            for (int i = 0; i < info.VideoCount; i++)
            {
                MediaInfoWrapper.TextTrack tempSubtitleTrack = info.Text[i];
                SubtitleTrack subtitleTrack = new SubtitleTrack();

                subtitleTrack.id = tempSubtitleTrack.ID;
                subtitleTrack.codec = codecDao.getCodecByKey(tempSubtitleTrack.Codec);

                subtitleTracks.Add(subtitleTrack);
            }
            return subtitleTracks;
        }

        private List<VideoTrack> fetchVideoTracks(MediaInfoWrapper.MediaInfo info)
        {
            List<VideoTrack> videoTracks = new List<VideoTrack>();
            for (int i = 0; i < info.VideoCount; i++)
            {
                MediaInfoWrapper.VideoTrack tempVideoTrack = info.Video[i];
                VideoTrack videoTrack = new VideoTrack();

                videoTrack.id = tempVideoTrack.ID;
                videoTrack.title = tempVideoTrack.Title;
                videoTrack.language = new Language(tempVideoTrack.LanguageString, tempVideoTrack.Language);
                videoTrack.codec = codecDao.getCodecByKey(tempVideoTrack.CodecID);
                videoTrack.duration = long.Parse(tempVideoTrack.Duration);
                videoTrack.frameCount = long.Parse(tempVideoTrack.FrameCount);
                videoTrack.frameRate = Double.Parse(tempVideoTrack.FrameRate.Replace(".", ","));

                videoTracks.Add(videoTrack);
            }
            return videoTracks;
        }

        private List<AudioTrack> fetchAudioTracks(MediaInfoWrapper.MediaInfo info)
        {
            List<AudioTrack> audioTracks = new List<AudioTrack>();
            for (int i = 0; i < info.AudioCount; i++)
            {
                MediaInfoWrapper.AudioTrack tempAudioTrack = info.Audio[i];
                AudioTrack audioTrack = new AudioTrack();

                audioTrack.audioID = Int32.Parse(tempAudioTrack.ID);
                audioTrack.codec = codecDao.getCodecByKey(tempAudioTrack.CodecID);
                audioTrack.duration = long.Parse(tempAudioTrack.Duration);
                audioTrack.language = new Language(tempAudioTrack.LanguageString, tempAudioTrack.Language);
                audioTrack.title = tempAudioTrack.Title;

                audioTracks.Add(audioTrack);
            }
            return audioTracks;
        }

    }
}
