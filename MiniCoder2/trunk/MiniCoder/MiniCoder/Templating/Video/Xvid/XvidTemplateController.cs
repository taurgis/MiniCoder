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

        public void ChangeBitrate(int bitrate)
        {
            if(bitrate > 0 && bitrate <= 10000)
                this.xTemplate.XBitRate = bitrate;
            RefreshView();
        }

        public void ChangeThreads(int threads)
        {
            if(threads > 0 && threads <= 100)
                this.xTemplate.XThreads = threads;
            RefreshView();
        }

        public void ChangeBFrames(int bframes)
        {
            if(bframes >= 0 && bframes <= 4)
                this.xTemplate.XBFrames = bframes;
            RefreshView();
        }

        public void ChangeMode(int mode)
        {
            this.xTemplate.XMode = (XVidEncodingMode)mode;
            RefreshView();
        }

        public void ChangeVHQMode(int vhqMode)
        {
            this.xTemplate.XVHQMode = (XVidVHQMode) vhqMode;
            RefreshView();
        }

        public void ChangeProfile(int profile)
        {
            this.xTemplate.XProfile = (XVidProfile)profile;
            RefreshView();
        }

        public void ChangeHVSMasking(int hvsMode)
        {
            this.xTemplate.XHVSMasking = (XVidHVSMasking)hvsMode;
            RefreshView();
        }

        public void ChangeMotionSearch(int motionSearch)
        {
            this.xTemplate.XMotionSearch = (XVidMotionSearch)motionSearch;
            RefreshView();
        }
                        
        public void SelectInterlaced(bool interlaced)
        {
            this.xTemplate.XInterlace = interlaced;
            RefreshView();
        }

        public void SelectTurbo(bool turbo)
        {
            this.xTemplate.XTurbo = turbo;
            RefreshView();
        }

        public void SelectTrellisQuant(bool trellis)
        {
            this.xTemplate.XTrellisQuant = trellis;
            RefreshView();
        }

        public void SelectPackedBitstream(bool pBitstream)
        {
            this.xTemplate.XPackedBitstream = pBitstream;
            RefreshView();
        }

        public void SelectAdaptiveQuant(bool aQuant)
        {
            this.xTemplate.XAdaptiveQuant = aQuant;
            RefreshView();
        }

        public void SelectQPel(bool qPel)
        {
            this.xTemplate.XQPel = qPel;
            RefreshView();
        }

        public void SelectGMC(bool gmc)
        {
            this.xTemplate.XGMC = gmc;
            RefreshView();
        }

        public void SelectChromaMotion(bool cMotion)
        {
            this.xTemplate.XChromaMotion = cMotion;
            RefreshView();
        }

        public void SelectVHQBFrames(bool vhqBframes)
        {
            this.xTemplate.XVHQBFrames = vhqBframes;
            RefreshView();
        }

        public void SelectClosedGOP(bool closedGOP)
        {
            this.xTemplate.XClosedGOP = closedGOP;
            RefreshView();
        }
    }
}
