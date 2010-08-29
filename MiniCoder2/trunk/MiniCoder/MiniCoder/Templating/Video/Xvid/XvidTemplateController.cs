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

        public void ChangeBitrate(int compressionFactor)
        {
            this.xTemplate.XBitRate = compressionFactor;            
            RefreshView();
        }

        public void ChangeQuantization(decimal quant)
        {
            this.xTemplate.XQuantizer = quant;
            RefreshView();
        }

        public void ChangeThreads(int threads)
        {
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
            this.xTemplate.XOptions["XInterlace"] = interlaced;
            RefreshView();
        }

        public void SelectTurbo(bool turbo)
        {
            this.xTemplate.XOptions["XTurbo"] = turbo;
            RefreshView();
        }

        public void SelectTrellisQuant(bool trellis)
        {
            this.xTemplate.XOptions["XTrellisQuant"] = trellis;
            RefreshView();
        }

        public void SelectPackedBitstream(bool pBitstream)
        {
            this.xTemplate.XOptions["XPackedBitstream"] = pBitstream;
            RefreshView();
        }

        public void SelectAdaptiveQuant(bool aQuant)
        {
            this.xTemplate.XOptions["XAdaptiveQuant"] = aQuant;
            RefreshView();
        }

        public void SelectQPel(bool qPel)
        {
            this.xTemplate.XOptions["XQPel"] = qPel;
            RefreshView();
        }

        public void SelectGMC(bool gmc)
        {
            this.xTemplate.XOptions["XGMC"] = gmc;
            RefreshView();
        }

        public void SelectChromaMotion(bool cMotion)
        {
            this.xTemplate.XOptions["XChromaMotion"] = cMotion;
            RefreshView();
        }

        public void SelectVHQBFrames(bool vhqBframes)
        {
            this.xTemplate.XOptions["XVHQBFrames"] = vhqBframes;
            RefreshView();
        }

        public void SelectClosedGOP(bool closedGOP)
        {
            this.xTemplate.XOptions["XClosedGOP"] = closedGOP;
            RefreshView();
        }
    }
}
