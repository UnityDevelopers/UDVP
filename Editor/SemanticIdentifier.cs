using UnityEditor;

namespace Editor.UDV {
    public class SemanticIdentifier : IBuildIdentifier {
       
        public string GetIdentifier() {
            return PlayerSettings.bundleVersion;
        }
    }
}