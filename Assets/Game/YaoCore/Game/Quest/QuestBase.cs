using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����Ʈ ���� ����
/// </summary>
public class QuestBase : MonoBehaviour
{
    public enum Type
    {
        Collect,
        Kill,
        Delive,
        DeliveSeveral,

    }
    public int questGiverId; 

    public bool CheckComplete()
    {
        return false;
    }

    public int ProgressCount()
    {
        return 1;
    }

    public int RequireProgressCount()
    {
        return 1;
    }
}
