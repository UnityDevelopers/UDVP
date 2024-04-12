using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace UDV {
    public class UDVersioning : IPreprocessBuildWithReport {
        public int callbackOrder => int.MaxValue;

        public void OnPreprocessBuild(BuildReport report) {
            var timeStampIdentifier = new TimeStampIdentifier();

            List<IBuildIdentifier> identifiers = new List<IBuildIdentifier>();

            identifiers.Add(new SemanticIdentifier());
            identifiers.Add(timeStampIdentifier);
            identifiers.Add(new PlatformIdentifier());
            identifiers.AddRange(UDVIdentifiers.Instance.Identifiers);

            if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android) {
                PlayerSettings.Android.bundleVersionCode = int.Parse(timeStampIdentifier.GetIdentifier());
            }

            List<string> parts = new List<string>();

            foreach (var identifier in identifiers) {
                parts.Add(identifier.GetIdentifier());
            }

            string build = string.Join("-", parts.ToArray()).ToLower();

            WriteFile(build);
        }

        private void WriteFile(string build) {
            Debug.Log($"BuildString is {build}");
            File.WriteAllText(Path.Combine(Application.dataPath,"StreamingAssets", "build.txt"), build);
        }
        

    }
}