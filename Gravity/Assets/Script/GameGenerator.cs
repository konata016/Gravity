using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    public float Gravity = 200f;

    public static float gravity { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        gravity = Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
