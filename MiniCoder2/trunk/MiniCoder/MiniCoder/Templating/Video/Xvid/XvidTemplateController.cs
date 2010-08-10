using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniCoder2.Templating.Files;

namespace MiniCoder2.Templating.Video.Xvid
{
    class XvidTemplateController
    {
        private XvidTemplate xTemplate;
        private TemplateForm xView;
        private TemplateDao xTemplateDao;

        public XvidTemplateController(TemplateForm view, XvidTemplate template)
        {
            this.xTemplate = template;
            this.xView = view;
            xTemplateDao = new TemplateDao();
        }

        private void RefreshView()
        {
            this.xView.UpdateData(xTemplate);
        }

        public void ChangeMode(int mode)
        {
            this.xTemplate.XMode = (XvidEncodingMode) mode;
            RefreshView();
        }

        public void ChangeBitrate(int bitrate)
        {
            if(bitrate > 0 && bitrate < 10000)
                this.xTemplate.XBitRate = bitrate;

            RefreshView();
        }

        public void ChangeVHQMode(int vhqMode)
        {
            this.xTemplate.XVHQMode = (XvidVHQMode) vhqMode;
            RefreshView();
        }

        public void ChangeThreads(int threads)
        {
            this.xTemplate.XThreads = threads;
            RefreshView();
        }

        public void ChangeHVSMasking(int hvsMode)
        {
            this.xTemplate.XHVSMasking = (XVidHVSMasking) hvsMode;
            RefreshView();
        }

        public void ChangeMotionSearch(int motionSearch)
        {
            this.xTemplate.XMotionSearch = (XVidMotionSearch) motionSearch;
        }

        public void SelectInterlaced()
        {

        }

        public void SelectTurbo()
        {

        }

        public void SelectTrellisQuant()
        {

        }

        public void SelectPackedBitstream()
        {

        }

        public void SelectAdaptiveQuant()
        {

        }

        public void SelectQPel()
        {

        }

        public void SelectGMC()
        {

        }

        public void SelectChromaMotion()
        {

        }

        public void SelectVHQBFrames()
        {

        }

        public void SelectClosedGOP()
        {

        }
    }
}
