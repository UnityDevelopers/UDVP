# UDVP - Unity Developers Versioning Package

## Design
Design and purpose is explained on [UDVP](https://reltimetech.atlassian.net/wiki/spaces/UD/pages/3000860684/UDVP+Unity+Developers+Versioning+Package)

## Package integration
To integrate it into a project please follow these steps:

1. Go to the Package Manager window on your Unity Project.
2. Click on the ```+``` button and select "Add package from git URL" 
3. Paste the following URL in the field: ```https://github.com/UnityDevelopers/UDVP.git?path=/Packages/uk.co.unitydevelopers.udvp```
4. Click the "Add" button

This should add the UDVP package to your project.

## Package use
Identifiers for app version, timestamp and platform are added by default to the build string. You can add new identifiers as follows.

### Add a new identifier
1. Create a class inside ```Assets/Editor``` folder of your project.
2. Make your class implement interfaces ```IBuildIdentifier``` and ```IPreprocessBuildWithReport```.
3. Method ```GetIdentifier``` must return the string you want to be added to the build string.
4. In method ```OnPreprocessBuild``` you can make some setup if needed.
5. In method ```OnPreprocessBuild``` you must add the identifier to the list of identifiers by adding current instance to identifiers.

#### Example

```csharp
public void OnPreprocessBuild(BuildReport report) {
       //... some setup if needed

        Identifiers.Instance.Add(this);
}
```
6. The ```callbackOrder``` property is used for the relative order of the identifiers.

Please note this is called in build time and not in runtime so access to some Unity API's is not possible. Most static methods should be fine.

### Read current build string
To read the current build string on runtime:
1. Add the script ```BuildString``` to a GameObject. This is available on ```Runtime``` directory of the package.
2. Get the ```BuildString``` component and call its ```Load``` method.
3. You should pass a callback that will be called with the build string value.

#### Example
```csharp
...
public TMP_Text Info;

private void Start() {
    GetComponent<BuildString>().Load(s => Info.text = s);
}
...
```

## Cloud build
To set the build string as the label for a cloud build:
1. Copy the file ```post-build.sh``` from the package contents to the root of your project
1. Go to the "Advanced Settings" tab of your Build Configuration on Web Dashboard.
2. Scroll to the "Script-hooks" section and set the field "Post-build script" to ```post-build.sh```

## Samples
You can find sample scripts on the ```Samples``` directory of the package.
