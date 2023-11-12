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

    public bool secretCorner = true;
    public GameObject secretCornerUI;
    public Collider secretCornerCollide;

    void Start()
    {
        firstDarkUI.SetActive(false);
        firstInteractUI.SetActive(false);
        secretCornerUI.SetActive(false);
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
        if (other == secretCornerCollide && secretCorner == true)
        {
            secretCornerUI.SetActive(true);
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
        if (other == secretCornerCollide)
        {
            secretCornerUI.SetActive(false);
        }
    }
    void Update()
    {
        
        
    }
}
