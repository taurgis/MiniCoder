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
        private XvidTemplate template;
        private TemplateForm view;
        private TemplateDao templateDao;

        public XvidTemplateController(TemplateForm view, XvidTemplate template)
        {
            this.template = template;
            this.view = view;
            templateDao = new TemplateDao();
        }

        private void RefreshView()
        {
            this.view.UpdateData(template);
        }

        public void ChangeBitrate(int compressionFactor)
        {
            this.template.BitRate = compressionFactor;            
            RefreshView();
        }

        public void ChangeQuantization(decimal quant)
        {
            this.template.Quantizer = quant;
            RefreshView();
        }

        public void ChangeThreads(int threads)
        {
            this.template.Threads = threads;
            RefreshView();
        }

        public void ChangeBFrames(int bframes)
        {
            if(bframes >= 0 && bframes <= 4)
                this.template.BFrames = bframes;
            RefreshView();
        }

        public void ChangeMode(int mode)
        {
            this.template.Mode = (XVidEncodingMode)mode;
            RefreshView();
        }

        public void ChangeVHQMode(int vhqMode)
        {
            this.template.VHQMode = (XVidVHQMode) vhqMode;
            RefreshView();
        }

        public void ChangeProfile(int profile)
        {
            this.template.Profile = (XVidProfile)profile;
            RefreshView();
        }

        public void ChangeHVSMasking(int hvsMode)
        {
            this.template.HVSMasking = (XVidHVSMasking)hvsMode;
            RefreshView();
        }

        public void ChangeMotionSearch(int motionSearch)
        {
            this.template.MotionSearch = (XVidMotionSearch)motionSearch;
            RefreshView();
        }
                        
        public void SelectInterlaced(bool interlaced)
        {
            this.template.Interlace= interlaced;
            RefreshView();
        }

        public void SelectTurbo(bool turbo)
        {
            this.template.Turbo = turbo;
            RefreshView();
        }

        public void SelectTrellisQuant(bool trellis)
        {
            this.template.TrellisQuant = trellis;
            RefreshView();
        }

        public void SelectPackedBitstream(bool pBitstream)
        {
            this.template.PackedBitstream = pBitstream;
            RefreshView();
        }

        public void SelectAdaptiveQuant(bool aQuant)
        {
            this.template.AdaptiveQuant = aQuant;
            RefreshView();
        }

        public void SelectQPel(bool qPel)
        {
            this.template.QPel = qPel;
            RefreshView();
        }

        public void SelectGMC(bool gmc)
        {
            this.template.GMC = gmc;
            RefreshView();
        }

        public void SelectChromaMotion(bool cMotion)
        {
            this.template.ChromaMotion = cMotion;
            RefreshView();
        }

        public void SelectVHQBFrames(bool vhqBframes)
        {
            this.template.VHQBFrames = vhqBframes;
            RefreshView();
        }

        public void SelectClosedGOP(bool closedGOP)
        {
            this.template.ClosedGOP = closedGOP;
            RefreshView();
        }

        /// <summary>
        /// Save a template to a file.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        public void SaveTemplate(String name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                this.template.Name = name;

                templateDao.SaveTemplate(template, typeof(XvidTemplate));
            }
        }

        /// <summary>
        /// Load a template from file.
        /// </summary>
        /// <param name="name">The name of the template.</param>
        public void LoadTemplate(String name)
        {
            this.template = (XvidTemplate)templateDao.LoadTemplate(name, typeof(XvidTemplate));
            view.UpdateData(this.template);
        }

        /// <summary>
        /// Get all templates for this type.
        /// </summary>
        /// <returns>Array of template names.</returns>
        public String[] FetchTemplateNames()
        {
            return templateDao.GetTemplatesByType(typeof(XvidTemplate));
        }

        /// <summary>
        /// Delete a template.
        /// </summary>
        /// <returns>Wether or not it was successfull.</returns>
        public Boolean DeleteTemplate()
        {
            return templateDao.DeleteTemplate(template.Name, typeof(XvidTemplate));
        }

        /// <summary>
        /// Export a template
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        /// <returns>Wether or not it was successfull.</returns>
        public Boolean ExportTemplate(String path)
        {
            return templateDao.ExportTemplate(this.template, typeof(XvidTemplate), path + "\\");
        }

        /// <summary>
        /// Import a template.
        /// </summary>
        /// <param name="path">The import file path.</param>
        /// <returns>The template class for the imported file.</returns>
        public ExtTemplate ImportTemplate(String path)
        {
            return templateDao.ImportTemplate(path, typeof(XvidTemplate));
        }
    }
 }