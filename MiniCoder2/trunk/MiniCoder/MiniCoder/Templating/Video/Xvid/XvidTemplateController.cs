using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniCoder2.Templating.Files;

namespace MiniCoder2.Templating.Audio.Xvid
{
    class XvidTemplateController
    {
        private XvidTemplate xTemplate;
        private TemplateForm xView;
        private TemplateDao xTemplateDao;

        public XvidTemplateController(XvidTemplate template, TemplateForm view)
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
    }
}
