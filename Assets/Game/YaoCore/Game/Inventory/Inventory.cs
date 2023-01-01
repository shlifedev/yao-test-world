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
/// �ڷᱸ��, �κ��丮�� �߰� ���� ��ġ���� ���� ������ �����ϰ� �����Ѵ�.
/// �������� ����ϰų� �����ۿ� ���������� �μ�ȿ�� ó���� �ٸ� Ŭ�������� �κ��丮�� �����Ѵ�.
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
        if (list.Count == max) throw new System.Exception("�κ��丮�� ������ �����ϴ�.(not enough space in inventory)");
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
