

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Target;
    public Vector3 V3;

    public float Speed = 20f;       //カメラが離れたとき、追いかけてくる速度
    float Dis;                      //カメラとターゲットの距離
    Vector3 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(new Vector3(transform.localPosition.z, 0f, 0f));
        float Step = Speed * Time.deltaTime;
        Vector3 Pos = transform.position;

        //Targetとの距離を求めて100倍する
        Dis = Vector3.Distance(transform.position, Target.transform.position) * 100f;

        //端数を切り捨てる
        float Rounding = Mathf.Floor(Dis);

        Pos.x = Target.transform.position.x + V3.x;
        Pos.y = Target.transform.position.y + V3.y;
        Pos.z = Target.transform.position.z + V3.z;

        //マウス左クリックしているときはカメラを動かさない
        if (!Input.GetMouseButton(0))
        {
            //ターゲットの近くにいる場合は、ターゲットと同じ動きをする（瞬間移動）
            //ターゲットと離れているときは、特定の速度でターゲットのもとへ行く
            if (Rounding / 100f > Dis) transform.position = Pos;
            else transform.position = Vector3.MoveTowards(transform.position, Pos, Step);
        }
    }
}
