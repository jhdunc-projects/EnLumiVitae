using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITriggerPoints : MonoBehaviour
{
    public bool firstDark = true;
    public GameObject firstDarkUI;
    public Collider firstDarkCollide;

    void Start()
    {
        firstDarkUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == firstDarkCollide && firstDark == true)
        {
            Debug.Log("gameobject working"); 
            firstDarkUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == firstDarkCollide)
        {
            firstDarkUI.SetActive(false);
            firstDark = false;
        }
    }
    void Update()
    {
        
        
    }
}
