using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialog {
    public int talker;
    public string dialog; 
    
}

public class QuestContext
{ 
    public List<QuestDialog> questDialogs = new List<QuestDialog>();

    public QuestContext(List<QuestDialog> questDialogs)
    {
        this.questDialogs = questDialogs;
    }
}
/// <summary>
/// 퀘스트 수행 내용
/// </summary>
public class QuestManager : MonoBehaviour
{
    public PlayEngineWrapper play = new PlayEngineWrapper();
    public void LoadQuestScript()
    {
        play.engine.Execute(@"
function enter(){
    
}
");
    }
}
