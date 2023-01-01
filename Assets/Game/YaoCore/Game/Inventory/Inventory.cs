using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public int id;
    public bool stack;
    public int maxStack;
    public int count;
}

public class Slot
{
    public int id;
    public InventoryItem refItem;
}
 
/// <summary>
/// 자료구조, 인벤토리는 추가 삭제 위치정보 수정 정도만 가능하게 구현한다.
/// 아이템을 사용하거나 아이템에 보유에대한 부수효과 처리는 다른 클래스에서 인벤토리를 참조한다.
/// </summary>
public class Inventory
{
    private readonly List<InventoryItem> list;
    public int max;
    public Inventory(int max)
    {
        list = new List<InventoryItem>(max);
        this.max = max;
    }

    public List<InventoryItem> GetItems() => list;
    public bool HasItem(InventoryItem item) => list.Find(x => x.id == item.id) != null;
    public bool HasItem(int id) => list.Find(x => x.id == id) != null;

    public void AddItem(InventoryItem item)
    {
        if (item.count > 1)
        {
            if (item.count != item.maxStack) 
                item.count += 1; 
        }
        if (list.Count == max) throw new System.Exception("인벤토리에 공간이 없습니다.(not enough space in inventory)");
        list.Add(item);
    }
    public void RemoveItem(InventoryItem item)
    {
         
    }


    public void Swap(InventoryItem a, InventoryItem b)
    {
        var idx1 = list.FindIndex(x => x.id == a.id);
        var idx2 = list.FindIndex(x => x.id == b.id);
        list[idx1] = b;
        list[idx2] = a;
    }
}
