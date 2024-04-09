using UnityEditor;

namespace UDV {
    public class PlatformIdentifier : IBuildIdentifier {
        public string GetIdentifier() {
            return EditorUserBuildSettings.activeBuildTarget.ToString();
        }
    }
}