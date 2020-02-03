using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueOut : MonoBehaviour {
    Vector3 v ;
    public float OutSpeed,length;
    
	// Use this for initialization
	void Start () {
        v=transform.localScale;
        v.z = 0;
        transform.localScale = v;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
        {
            v.z += Time.deltaTime * OutSpeed;
        }
        else
        {
            v.z -= Time.deltaTime * OutSpeed;
        }
        if (v.z >= length)
        {
            v.z = length;
        }
        if (v.z <= 0)
        {
            v.z = 0;
        }
        transform.localScale = v;
        if (v.z == 0)
        {
            GetComponentInChildren<BoxCollider>().enabled = false;
        }
        else
        {
            GetComponentInChildren<BoxCollider>().enabled = true;
        }
    }
}
