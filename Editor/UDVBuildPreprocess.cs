using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor.UDV {
    public abstract class UDVBuildPreprocess {
        protected readonly List<IBuildIdentifier> Identifiers = new ();
        
        protected void AddDefaultIdentifiers(string version) {
            Identifiers.Add(new SemanticIdentifier(version));
            Identifiers.Add(new TimeStampIdentifier());
            Identifiers.Add(new PlatformIdentifier());
        }

        protected void SetBuildString() {
            PlayerSettings.bundleVersion = BuildString();
            PlayerSettings.Android.bundleVersionCode = VersionCode();

            Debug.Log($"Bundle version is {PlayerSettings.bundleVersion}");
        }

        private string BuildString() {
            List<string> parts = new List<string>();

            foreach (var identifier in Identifiers) {
                parts.Add(identifier.GetIdentifier());
            }

            return string.Join("-", parts.ToArray());
        }

        private int VersionCode() {
            PlayerSettings.Android.bundleVersionCode++;
            return PlayerSettings.Android.bundleVersionCode;
        }
    }
}