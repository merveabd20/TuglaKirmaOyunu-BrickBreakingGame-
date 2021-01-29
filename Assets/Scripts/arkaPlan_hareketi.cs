using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arkaPlan_hareketi : MonoBehaviour
{

    float hiz = 2.0f;

    void Update()
    {
        if (transform.position.z > -40.0f)
        {
            transform.Translate(0, 0, -hiz * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 140.0f);
        }
    }
}
