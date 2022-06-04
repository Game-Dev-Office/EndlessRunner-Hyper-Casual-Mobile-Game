using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] int maxInvCapacity          = 8;
    [SerializeField] int invCapacity             = 0;
    int maxLemonCapacity        = 4;
    int lemonCount              = 0;
    
    
    public List<GameObject> Inventory;
    //public List<GameObject> stationInv;

    public bool isActive;

    public Transform holdPosition;
    public Transform itemSpawnPosition;
    public GameObject preparedItem;

   /* private void prepareItem()
    {
        /*
        if (isActive && Inventory.Count >= 2)
        {
            Inventory.RemoveRange(0, 2);
            GameObject GO = Instantiate(preparedItem, itemSpawnPosition.transform.position, Quaternion.identity);
            Destroy(GameObject.Find("stationed item"));
        }
        
        int lemonNo = 0;
        List<GameObject> tempObj = new List<GameObject>();

        foreach (var item in Inventory)
        {
            if (item.name == "Lemon")
            {
                lemonNo++;
                //tempObj.Add(item);
                Inventory.Add(maxLemonCapacity <= 4 ? item : null );
            }

            
            if (maxLemonCapacity >= 2)

            {
                    foreach (var _item in Inventory)
                    {
                        if(maxLemonCapacity >= 2)    
                        Inventory.Remove(_item);
                    }

                GameObject GO = Instantiate(preparedItem, itemSpawnPosition.position , Quaternion.identity);
                break;
            }
        }
    }*/

    public bool takeLemon(GameObject go, Player player)
    {
        if (lemonCount < maxLemonCapacity && invCapacity < maxInvCapacity)
        {
            player.Inventory.Remove(go);
            player.invCapacity--;

            Inventory.Add(go);
            go.transform.SetParent(transform);
            go.name = "stationed item";

            lemonCount++;
            invCapacity++;
            
            return true;
        }

        return false;
    }
}
