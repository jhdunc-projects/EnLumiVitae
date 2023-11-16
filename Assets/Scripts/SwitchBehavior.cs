using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehavior : MonoBehaviour
{
    [SerializeField] private SwitchType switchType;
    public GameObject switchObject;
    public GameObject switchTarget;
    public Collider playerCollider;
    public GameObject particleSparklies;

    public bool switchState;
    private bool changeState;
    private bool nearSwitch;

    public bool voidState;
    public GameObject player;

    public enum SwitchType { BinaryLights, DoorUnlock};

    private void Start()
    {
        changeState = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider)
        {
            nearSwitch = true;
            Debug.Log("Near Switch" + nearSwitch);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == playerCollider)
        {
            nearSwitch = false;
            Debug.Log("Near Switch" + nearSwitch);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && nearSwitch == true)
        {
            particleSparklies.SetActive(false);
            switch (switchType)
            {
                case SwitchType.BinaryLights:
                    if (switchState == true)
                    {
                        switchState = false;
                        switchTarget.SetActive(false);
                        if (changeState == true)
                        {
                            voidState = true;

                        }
                    }
                    else
                    {
                        switchState = true;
                        switchTarget.SetActive(true);
                        if (changeState == true)
                        {
                            voidState = false;
                        }
                    }
                    break;
                case SwitchType.DoorUnlock:
                    break;

            }
        }

    }
}
