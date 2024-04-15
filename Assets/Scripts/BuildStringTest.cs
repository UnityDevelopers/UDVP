using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UDVP;
using UnityEngine;

public class BuildStringTest : MonoBehaviour {
    public TMP_Text Info;

    private void Start() {
        GetComponent<BuildString>().Load(s => Info.text = s);
    }
}