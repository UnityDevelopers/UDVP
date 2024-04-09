using UDV;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class EnvironmentIdentifier : IBuildIdentifier, IPreprocessBuildWithReport {
    public int callbackOrder => 1; // relative order of callback

    public string GetIdentifier() {
        return "SAMPLE"; //can be a static value from other class
    }

    public void OnPreprocessBuild(BuildReport report) {
        UDVIdentifiers.Instance.Add(this); //add identifier to build string
    }
}
