using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class BuildInfo : MonoBehaviour {
    public void BuildString(Action<string> callback) {
        StartCoroutine(LoadBuildInfo("build.txt", callback));
    }

    private IEnumerator LoadBuildInfo(string fileName, Action<string> onLoaded) {
        string url = $"{Application.streamingAssetsPath}/{fileName}";

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WebGLPlayer) {
            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success) {
                string content = request.downloadHandler.text;
                onLoaded?.Invoke(content);
            }
            else {
                Debug.LogWarning(request.error);
                onLoaded?.Invoke(Application.version);
            }
        }
        else {
            try {
                string content = File.ReadAllText(url);
                onLoaded?.Invoke(content);
            }
            catch (Exception ex) {
                Debug.LogWarning(ex.Message);
                onLoaded?.Invoke(Application.version);
            }
        }
    }
}