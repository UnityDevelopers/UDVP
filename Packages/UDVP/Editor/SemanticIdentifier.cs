using UnityEditor;

namespace UDV {
    public class SemanticIdentifier : IBuildIdentifier {
       
        public string GetIdentifier() {
            return PlayerSettings.bundleVersion;
        }
    }
}