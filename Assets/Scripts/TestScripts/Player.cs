using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxInvCapacity;
    public int invCapacity;    
    public List<GameObject> Inventory;
    
    public GameObject holdPosition;
    public GameObject childObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "item")
        {
            if (invCapacity < maxInvCapacity)
            {
                Inventory.Add(other.gameObject);
                invCapacity++;
                other.gameObject.transform.SetParent(this.transform);
                other.gameObject.transform.position = holdPosition.transform.position;
                holdPosition.transform.position += new Vector3(0, other.gameObject.transform.localScale.y+0.1f, 0);
            }
        }

        if (other.gameObject.name == "Station")
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i].GetComponent<Item>().itemData.displayName == "Lemon")
                {
                    childObject = Inventory[i];

                    if (other.GetComponent<Station>().invCapacity < other.GetComponent<Station>().maxInvCapacity)
                    {
                        Inventory.Remove(childObject);
                        invCapacity--;
                        childObject.transform.SetParent(other.gameObject.transform);
                        childObject.name = "stationed item";
                        other.GetComponent<Station>().Inventory.Add(childObject);
                        other.GetComponent<Station>().invCapacity++;

                    }

                }
            }            
        }
    }
}
