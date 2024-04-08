using System;

namespace Editor.UDVP {
    public class TimeStampIdentifier : IBuildIdentifier {
        public string GetIdentifier() {
            return DateTime.Now.ToString("yyMMddHHmm");
        }
    }
}
