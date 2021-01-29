using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyun_kontrolu : MonoBehaviour
{

    public Rigidbody oyuncu_rigi;
    float hiz = 10.0f;
    float yatay_ok_tusu;
    float mouse;
    private void FixedUpdate()
    {
        oyuncu_hareketi();
    }

    void oyuncu_hareketi()
    {
        yatay_ok_tusu = Input.GetAxis("Horizontal");
        mouse = Input.GetAxis("Mouse X");
        oyuncu_rigi.velocity = (Vector3.right * hiz) * yatay_ok_tusu;

        if (Input.GetMouseButton(0))
        {
            oyuncu_rigi.velocity = (Vector3.right * hiz * 2.0f) * mouse;
        }
    }
}
