using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class go : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void Scenelvl_next() {
        Application.LoadLevel("Next_level");


    }
    public void Scenelvl()
    {
        Application.LoadLevel("SampleScene");


    }
    // Update is called once per frame
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
