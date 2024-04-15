using UDVP;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class EnvironmentIdentifier : IBuildIdentifier, IPreprocessBuildWithReport {

    public int callbackOrder => 1;

    public string GetIdentifier() {
        return Environment.Current.Name;
    }

    public void OnPreprocessBuild(BuildReport report) {
        Identifiers.Instance.Add(this);
    }
}
