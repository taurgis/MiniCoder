using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using be.miniTech.minicoder.controller;
using be.miniTech.minicoder.model.inputfile;

namespace MiniCoder_Reloaded_Tests.MKV_Source_Tests
{
    [TestFixture]
    public class FetchFileInfoTests : AssertionHelper
    {
        [Test]
        public void checkAudioCount()
        {
            InputFile input = AnalysisController.fetchFileInfo("C:\\Users\\Thomas Theunen\\Downloads\\_5BRe-encoded_20by_20steveyk_5DKioBaJi-12.mkv");
            Assert.AreEqual(input.audioTracks.Count, 2);
        }
    }
}
