using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public bool isActive;

    public List<GameObject> numberOfWheat;
    public List<GameObject> numberOfTomato;
    public List<GameObject> numberOfDough;

    public GameObject doughPrefab;
    public GameObject pizzaPrefab;
    public GameObject pizzaSpawnStation;
    public GameObject doughSpawnStation;


    // Update is called once per frame
    void Update()
    {
        makeDough();
        makePizza();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.gameObject.name == "Tomato")
        {
            isActive = true;
            numberOfTomato.Add(other.GetComponentInChildren<Tomato>().gameObject);
            other.GetComponentInChildren<Tomato>().gameObject.transform.parent = this.transform.parent;

        }
        else if (other.tag == "Player" || other.gameObject.name == "Wheat")
        {
            isActive = true;
            numberOfWheat.Add(other.GetComponentInChildren<Wheat>().gameObject);
            other.GetComponentInChildren<Wheat>().gameObject.transform.parent = this.transform.parent;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = false;
        }
    }

    private void makeDough()
    {
        if (isActive && numberOfWheat.Count >= 2)
        {
            numberOfWheat.RemoveRange(0, 2);
            GameObject GO = Instantiate(doughPrefab, doughSpawnStation.transform.position, Quaternion.identity);
        }
    }

    private void makePizza()
    {
        if (isActive && numberOfDough.Count >= 1 && numberOfTomato.Count >= 1)
        {
            numberOfDough.RemoveRange(0, 1);
            numberOfTomato.RemoveRange(0, 1);
            GameObject GO = Instantiate(pizzaPrefab, pizzaSpawnStation.transform.position, Quaternion.Euler(-90, 0, 0));
        }
    }
}
