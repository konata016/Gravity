using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    Rigidbody rb;
    Vector3 gravityForth;
    Vector3 saveGravityForth;
    Vector3 pos;
    Vector3 jumpForth;

    bool isEnd;
    float fixPos;
    float timer;
    string saveGroundName;

    public float jumpPower = 20f;
    public float gravity = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = rb.position;
        if (!isEnd)
        {
            timer += 1f * Time.deltaTime;
            rb.isKinematic = true;
            if (timer > 3f)
            {
                rb.isKinematic = false;
                rb.AddForce(jumpPower * (jumpForth - rb.velocity), ForceMode.Acceleration);
            }
        }

        //位置修正
        switch (saveGroundName)
        {
            case "GroundUp":
            case "GroundDown":
                transform.position = Vector3.MoveTowards(rb.position, new Vector3(pos.x, pos.y, fixPos), 10);
                break;

            case "GroundForward":
            case "GroundBack":
            case "GroundRight":
            case "GroundLeft":
                transform.position = Vector3.MoveTowards(rb.position, new Vector3(pos.x, fixPos, pos.z), 10);
                break;

            default: break;
        }

        //重力
        rb.AddForce(gravityForth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") isEnd = false;
        if (collision.gameObject.tag == "Needle" ||
            collision.gameObject.tag == "Ground")
        {
            timer = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        gravityForth = saveGravityForth;
    }
    private void OnTriggerEnter(Collider other)
    {
        //重力エリアに入った場合ロックする
        if (saveGroundName != other.gameObject.tag)
        {
            isEnd = true;
        }

        //重力の力の向き
        switch (other.gameObject.tag)
        {
            case "GroundForward":
                gravityForth = Vector3.forward * gravity;
                jumpForth = Vector3.back * jumpPower;
                fixPos = other.transform.root.transform.position.y;
                rb.constraints = 
                    RigidbodyConstraints.FreezePositionY |
                    RigidbodyConstraints.FreezePositionX |
                    RigidbodyConstraints.FreezeRotation;
                break;

            case "GroundBack":
                gravityForth = Vector3.back * gravity;
                jumpForth = Vector3.forward * jumpPower;
                fixPos = other.transform.root.transform.position.y;
                rb.constraints = 
                    RigidbodyConstraints.FreezePositionY |
                    RigidbodyConstraints.FreezePositionX |
                    RigidbodyConstraints.FreezeRotation;
                break;

            case "GroundUp":
                gravityForth = Vector3.up * gravity;
                jumpForth = Vector3.down * jumpPower;
                fixPos = other.transform.root.transform.position.z;
                rb.constraints = 
                    RigidbodyConstraints.FreezePositionZ |
                    RigidbodyConstraints.FreezePositionX |
                    RigidbodyConstraints.FreezeRotation;
                break;

            case "GroundDown":
                gravityForth = Vector3.down * gravity;
                jumpForth = Vector3.up * jumpPower;
                fixPos = other.transform.root.transform.position.z;
                rb.constraints = 
                    RigidbodyConstraints.FreezePositionZ |
                    RigidbodyConstraints.FreezePositionX |
                    RigidbodyConstraints.FreezeRotation;
                break;

            case "GroundRight":
                gravityForth = Vector3.right * gravity;
                jumpForth = Vector3.left * jumpPower;
                fixPos = other.transform.root.transform.position.y;
                rb.constraints = 
                    RigidbodyConstraints.FreezePositionY |
                    RigidbodyConstraints.FreezePositionZ |
                    RigidbodyConstraints.FreezeRotation;
                break;

            case "GroundLeft":
                gravityForth = Vector3.left * gravity;
                jumpForth = Vector3.right * jumpPower;
                fixPos = other.transform.root.transform.position.y;
                rb.constraints =
                    RigidbodyConstraints.FreezePositionY |
                    RigidbodyConstraints.FreezePositionZ |
                    RigidbodyConstraints.FreezeRotation;
                break;

            default: break;
        }
        //重力が発生する場所の名前を保存
        if (other.gameObject.tag != "Ground")
        {
            saveGroundName = other.gameObject.tag;
            saveGravityForth = gravityForth;
        }
    }
}
