using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActiveGroup : MonoBehaviour
{
    public bool active = true;
    
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ToggleActive()
    {
        active = !active;
        foreach (GameObject obj in objects)
        {
            obj.SetActive(active);
        }
    }
}
