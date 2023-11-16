using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private bool triggerActive;
    public GameObject objSparkle;

    public void Start()
    {
        triggerActive = true;
        objSparkle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(triggerActive == true)
        {
            SfxManagerScript.sfxInstance.audioSource.PlayOneShot(SfxManagerScript.sfxInstance.nevAlert);
            triggerActive = false;
            objSparkle.SetActive(true);
        }
    }
}
