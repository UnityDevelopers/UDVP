using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace UDVP {
    public class Identifiers : IPreprocessBuildWithReport {
        public int callbackOrder => int.MinValue;

        internal List<IBuildIdentifier> CustomIdentifiers;
        public static Identifiers Instance;

        public void OnPreprocessBuild(BuildReport report) {
            CustomIdentifiers = new List<IBuildIdentifier>();
            Instance = this;
        }

        public void Add(IBuildIdentifier identifier) {
            CustomIdentifiers.Add(identifier);
        }
    }
}