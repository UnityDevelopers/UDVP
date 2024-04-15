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
            var semanticIdentifier = new SemanticIdentifier().GetIdentifier();
            var timeStampIdentifier = new TimeStampIdentifier().GetIdentifier();

            List<IBuildIdentifier> identifiers = new List<IBuildIdentifier>();

            identifiers.Add(new PlatformIdentifier());
            identifiers.AddRange(UDVIdentifiers.Instance.Identifiers);

            if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android) {
                PlayerSettings.Android.bundleVersionCode = int.Parse(timeStampIdentifier);
            }

            string build = $"{semanticIdentifier}.{timeStampIdentifier}";

            foreach (var identifier in identifiers) {
                build += $"-{identifier.GetIdentifier().ToLower()}";
            }

            WriteFile(build);
        }

        private void WriteFile(string build) {
            Debug.Log($"BuildString is {build}");
            File.WriteAllText(Path.Combine(Application.dataPath,"StreamingAssets", "build.txt"), build);
        }
        

    }
}