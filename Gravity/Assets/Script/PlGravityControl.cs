using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlGravityControl : MonoBehaviour
{
    Rigidbody rb;
    Vector3 JumpForth;
    Quaternion Ang;

    float sid;

    string saveGroundName;
    public float jumpPower;
    public float attackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGround.isReady)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(JumpForth);
            }
        }
        else
        {
            
        }
        rb.rotation = Ang;
    }
    private void OnTriggerEnter(Collider other)
    {
        rb.velocity = Vector3.zero;
        if (other.gameObject.tag != "Ground") saveGroundName = other.gameObject.tag;

        switch (other.gameObject.tag)
        {
            case "GroundForward":
                JumpForth = Vector3.back * jumpPower;
                break;

            case "GroundBack":
                JumpForth = Vector3.forward * jumpPower;
                break;

            case "GroundUp":
                JumpForth = Vector3.down * jumpPower;
                break;

            case "GroundDown":
                JumpForth = Vector3.up * jumpPower;
                break;

            case "GroundRight":
                JumpForth = Vector3.left * jumpPower;
                break;

            case "GroundLeft":
                JumpForth = Vector3.right * jumpPower;
                break;

            default: break;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        switch (saveGroundName)
        {
            case "GroundForward":
            case "GroundBack":
            case "GroundUp":
            case "GroundDown":
                if (Input.GetKey(KeyCode.Alpha6)) sid = -90;
                if (Input.GetKey(KeyCode.Alpha4)) sid = 90f;
                break;

            case "GroundRight":
            case "GroundLeft":
                if (Input.GetKey(KeyCode.Alpha8)) sid = 180;
                if (Input.GetKey(KeyCode.Alpha2)) sid = 0f;
                break;

            default: break;
        }
        switch (saveGroundName)
        {
            case "GroundForward": 
            case "GroundBack": 
            case "GroundUp": 
            case "GroundDown":
                Ang.eulerAngles = new Vector3(0, 0, sid);
                break;

            case "GroundRight":
            case "GroundLeft":
                Ang.eulerAngles = new Vector3(90, sid, 0); break;

            default: break;
        }
    }
}
