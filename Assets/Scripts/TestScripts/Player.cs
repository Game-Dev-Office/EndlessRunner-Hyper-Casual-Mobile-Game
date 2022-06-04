using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Station st = null;

    int maxInvCapacity = 8;
    public int invCapacity = 0;    
    public List<GameObject> Inventory = null;
    
    public Transform holdPosition;
    //public GameObject childObject;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "item")
        {
            if (invCapacity < maxInvCapacity)
            {
                Inventory.Add(other.gameObject);
                invCapacity++;
                other.gameObject.transform.SetParent(transform);
                other.gameObject.transform.position = holdPosition.transform.position;
                holdPosition.transform.position += new Vector3(0, other.gameObject.transform.localScale.y+0.1f, 0);
                Destroy(other.GetComponent<Collider>());
            }
        }

        /*if (other.gameObject.name == "Station")
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
        }*/

        else if (other.gameObject.name == "Station")
        {
            st = other.GetComponent<Station>();                             //Station componenti al�n�r
             
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i] != null)
                {
                    if (st.TakeItem(Inventory[i],this))                     //station i�indeki bool fonksiyonunda item al�m� ger�ekle�ir.
                    {
                        Debug.Log("ENVANTERE �STASYONA ALINDI");            //E�ya al�n�rsa al�nd���na dair olan olaylar burda olur
                    }
                    else
                    {
                        Debug.Log("ENVANTER DOLU OLDU�U ���N ALINAMADI");   //e�ya al�namazsa al�namad���na dair olan olaylar burda olur
                        break;
                    }
                }
            }
        }
    }
}
