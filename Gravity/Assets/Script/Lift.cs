using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    Rigidbody rb;
    Vector3 startPos;
    bool isMoveEnd;
    bool isSwitch;

    public float speed;
    public float goalPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //右に移動
        if (transform.position.x <= startPos.x + goalPos && !isSwitch)
        {
            //慣性の消去
            if (!isMoveEnd)
            {
                rb.isKinematic = true;
                rb.isKinematic = false;
                isMoveEnd = true;
            }

            rb.AddForce(speed * ((Vector3.right * speed) - rb.velocity), ForceMode.Acceleration);
        }
        else isSwitch = true;

        //左に移動
        if (transform.position.x >= startPos.x && isSwitch)
        {
            //慣性の消去
            if (isMoveEnd)
            {
                rb.isKinematic = true;
                rb.isKinematic = false;
                isMoveEnd = false;
            }

            rb.AddForce(speed * ((Vector3.left * speed) - rb.velocity), ForceMode.Acceleration);
        }
        else isSwitch = false;
    }
}
