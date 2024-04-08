using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Editor.UDVP {
    class BuildPreprocess : IPreprocessBuildWithReport {
    
        public int callbackOrder { get { return 0; } }

        public List<IBuildIdentifier> Identifiers;

        public BuildPreprocess() {
            Identifiers = new List<IBuildIdentifier>();
            Identifiers.Add(new TimeStampIdentifier());
            Identifiers.Add(new PlatformIdentifier());
        }

        public void OnPreprocessBuild(BuildReport report) {
            string buildString = BuildString();
            Debug.Log($"BuildPreprocess.OnPreprocessBuild {buildString}");
            //PlayerSettings.bundleVersion = newVersion.ToString();
            //PlayerSettings.Android.bundleVersionCode = newVersion.Revision;
        }

        public string BuildString() {
            List<string> parts = new List<string>();

            foreach (var identifier in Identifiers) {
                parts.Add(identifier.GetIdentifier());
            }

            return string.Join("_", parts.ToArray());
        }
    }
}