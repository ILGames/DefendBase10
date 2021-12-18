using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public static bool cont = false;

    public TextMeshProUGUI text_new;
    public TextMeshProUGUI text_continue;
    public TextMeshProUGUI text_reset;

    Transform bannerTransform;
    Image bannerImage;
    Color bannerColor;
    Image lineImage;
    Color lineColor;

    Image image;
    Color color;
    float bannerY;
    float bannerHeight;
    void Start()
    {
        CheckSave();

        Time.timeScale = 1f;    // ensure not paused any more
    
        // 60 second sleep timeout
        Screen.sleepTimeout = 60;

        GameObject banner = GameObject.Find("Banner");
        bannerHeight = banner.GetComponent<RectTransform>().rect.height;
        bannerTransform = banner.transform;
        bannerY = bannerTransform.localPosition.y;
       // bannerImage = banner.GetComponent<Image>();
       // bannerColor = bannerImage.color;

       // GameObject line = GameObject.Find("line");
       // lineImage = line.GetComponent<Image>();
       // lineColor = lineImage.color;

        GameObject fader = GameObject.Find("fader");
        if(fader != null)
        {
            image = fader.GetComponent<Image>();
            color = image.color;
        }
/*
        float alpha = color.a;
        var sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(null,null,0,2));
        sequence.Append(DOTween.To(
            () => alpha,
            (value) => {
                alpha = value;
                color.a = alpha;
                image.color = color;
            },
            0,
            1
        ));*/
       // image.DOFade(0, 0.75);
       DOVirtual.DelayedCall(0.25f, Animate);
    }
    void CheckSave()
    {
        if(PlayerPrefs.HasKey("wave"))
        {
            text_new.enabled = false;
            text_continue.enabled = true;
            text_reset.enabled = true;
        }else{
            text_new.enabled = true;
            text_continue.enabled = false;
            text_reset.enabled = false;
        }
    }
    public void Reset()
    {
        TitleScene.cont = false;
        PlayerPrefs.DeleteKey("wave");
        CheckSave();
    }
    public void Continue()
    {
        TitleScene.cont = true;
        LoadGame();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
    void Animate()
    {
        float alpha = color.a;
        DOTween.To(
            () => alpha,
            (value) => {
                alpha = value;
                color.a = alpha;
                image.color = color;
            },
            0,
            1
        );
        bannerTransform.DOLocalMoveY(bannerY-bannerHeight,0);
        DOVirtual.DelayedCall(2, AnimateBanner);
    }
    void AnimateBanner()
    {
        bannerTransform.DOLocalMoveY(bannerY, 1);//.From();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
