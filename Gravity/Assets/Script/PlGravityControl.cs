using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlGravityControl : MonoBehaviour
{
    Rigidbody rb;
    Vector3 jumpForth;
    Vector3 attackForth;
    Quaternion ang;

    float sid;
    bool isSlip;
    bool isEnd;

    string saveGroundName;
    public float jumpPower;
    public float attackSpeed;

    public static bool isAttack { set; get; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ang.eulerAngles = new Vector3(0, 0, sid);
        saveGroundName = "GroundDown";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && !isEnd)
        {
            //ジャンプ
            rb.AddForce(jumpPower * (jumpForth - rb.velocity));
        }

        if (IsGround.isReady)
        {
            isSlip = false;
            attackForth = Vector3.zero;
            isEnd = false;
        }
        else
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                isAttack = true;

                //慣性の消去
                if (!isSlip)
                {
                    //rb.velocity = Vector3.zero;
                    isSlip = true;
                }

                //移動の代入
                switch (saveGroundName)
                {
                    case "GroundForward":
                    case "GroundBack":
                    case "GroundUp":
                    case "GroundDown":
                        if (Input.GetAxis("Horizontal") > 0) attackForth = Vector3.right * attackSpeed;
                        if (Input.GetAxis("Horizontal") < 0) attackForth = Vector3.left * attackSpeed;
                        if(Input.GetAxis("Horizontal") != 0) rb.rotation = ang;  //回転
                        break;

                    case "GroundRight":
                    case "GroundLeft":
                        if (Input.GetAxis("Vertical") < 0) attackForth = Vector3.back * attackSpeed;
                        if (Input.GetAxis("Vertical") > 0) attackForth = Vector3.forward * attackSpeed;
                        if (Input.GetAxis("Vertical") != 0) rb.rotation = ang;  //回転
                        break;

                    default: break;
                }
                //移動
                rb.AddForce(attackForth);
            }
            else isAttack = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //ジャンプした時別の重力エリアに入った場合ロックする
        if (saveGroundName != other.gameObject.tag)
        {
            isEnd = true;
        }

        if (other.gameObject.tag != "Ground") saveGroundName = other.gameObject.tag;

        //ジャンプする方向の定義
        switch (other.gameObject.tag)
        {
            case "GroundForward":
                jumpForth = Vector3.back * jumpPower;
                break;

            case "GroundBack":
                jumpForth = Vector3.forward * jumpPower;
                break;

            case "GroundUp":
                jumpForth = Vector3.down * jumpPower;
                break;

            case "GroundDown":
                jumpForth = Vector3.up * jumpPower;
                break;

            case "GroundRight":
                jumpForth = Vector3.left * jumpPower;
                break;

            case "GroundLeft":
                jumpForth = Vector3.right * jumpPower;
                break;

            default: break;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //傾ける方向
        switch (saveGroundName)
        {
            case "GroundForward":
            case "GroundBack":
            case "GroundUp":
            case "GroundDown":
                if (Input.GetAxis("Horizontal") < 0) sid = -90f;
                if (Input.GetAxis("Horizontal") > 0) sid = 90f;
                break;

            case "GroundRight":
            case "GroundLeft":
                if (Input.GetAxis("Vertical") < 0) sid = 0f;
                if (Input.GetAxis("Vertical") > 0) sid = 180f;
                break;

            default: break;
        }
        switch (saveGroundName)
        {
            case "GroundForward":
            case "GroundBack":
            case "GroundUp":
            case "GroundDown":
                ang.eulerAngles = new Vector3(0, 0, sid);
                break;

            case "GroundRight":
            case "GroundLeft":
                ang.eulerAngles = new Vector3(90, sid, 0); break;

            default: break;
        }
    }
    void OnTriggerExit(Collider other)
    {
        //ang.eulerAngles = new Vector3(0, sid, 0);
    }
}
