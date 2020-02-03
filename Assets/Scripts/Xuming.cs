using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xuming : MonoBehaviour {
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<AI>().Minus1s();
            GetComponentInParent<FrogController>().Plus1s();
        }
        
    }

}
