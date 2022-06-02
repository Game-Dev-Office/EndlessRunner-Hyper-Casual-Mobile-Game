using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{

    public float scaleOfTomato = 0f;
    public float fullTomatoSize = 0.02f;
    public float increaseTomatoScale = 0.001f;
    public bool isAttachedToTree = true;
    public bool isPicked;
    public Transform playerHoldingPosObj;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(scaleOfTomato, scaleOfTomato, scaleOfTomato);
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleOfTomato < fullTomatoSize && isAttachedToTree)
        {
            scaleOfTomato += increaseTomatoScale * Time.deltaTime/2f;
            gameObject.name = "growingTomato";
        }

        if (isAttachedToTree && scaleOfTomato >= fullTomatoSize)
        {
            isAttachedToTree = true;
            isPicked = false;
            gameObject.name = "Tomato";
        }

        transform.localScale = transform.parent.InverseTransformVector(new Vector3(scaleOfTomato, scaleOfTomato, scaleOfTomato));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.name == "Tomato")
        {
            isAttachedToTree = false;
            isPicked = true;
            this.transform.position = playerHoldingPosObj.position;
            playerHoldingPosObj.transform.position += new Vector3(0, (float)0.25, 0);
            this.transform.parent = playerHoldingPosObj.parent;
        }
    }

}
