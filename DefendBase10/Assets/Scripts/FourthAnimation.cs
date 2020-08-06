using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthAnimation : MonoBehaviour
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
        if (sentences[index] == "Wave 110")
        {
            animator.SetTrigger("firstTransition");
        }
        if (sentences[index] == "Wave 1010")
        {
            animator.SetTrigger("secondTransition");
        }
        if (sentences[index] == "Wave 10000")
        {
            animator.SetTrigger("thirdTransition");
        }
    }
    public void ResetDigits()
    {
        index++;
    }
}
