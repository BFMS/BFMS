using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class Config
    {
        public static bool IsDBLogging = false;
        public static bool IsEMail = false;
        public static bool IsSMS = false;
        public static Mode ServiceMode = Mode.DB;

        public enum Mode
        {
            DB,
            API,
        };
    }
}
