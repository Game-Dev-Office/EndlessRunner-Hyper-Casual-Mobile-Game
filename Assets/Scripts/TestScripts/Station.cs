using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public int maxInvCapacity;
    public int invCapacity;
    public List<GameObject> Inventory;

    public bool isActive;

    public GameObject holdPosition;
    public GameObject itemSpawnPosition;
    public GameObject preparedItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        prepareItem();
    }

    private void prepareItem()
    {
        /*
        if (isActive && Inventory.Count >= 2)
        {
            Inventory.RemoveRange(0, 2);
            GameObject GO = Instantiate(preparedItem, itemSpawnPosition.transform.position, Quaternion.identity);
            Destroy(GameObject.Find("stationed item"));
        }
        */
        int lemonNo = 0;
        GameObject tempObj;

        foreach (var item in Inventory)
        {
            if (item.name == "Lemon")
            {
                lemonNo++;
                tempObj = item;
            }

            if (lemonNo == 2)
            {
                Inventory.Remove(item);

                GameObject GO = Instantiate(preparedItem, itemSpawnPosition.transform.position, Quaternion.identity);
                break;
            }
        }


    }
}
