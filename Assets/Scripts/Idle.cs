using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
{
    private Animator nave1Idle;

    void Awake()
    {
        nave1Idle = GetComponent<Animator>();
        nave1Idle.SetBool("idle", true);
    }

    private void OnEnable()
    {
        nave1Idle.SetBool("idle", true);
    }

    public void leaveAnimation()
    {
        nave1Idle.SetBool("idle", false);
    }

    public void restart()
    {
        nave1Idle.SetTrigger("restart");
        nave1Idle.SetBool("idle", true);
    }
}
