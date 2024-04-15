using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace UDVP {
    public class BuildString : MonoBehaviour {
        public void Load(Action<string> callback) {
            StartCoroutine(LoadBuildString("build.txt", callback));
        }

        private IEnumerator LoadBuildString(string fileName, Action<string> onLoaded) {
            string url = $"{Application.streamingAssetsPath}/{fileName}";

            if (Application.platform == RuntimePlatform.Android ||
                Application.platform == RuntimePlatform.WebGLPlayer) {
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
}