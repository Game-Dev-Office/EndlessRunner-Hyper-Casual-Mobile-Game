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
        List<GameObject> tempObj = new List<GameObject>();

        foreach (var item in Inventory)
        {
            if (item.name == "Lemon")
            {
                lemonNo++;
                //tempObj = tempObj == null ? item : tempObj; //Temp obje null ise itemi koysun, null deðilse tempobj olark devam etsin
                tempObj.Add(item);
            }

            if (lemonNo == 2)//Tam Buraya yorum satýrý ekledim


            //Branch conflict testi
            if (lemonNo == 2)

            {
                    //Inventory.Remove(item);
                    //Inventory.Remove(tempObj);

                    foreach (var _item in tempObj)
                    {
                        Inventory.Remove(_item);
                    }

                GameObject GO = Instantiate(preparedItem, itemSpawnPosition.transform.position, Quaternion.identity);
                break;
            }
        }


    }
}
