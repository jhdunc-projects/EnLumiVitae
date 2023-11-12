using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITriggerPoints : MonoBehaviour
{
    public bool firstDark = true;
    public GameObject firstDarkUI;
    public Collider firstDarkCollide;

    public bool firstInteract = true;
    public GameObject firstInteractUI;
    public Collider firstInteractCollide;

    void Start()
    {
        firstDarkUI.SetActive(false);
        firstInteractUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == firstDarkCollide && firstDark == true)
        {
            firstDarkUI.SetActive(true);
        }
        if (other == firstInteractCollide && firstInteract == true)
        {
            firstInteractUI.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other == firstDarkCollide)
        {
            firstDarkUI.SetActive(false);
            firstDark = false;
        }
        if (other == firstInteractCollide)
        {
            firstInteractUI.SetActive(false);
            firstInteract = false;
        }
    }
    void Update()
    {
        
        
    }
}
