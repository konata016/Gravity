using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody rb;
    Vector3 plPos;
    Vector3 pos;
    GameObject pl;

    public float maxDis = 20f;
    public float speed = 3f;

    enum DIR
    {
        Forward, Back,
        Right, Left
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = transform.position;
        pl = GameObject.Find("UTC_Default");
    }

    // Update is called once per frame
    void Update()
    {
        plPos = pl.transform.position;
        float dis = Vector3.Distance(plPos, transform.position);

        if (dis < maxDis && IsGround.isReady)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(plPos.x, pos.y, plPos.z), speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            Destroy(gameObject);
        }
    }
}
