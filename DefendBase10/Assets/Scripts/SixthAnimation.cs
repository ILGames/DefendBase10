﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthAnimation : MonoBehaviour
{
    Animator animator;
    public string[] sentences;
    private int index;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sentences[index] == "Wave 10000")
        {
            animator.SetTrigger("firstTransition");
        }
    }
    public void ResetDigits()
    {
        index++;
    }
}
