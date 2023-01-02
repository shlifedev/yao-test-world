
using Jint;
using System.Collections.Generic;

public class CustomConsole
{
    public void log(object o) => UnityEngine.Debug.Log(o);
}

public class UISystem
{
    
}
 
public class PlayEngineWrapper
{
    public static readonly Dictionary<string, object> GlobalObject = new Dictionary<string, object>() {
        {  "log", new System.Action<object>((o)=>UnityEngine.Debug.Log(o)) }, 
    };

    public Engine engine;
    public PlayEngineWrapper()
    { 
        engine = new Engine(cfg => {
            cfg.AllowClr(typeof(UnityEngine.GameObject).Assembly);
        });
        engine.SetValue("console", new CustomConsole());
        engine.SetValue("UnityEngine.GameObject", typeof(UnityEngine.GameObject));
        engine.SetValue("UnityEngine.Vector3", typeof(UnityEngine.Vector3)); 
    }
}

 