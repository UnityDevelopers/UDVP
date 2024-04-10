using System;

namespace UDV {
    public class TimeStampIdentifier : IBuildIdentifier {
        private string Identifier;
        public TimeStampIdentifier() {
            Identifier = DateTime.UtcNow.ToString("yyMMddHHmm");
        }

        public string GetIdentifier() {
            return Identifier.Substring(1);
        }
    }
}
