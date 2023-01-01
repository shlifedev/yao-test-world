using Jint;
using Jint.Native;
using Jint.Runtime.Interop;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpreterTest : MonoBehaviour
{
    PlayEngineWrapper engineWrap = new PlayEngineWrapper();
    public string script;
    private void OnGUI()
    {
        if(GUILayout.Button("Click Me"))
        {
            engineWrap.engine.Execute(script);
        }
    }
}
