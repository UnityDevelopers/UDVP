using UnityEditor;

namespace Editor.UDV {
    public class PlatformIdentifier : IBuildIdentifier {
        public string GetIdentifier() {
            return EditorUserBuildSettings.activeBuildTarget.ToString();
        }
    }
}