using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITriggerPoints : MonoBehaviour
{
    public bool firstDark = true;
    public GameObject firstDarkUI;
    public Collider firstDarkCollide;

    public bool firstJump = true;
    public GameObject firstJumpUI;
    public Collider firstJumpCollide;

    public bool firstInteract = true;
    public GameObject firstInteractUI;
    public Collider firstInteractCollide;

    public bool secretCorner = true;
    public GameObject secretCornerUI;
    public Collider secretCornerCollide;
    public GameObject secretSparkle;

    public bool firstKnowledge = true;
    public GameObject firstKnowledgeUI;
    public Collider firstKnowledgeCollide;


    void Start()
    {
        firstDarkUI.SetActive(false);
        firstInteractUI.SetActive(false);
        secretCornerUI.SetActive(false);
        firstJumpUI.SetActive(false);
        firstKnowledgeUI.SetActive(false);
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
            SfxManagerScript.sfxInstance.audioSource.PlayOneShot(SfxManagerScript.sfxInstance.nevDisarray);
        }
        if (other == secretCornerCollide && secretCorner == true)
        {
            secretCornerUI.SetActive(true);
            }
        if (other == firstJumpCollide && firstJump == true)
        {
            firstJumpUI.SetActive(true);
            SfxManagerScript.sfxInstance.audioSource.PlayOneShot(SfxManagerScript.sfxInstance.nevVoid);
        }
        if (other == firstKnowledgeCollide && firstKnowledge == true)
        {
            firstKnowledgeUI.SetActive(true);
            SfxManagerScript.sfxInstance.audioSource.PlayOneShot(SfxManagerScript.sfxInstance.nevPortrait);
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
            secretSparkle.SetActive(false);
            secretCorner = false;
        }
        if (other == firstJumpCollide)
        {
            firstJumpUI.SetActive(false);
            firstJump = false;
        }
        if(other == firstKnowledgeCollide)
        {
            firstKnowledge = false;
            firstKnowledgeUI.SetActive(false);
        }
    }
    void Update()
    {
        
        
    }
}
