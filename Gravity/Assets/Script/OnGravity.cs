using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGravity : MonoBehaviour
{
    float time = 5f;
    bool isPl;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPl)
        {
            float timer = 0.1f * Time.deltaTime;

            if (timer < time)
            {
                gameObject.GetComponent<Collider>().enabled = false;
                isPl = false;
                timer = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") isPl = true;
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }
}
