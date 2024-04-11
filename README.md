# UDVP - Unity Developers Versioning Package

## Design
Design and purpose is explained on [UDVP](https://reltimetech.atlassian.net/wiki/spaces/UD/pages/3000860684/UDVP+Unity+Developers+Versioning+Package)

## Package integration
To integrate it into a project please follow these steps:

1. Go to the [github repo](https://github.com/UnityDevelopers/UDVP) and download the code from the main branch in zip format.
2. Extract the contents of the zip file, it will create a directory named UDVP-main.
3. Rename the directory to just UDVP.
4. Copy the directory to the Packages directory of your Unity project.

Unity should detect UDVP as an embedded package.

## Package use
By default identifiers for app version, timestamp and platform are added to the build string. You can add new identifiers as follows.

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

        UDVIdentifiers.Instance.Add(this);
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
1. Go to the "Advanced Settings" tab of your Build Configuration.
2. Scroll to the "Script-hooks" section and set the field "Post-build script" to ```Packages/UDVP/post-build.sh```

## Samples
You can find sample scripts on the ```Samples```directory of the package.
