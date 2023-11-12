using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public PlayerMovementRB movement;
    public Animator anim;
    void Start()
    {
        movement.moveSpeed = 0;
        movement.sr.enabled = false;
        Invoke("SpawnAnim", 2);
    }

    public void SpawnAnim()
    {
        anim.SetBool("PlayerSpawn", true);
    }    

    public void SpawnPlayer()
    {
        anim.SetBool("PlayerSpawn", false); 
        movement.moveSpeed = 3;
        movement.sr.enabled = true;

    }
    void Update()
    {
        
    }
}
