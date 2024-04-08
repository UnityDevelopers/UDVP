using System;

namespace Editor.UDV {
    public class TimeStampIdentifier : IBuildIdentifier {
        public string GetIdentifier() {
            return DateTime.Now.ToString("yyMMddHHmm");
        }
    }
}
