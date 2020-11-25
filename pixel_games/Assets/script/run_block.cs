using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run_block : MonoBehaviour
{
    bool checks=false;
    int x=-18, y=-3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject.Find("enemy_block_run").transform.position += Vector3.right * Time.deltaTime/2;
        
    }
}
