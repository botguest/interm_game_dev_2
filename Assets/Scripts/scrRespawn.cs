using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrRespawn : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);
        GameObject instance = Instantiate(prefabToInstantiate, new Vector3(0, 4f, 0), Quaternion.identity);
        //Destroy(other.gameObject);
    }
}
