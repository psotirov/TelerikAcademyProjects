using System;

namespace _11_Version_Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Enum | 
        AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Struct, AllowMultiple=true, Inherited=true)]
    public class VersionAttribute : Attribute
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }

        public VersionAttribute(string ver)
        {
            string[] v = ver.Split('.'); // parses version info as major and minor part
            this.Major = int.Parse(v[0]);
            this.Minor = int.Parse(v[1]);
        }

        public override string ToString()
        {
            return String.Format("Version: {0}.{1}", this.Major, this.Minor); // outputs the version info
        }
    }
}
