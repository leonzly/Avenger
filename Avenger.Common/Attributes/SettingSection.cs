using System;

namespace Avenger.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SettingSection : Attribute
    {
        public string SectionKey { get; }
        public SettingSection(string sectionKey) {
            SectionKey = sectionKey;
        }
    }
}
