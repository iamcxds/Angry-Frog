using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    public int life;
    public float speed;
    public float rotSpeed;
    public int attack;
    Vector3 target ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        target =new Vector3(GameManager1.jiang.x - transform.position.x,0, GameManager1.jiang.z - transform.position.z);
        transform.Translate(Vector3.forward * speed*Time.deltaTime);
        Vector3 relativePos = Vector3.RotateTowards(transform.forward, target, rotSpeed*Time.deltaTime,0);
        transform.rotation = Quaternion.LookRotation(relativePos);
        
        if((transform.position.x* transform.position.x>=100.0f)|| (transform.position.z* transform.position.z >= 100.0f)||life==0)
        {
            Destroy(gameObject);
        }

    }
    public void Minus1s()
    {
        life--;
    }
    public void Plusns()
    {
        life += attack;
    }
}  
