using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{

    public Material dough;
    public Color uncooked = new Color(217, 224, 153, 255);
    public Color cooked = new Color(157, 161, 62, 255);
    public Color cooking;
    public float cookingSpeed;
    public float startTime;
    public float t;


    public bool isCooking;
    public bool isPicked;

    public Transform playerHoldingPosObj;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        dough.color = uncooked;
    }

    // Update is called once per frame
    void Update()
    {
        t = (Time.time - startTime) * cookingSpeed;
        dough.color = Color.Lerp(uncooked, cooked, t);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.name == "Pizza")
        {
            isCooking = false;
            isPicked = true;
            this.transform.position = playerHoldingPosObj.position;
            playerHoldingPosObj.transform.position += new Vector3(0, (float)0.25, 0);
            this.transform.parent = playerHoldingPosObj.parent;
        }
    }
}
