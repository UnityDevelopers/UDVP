using System;

namespace Editor.UDV {
    public class TimeStampIdentifier : IBuildIdentifier {
        private string Identifier;
        public TimeStampIdentifier() {
            Identifier = DateTime.Now.ToString("yMMddHHmm");
        }

        public string GetIdentifier() {
            return Identifier;
        }
    }
}
