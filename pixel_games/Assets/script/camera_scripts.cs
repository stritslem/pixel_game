using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_scripts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Hero;
    void Update()
    {
        transform.position = new Vector3(Hero.transform.position.x, Hero.transform.position.y, -10f);
    }
}
