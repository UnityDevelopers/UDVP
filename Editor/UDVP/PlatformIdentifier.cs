using UnityEngine;

namespace Editor.UDVP {
    public class PlatformIdentifier : IBuildIdentifier {
        public string GetIdentifier() {
            return Application.platform.ToString();
        }
    }
}