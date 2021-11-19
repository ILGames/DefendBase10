using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class TitleScene : MonoBehaviour
{
    // Start is called before the first frame update
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
        image = fader.GetComponent<Image>();
        color = image.color;

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
