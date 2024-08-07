using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class PreferencesService
    {
        private const string ColorPreferenceKey = "TableColor";

        public void SaveColor(string color)
        {
            Preferences.Set(ColorPreferenceKey, color);
        }

        public string LoadColor()
        {
            return Preferences.Get(ColorPreferenceKey, "#F2F2F2; color:black;");
        }
    }
}
