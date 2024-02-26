using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrRespawn : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public GameObject textManager; //for updating score info
    public bool respawnable = true; //updated in scrManager

    private scrManager _scrManager;
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
        _scrManager = textManager.GetComponent<scrManager>();
        _scrManager.live_lost = true;
        if (_scrManager.lives > 0 && respawnable)
        {
            GameObject instance = Instantiate(prefabToInstantiate, new Vector3(0, 4f, 0), Quaternion.identity);
        }
        //Destroy(other.gameObject);
    }
}
