using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace UDV {
    public class UDVIdentifiers : IPreprocessBuildWithReport {
        public int callbackOrder => int.MinValue;

        internal List<IBuildIdentifier> Identifiers;
        public static UDVIdentifiers Instance;

        public void OnPreprocessBuild(BuildReport report) {
            Identifiers = new List<IBuildIdentifier>();
            Instance = this;
        }

        public void Add(IBuildIdentifier identifier) {
            Identifiers.Add(identifier);
        }
    }
}