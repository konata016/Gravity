using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlMove : MonoBehaviour
{
    Rigidbody rb;
    float rivalSpeed;
    string saveGroundName;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rivalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGround.isReady)
        {
            //移動処理
            switch (saveGroundName)
            {
                case "GroundForward":
                case "GroundBack":
                case "GroundUp":
                case "GroundDown":
                    if (Input.GetAxis("Horizontal") < 0)
                    {
                        rb.AddForce(rivalSpeed * ((Vector3.left * speed) - rb.velocity));
                    }
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        rb.AddForce(rivalSpeed * ((Vector3.right * speed) - rb.velocity));
                    }
                    break;

                case "GroundRight":
                case "GroundLeft":
                    if (Input.GetAxis("Vertical") < 0)
                    {
                        rb.AddForce(rivalSpeed * ((Vector3.back * speed) - rb.velocity));
                    }
                    if (Input.GetAxis("Vertical") > 0)
                    {
                        rb.AddForce(rivalSpeed * ((Vector3.forward * speed) - rb.velocity));
                    }
                    break;

                default: break;
            }

            //慣性の消去
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                //rb.velocity = Vector3.zero;
                rb.isKinematic = true;
                rb.isKinematic = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Ground") saveGroundName = other.gameObject.tag;
    }
}
