using System;

namespace MVC_Playground.PageLibrary
{
    public class MvcPlaygroundSettings
    {
        public string BaseUrl { get; private set; }

        public string FirefoxBinaryPath { get; set; }

        private static MvcPlaygroundSettings _settings;
        public static MvcPlaygroundSettings CurrentSettings
        {
            get
            {
                if (_settings == null)
                {
                    LoadSettings("TestRun.config");
                }
                return _settings;
            }
        }

        private MvcPlaygroundSettings(string url)
        {
            BaseUrl = url;
        }

        private static void LoadSettings(String file)
        {
            //var settingsFile = XElement.Load(file);
            //var xElement = settingsFile.Element("URL");
            //if (xElement != null)
            //{
            //    var url = xElement.Value;
            //    _settings = new MvcPlaygroundSettings(url);
            //}
            _settings = new MvcPlaygroundSettings("http://localhost:19131/");
        }
    }
}