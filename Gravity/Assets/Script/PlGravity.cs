﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlGravity : MonoBehaviour
{
    Rigidbody rb;
    Quaternion ang;
    Vector3 gravityForth;
    Vector3 saveGravityForth;
    Vector3 pos;

    float sid;
    float fixPos;
    string saveGroundName;

    public float gravity = 200f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravityForth = Vector3.down * gravity;
        ang.eulerAngles = new Vector3(0, sid, 0);
    }

    // Update is called once per frame
    void Update()
    {
        pos = rb.position;

        if (!Input.GetKey(KeyCode.Alpha6) && !Input.GetKey(KeyCode.Alpha4) &&
            !Input.GetKey(KeyCode.Alpha8) && !Input.GetKey(KeyCode.Alpha2))
        {
            //向きを変える
            rb.rotation = ang;
            Debug.Log(saveGravityForth);
            //重力の移動処理
            rb.AddForce(gravityForth);
        }
        else gravityForth = saveGravityForth;

        //gravityForthがゼロになるのでバグが起きる

        //位置修正
        switch (saveGroundName)
        {
            case "GroundForward":
            case "GroundBack":
            case "GroundUp":
            case "GroundDown":
                transform.position = Vector3.MoveTowards(rb.position, new Vector3(pos.x, pos.y, fixPos), 10);
                break;

            case "GroundRight":
            case "GroundLeft":
                transform.position = Vector3.MoveTowards(rb.position, new Vector3(pos.x, fixPos, pos.z), 10);
                break;

            default: break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        rb.velocity = Vector3.zero;
        gravityForth = Vector3.zero;

        //重力が発生する場所の名前を保存
        if (other.gameObject.tag != "Ground") saveGroundName = other.gameObject.tag;

        //重力の力の向き
        switch (other.gameObject.tag)
        {
            case "GroundForward":
                gravityForth = Vector3.forward * gravity;
                fixPos = other.transform.root.transform.position.y;
                break;

            case "GroundBack":
                gravityForth = Vector3.back * gravity;
                fixPos = other.transform.root.transform.position.y;
                break;

            case "GroundUp":
                gravityForth = Vector3.up * gravity;
                fixPos = other.transform.root.transform.position.z;
                break;

            case "GroundDown":
                gravityForth = Vector3.down * gravity;
                fixPos = other.transform.root.transform.position.z;
                break;

            case "GroundRight":
                gravityForth = Vector3.right * gravity;
                fixPos = other.transform.root.transform.position.y;
                break;

            case "GroundLeft":
                gravityForth = Vector3.left * gravity;
                fixPos = other.transform.root.transform.position.y;
                break;

            default: break;
        }
        saveGravityForth = gravityForth;
    }
    private void OnTriggerStay(Collider other)
    {
        //向きの修正
        switch (saveGroundName)
        {
            case "GroundForward":
            case "GroundBack":
                if (Input.GetAxis("Horizontal") < 0) sid = 180;
                if (Input.GetAxis("Horizontal") > 0) sid = 0f;
                break;

            case "GroundUp":
            case "GroundDown":
                if (Input.GetAxis("Horizontal") < 0) sid = -90;
                if (Input.GetAxis("Horizontal") > 0) sid = 90f;
                break;

            case "GroundRight":
            case "GroundLeft":
                if (Input.GetAxis("Vertical") < 0) sid = 180;
                if (Input.GetAxis("Vertical") > 0) sid = 0;
                break;

            default: break;
        }
        switch (saveGroundName)
        {
            case "GroundForward": ang.eulerAngles = new Vector3(sid, 90, -90); break;
            case "GroundBack": ang.eulerAngles = new Vector3(sid, 90, 90); break;
            case "GroundUp": ang.eulerAngles = new Vector3(180, sid, 0); break;
            case "GroundDown": ang.eulerAngles = new Vector3(0, sid, 0); break;
            case "GroundRight": ang.eulerAngles = new Vector3(sid, 0, 90); break;
            case "GroundLeft": ang.eulerAngles = new Vector3(sid, 0, -90); break;
            default: break;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        慣性の消去
        if (collision.gameObject.tag == "Ground")
        {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                rb.velocity = Vector3.zero;
                gravityForth = Vector3.zero;
            }
        }
    }
}
