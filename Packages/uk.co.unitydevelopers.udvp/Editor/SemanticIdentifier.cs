using UnityEditor;

namespace UDVP {
    public class SemanticIdentifier : IBuildIdentifier {
       
        public string GetIdentifier() {
            return PlayerSettings.bundleVersion;
        }
    }
}