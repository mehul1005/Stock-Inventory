using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Inventory
{
    public class IniFile
    {
        private string filePath;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        public IniFile(string fileName)
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, filePath);
        }

        public string Read(string section, string key, string defaultValue)
        {
            const int initialBufferSize = 2048; // Use a larger initial buffer size

            StringBuilder sb = new StringBuilder(initialBufferSize);
            uint bytesRead = GetPrivateProfileString(section, key, defaultValue, sb, (uint)sb.Capacity, filePath);

            if (bytesRead == sb.Capacity - 1)
            {
                // The retrieved string might be truncated
                // Keep reading in chunks until we get the full value
                while (true)
                {
                    sb.Capacity += initialBufferSize;
                    uint additionalBytesRead = GetPrivateProfileString(section, key, defaultValue, sb, (uint)sb.Capacity, filePath);
                    if (additionalBytesRead < sb.Capacity - 1)
                    {
                        break;
                    }
                }
            }

            return sb.ToString();
        }
    }
}
