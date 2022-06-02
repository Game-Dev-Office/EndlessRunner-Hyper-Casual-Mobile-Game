using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{

    public float scaleOfWheat = 0f;
    public float fullWheatSize = 0.5f;
    public float increaseWheatScale = 0.001f;
    public bool isAttachedToTree = true;
    public bool isPicked;
    public Transform playerHoldingPosObj;
    public Transform doughSpawn;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.1f, scaleOfWheat, 0.3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleOfWheat < fullWheatSize && isAttachedToTree)
        {
            scaleOfWheat += increaseWheatScale * Time.deltaTime / 2f;
            gameObject.name = "growingWheat";
        }

        if (isAttachedToTree && scaleOfWheat >= fullWheatSize)
        {
            isAttachedToTree = true;
            isPicked = false;
            gameObject.name = "Wheat";
        }

        transform.localScale = transform.parent.InverseTransformVector(new Vector3(0.1f, scaleOfWheat, 0.3f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.name == "Wheat")
        {
            isAttachedToTree = false;
            isPicked = true;
            this.transform.position = playerHoldingPosObj.position;
            playerHoldingPosObj.transform.position += new Vector3(0, (float)0.25, 0);
            this.transform.parent = playerHoldingPosObj.parent;
        }

        if (other.tag == "Counter")
        {
            isAttachedToTree = false;
            isPicked = true;
            this.transform.position = doughSpawn.position;
            doughSpawn.transform.position += new Vector3(0, (float)0.25, 0);

        }

    }

}
