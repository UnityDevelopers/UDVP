using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Editor.UDV {
    public class UDVersioning : IPreprocessBuildWithReport {
        public int callbackOrder => 0;
        public readonly List<IBuildIdentifier> Identifiers = new();

        public static readonly UDVersioning Instance = new UDVersioning();
        
        private UDVersioning() {
        }

        public void OnPreprocessBuild(BuildReport report) {
            var timeStampIdentifier = new TimeStampIdentifier();

            List<IBuildIdentifier> identifiers = new List<IBuildIdentifier>();

            identifiers.Add(new SemanticIdentifier());
            identifiers.Add(timeStampIdentifier);
            identifiers.Add(new PlatformIdentifier());
            identifiers.AddRange(Identifiers);

            if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android) {
                PlayerSettings.Android.bundleVersionCode = int.Parse(timeStampIdentifier.GetIdentifier());
            }

            List<string> parts = new List<string>();

            foreach (var identifier in identifiers) {
                parts.Add(identifier.GetIdentifier());
            }

            string build = string.Join("-", parts.ToArray());
        }
    }
}