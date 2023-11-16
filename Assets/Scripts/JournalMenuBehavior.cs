using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalMenuBehavior : MonoBehaviour
{
    public GameObject journalMenu;

    public GameObject tutorialTab;
    public GameObject knowledgeTab;

    public GameObject journalDefaultContent;
    public GameObject tutMoveContent;
    public GameObject tutSecretContent;
    public GameObject tutInteractionContent;
    public GameObject tutKnowledgeContent;

    public GameObject knowBlood;
    void Start()
    {
        HideAllContent();
    }

    public void HideAllContent()
    {
        journalMenu.SetActive(false);
        tutorialTab.SetActive(false);
        knowledgeTab.SetActive(false);
        journalDefaultContent.SetActive(false);
        tutMoveContent.SetActive(false);
        tutSecretContent.SetActive(false);
        tutInteractionContent.SetActive(false);
        tutKnowledgeContent.SetActive(false);
        knowBlood.SetActive(false);
    }

    public void OpenTutorialTabs()
    {
        HideAllContent();
        journalMenu.SetActive(true);
        tutorialTab.SetActive(true);
        journalDefaultContent.SetActive(true);
    }

    public void OpenKnowledgeTabs()
    {
        HideAllContent();
        journalMenu.SetActive(true);
        knowledgeTab.SetActive(true);
        journalDefaultContent.SetActive(true);
    }

    public void OpenSecretContent()
    {
        HideAllContent();
        journalMenu.SetActive(true);
        tutSecretContent.SetActive(true);
    }

    public void OpenMoveContent()
    {
        HideAllContent();
        journalMenu.SetActive(true);
        tutMoveContent.SetActive(true);
    }
    public void OpenInteractionContent()
    {
        HideAllContent();
        journalMenu.SetActive(true);
        tutInteractionContent.SetActive(true);
    }
    public void OpenKnowContent()
    {
        HideAllContent();
        journalMenu.SetActive(true);
        tutKnowledgeContent.SetActive(true);
    }
    public void OpenBloodContent()
    {
        HideAllContent();
        journalMenu.SetActive(true);
        knowBlood.SetActive(true);
    }

   public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (journalMenu.activeSelf == false)
            { OpenTutorialTabs(); }
            else
            { HideAllContent(); }
        }
    }

}
