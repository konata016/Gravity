using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsGround : MonoBehaviour
{
    //地面に触れている場合の処理
    public static bool isReady;

    public GameObject effect;
    string saveGroundName;
    GameObject obj;


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground") isReady = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") obj=Instantiate(effect, transform);
        Destroy(obj, 0.1f);
    }
    public void OnTriggerExit(Collider other)
    {
        //Debug.Log("地面ではない");
        if (other.gameObject.tag == "Ground") isReady = false;
    }
}
