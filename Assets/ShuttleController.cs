using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleController : MonoBehaviour
{
    public Animator animator;
    private void OnCollisionEnter(Collider other)
    {
        if(other.tag == "Player") {
            animator.SetTrigger("Win");
        }
    }
}
