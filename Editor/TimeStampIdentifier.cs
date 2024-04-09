using System;

namespace UDV {
    public class TimeStampIdentifier : IBuildIdentifier {
        private string Identifier;
        public TimeStampIdentifier() {
            Identifier = DateTime.Now.ToString("yyMMddHHmm");
        }

        public string GetIdentifier() {
            return Identifier.Substring(1);
        }
    }
}
