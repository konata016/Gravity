using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKey : MonoBehaviour
{
    public static bool isGravityControl { get; set; }
    public static bool isEnemyThrow { get; set; }
    public static bool isSavePos { get; set; }
    public static bool isTeleport { set; get; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //重力移動
        if (Input.GetKey(KeyCode.E)||Input.GetKey(KeyCode.JoystickButton2))
        {
            isGravityControl = true;
        }
        else isGravityControl = false;

        //敵を飛ばす
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.JoystickButton3))
        {
            isEnemyThrow = true;
        }
        else isEnemyThrow = false;

        //位置をセーブ
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            isSavePos = true;
        }
        else isSavePos = false;

        //セーブした場所に移動
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            isTeleport = true;
        }
        else isTeleport = false;
    }
}
