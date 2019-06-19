using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    Rigidbody rb;

    public GameObject savePointObj;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputKey.isSavePos)
        {
            savePointObj.transform.position = transform.position;
        }

        if(InputKey.isTeleport)
        {
            rb.position = savePointObj.transform.position;
        }
    }
}
