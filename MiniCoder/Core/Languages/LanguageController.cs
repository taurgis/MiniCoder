﻿//    MiniCoder
//    Copyright (C) 2009-2010  MiniTech support@minitech.org
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using MiniTech.MiniCoder.Core.Other.Logging;

namespace MiniTech.MiniCoder.Core.Languages
{
    public sealed class LanguageController
    {
        private CultureInfo culture;
        private static LanguageController instance = null;

        public static LanguageController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LanguageController();

                return instance;
            }
        }

        public void setLanguage(int languageCode)
        {
            LogBookController.Instance.addLogLine("Loading language with code " + languageCode, LogMessageCategories.Debug);

            switch (languageCode)
            {
                case 0:
                    culture = CultureInfo.CreateSpecificCulture("");
                    break;
                case 1:
                    culture = CultureInfo.CreateSpecificCulture("nl-NL");
                    break;
                case 2:
                    culture = CultureInfo.CreateSpecificCulture("pt-BR");
                    break;
                case 3:
                    culture = CultureInfo.CreateSpecificCulture("tr-TR");
                    break;
                case 4:
                    culture = CultureInfo.CreateSpecificCulture("fr-FR");
                    break;
                default:
                    culture = CultureInfo.CreateSpecificCulture("");
                    break;
            }
        }

        public String getLanguageString(String stringName)
        {
            LogBookController.Instance.addLogLine("Fetching " + stringName + " from language file.", LogMessageCategories.Debug);

            ResourceManager rm = ResourceManager.CreateFileBasedResourceManager("language", Application.StartupPath + "/languages", null);
            return rm.GetString(stringName, culture);
        }
    }
}