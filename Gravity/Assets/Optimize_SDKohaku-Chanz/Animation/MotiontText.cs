using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiontText : MonoBehaviour
{
    private Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)) Anim.SetBool("IsJump", true);
        else Anim.SetBool("IsJump", false);

        if (Input.GetKey(KeyCode.Alpha2)) Anim.SetBool("IsDamage", true);
        else Anim.SetBool("IsDamage", false);

        if (Input.GetKey(KeyCode.Alpha3)) Anim.SetBool("IsFloat", true);
        else Anim.SetBool("IsFloat", false);

        if (Input.GetKey(KeyCode.Alpha4)) Anim.SetBool("IsLan", true);
        else Anim.SetBool("IsLan", false);

        if (Input.GetKey(KeyCode.Alpha5)) Anim.SetBool("IsKneel", true);
        else Anim.SetBool("IsKneel", false);
    }
}
