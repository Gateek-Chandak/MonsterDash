using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
	
    public int destroyTime;    

    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
