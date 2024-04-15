using UnityEditor;

namespace UDVP {
    public class PlatformIdentifier : IBuildIdentifier {
        public string GetIdentifier() {
            return EditorUserBuildSettings.activeBuildTarget.ToString();
        }
    }
}