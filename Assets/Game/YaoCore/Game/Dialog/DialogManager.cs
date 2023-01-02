
using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogScript
{
    public int talker;
    public string dialog;
}

public class DIalogScriptExecutor : PlayEngineWrapper
{
    private DialogContext context;
    public DIalogScriptExecutor(DialogContext context, DialogManager manager)
    {
        engine.SetValue("DialogScript", typeof(DialogScript));
        engine.SetValue("push", new Action<string>((string v) =>
        {
            this.context.dialogs.Add(new DialogScript()
            {
                talker = 0,
                dialog = v
            });
        }));
        this.context = context;

    }
}

public class DialogContext
{
    public List<DialogScript> dialogs = new List<DialogScript>();
}
public class DialogManager : MonoBehaviour
{
    private DIalogScriptExecutor _executor;
    private DialogContext _context;
    public DialogContext Context => _context;
    private void SetCurrentContext(DialogContext context) { this._context = context; }
    public static DialogManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<DialogManager>();
            if (_instance.Context == null)
                _instance._context = new DialogContext();

            return _instance;
        }
    }
    private static DialogManager _instance;

    public void LoadScript(string filename)
    {
        string tempScript = @"
function enter(){
    console.log(push)
    console.log(DialogScript) 
}
";
        SetCurrentContext(new DialogContext());
        _executor = new DIalogScriptExecutor(_context, this);
        _executor.engine.Execute(tempScript);
        var invoker = _executor.engine.GetValue("enter");
        if(invoker != null)
        {
            var jsValue = invoker?.Invoke(); 
        }
        else
        {
            throw new Exception("dialog load failgure");
        }
    }

    public void Show() { }
    public void Hide() { }
    public void Push(string value) { }

    void OnGUI()
    {
        if (GUILayout.Button("Load Dialog"))
        {
            this.LoadScript(null);
        }
    }
}


