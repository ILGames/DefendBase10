using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject image;
    public bool notFinished = true;
    public Animator endAnimator;
    public bool runningCoroutine;


    void Awake()
    {
        //StartCoroutine(Type());
        NextSentence();
        notFinished = true;
    }
    void OnEnable()
    {
        if(runningCoroutine && textDisplay.maxVisibleCharacters < textDisplay.text.Length)
        {
            StartCoroutine(Type());
        }
    }
    void OnDisable()
    {
        
    }
    void Update()
    {
        //if(textDisplay.text == sentences[index])
        if(notFinished && textDisplay.maxVisibleCharacters >= textDisplay.text.Length)
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        runningCoroutine = true;
        // tried `textDisplay.textInfo.characterCount` but it returns 0
        while (textDisplay.maxVisibleCharacters < textDisplay.text.Length)
        {
            textDisplay.maxVisibleCharacters = textDisplay.maxVisibleCharacters + 1;
            yield return new WaitForSeconds(typingSpeed);
        }
        runningCoroutine = false;
        /*
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }*/
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(index < sentences.Length)// -1
        {
            //textDisplay.text = "";
            textDisplay.text = sentences[index];
            textDisplay.maxVisibleCharacters = 0;
            index++;
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            notFinished = false;
            image.SetActive(false);
            if (endAnimator)
            {
                //endAnimator.SetFloat("Direction", 1f);
               // endAnimator.speed = 1f;
                //endAnimator.Play("Take 001", 0, 0f);
            }
        }
    }
}
