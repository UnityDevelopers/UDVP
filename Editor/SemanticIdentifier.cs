namespace Editor.UDV {
    public class SemanticIdentifier : IBuildIdentifier {
        private string Version;
        public SemanticIdentifier(string version) {
            Version = version;
        }

        public string GetIdentifier() {
            return Version;
        }
    }
}