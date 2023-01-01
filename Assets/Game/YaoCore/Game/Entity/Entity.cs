using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityBaseProperties
{ 
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int MovementSpeed { get; set; }  
    public bool isMine { get; set; } 
    public Inventory Inventory { get; set; }
    public bool HasInventory;
}
  
public class Entity : MonoBehaviour
{
    public EntityBaseProperties props;
    public GameObject rootObject; 

    /// <summary>
    /// ��ƼƼ �ʱ�ȭ�� ���ؼ� ����Ѵ�. ȣ������ ������ ��ƼƼ�� ����� �� ����.
    /// </summary> 
    public void Iniitalize(EntityBaseProperties props, GameObject rootObject)
    {
        this.props = props;
        this.rootObject = rootObject;
    }
     
    public static Entity Create(string addressableKey, Vector3 worldPosition, Quaternion rotation, EntityBaseProperties entityBaseProps)
    {
        var instantiated = new GameObject();
        instantiated.name = addressableKey; 
        var entity = instantiated.AddComponent<Entity>();
        entity.Iniitalize(new EntityBaseProperties() { 
            Health = 1,
            isMine = true,
            MaxHealth = 0,
            MovementSpeed = 0
        }, instantiated);

        return entity;
    }

} 
