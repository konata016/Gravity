using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    Rigidbody rb;
    Vector3 startPos;

    bool isHitPl;
    float timer;

    public float time = 3f;
    public float leng = 15f;

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
        //timer += Time.deltaTime;


        //rb.MovePosition(new Vector3(startPos.x + Mathf.PingPong(timer * time, leng), startPos.y, startPos.z));
        //Debug.Log(Mathf.PingPong(timer * leng / time * 2, leng));

        //if (isHitPl && !Input.GetButtonDown("Jump"))
        //{
        //    GameObject.Find("UTC_Default").GetComponent<Rigidbody>().isKinematic = true;
        //}
        //if (Input.GetButton("Jump"))
        //{
        //    GameObject.Find("UTC_Default").GetComponent<Rigidbody>().isKinematic = false;
        //}

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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isHitPl = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isHitPl = false;
        }
    }
}
