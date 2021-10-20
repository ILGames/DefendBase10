using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
/// <summary>
///   Use this class to respond to layout changes higher up and animate children by offseting the childs rect
///   1. detect any changes
/// </summary>
public class CustomLayout : UIBehaviour, ILayoutSelfController
{

    [System.NonSerialized]
    private RectTransform m_Rect;

    private Vector2 previousPos;
    private bool previousSet = false;

    private RectTransform rectTransform
    {
        get
        {
            if (m_Rect == null)
                m_Rect = GetComponent<RectTransform>();
            return m_Rect;
        }
    }


    /// <summary>
    /// Method called by the layout system. Has no effect
    /// </summary>
    public virtual void SetLayoutHorizontal()
    {
        Debug.Log("layout SetLayoutHorizontal");
    }

    /// <summary>
    /// Method called by the layout system. Has no effect
    /// </summary>
    public virtual void SetLayoutVertical()
    {
        Debug.Log("layout SetLayoutVertical");

        Vector2 delta;
        if (!previousSet)
        {
            previousPos = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);
            previousSet = true;
            delta = rectTransform.anchoredPosition - previousPos;
        }
        else
        {
            delta = rectTransform.anchoredPosition - previousPos;
            previousPos = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);
        }
        Debug.Log(previousPos);
        Debug.Log(delta.x);

        if (Application.isPlaying)
        {
            for (int i = 0; i < rectTransform.childCount; i++)
            {
                RectTransform child = rectTransform.GetChild(i) as RectTransform;
                if (child)
                {
                    child.anchoredPosition = new Vector2(-delta.x, -delta.y);
                }
            }

            StopAllCoroutines();
            IEnumerator coroutine = ShowSelf(0.25f);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator ShowSelf(float duration)
    {
        float time = 0.0f;
        Vector2[] values = new Vector2[rectTransform.childCount];
        for (int i = 0; i < rectTransform.childCount; i++)
        {
            RectTransform child = rectTransform.GetChild(i) as RectTransform;
            values[i] = child ? child.anchoredPosition : Vector2.zero;
        }
        while (time < duration)
        {
            for (int i = 0; i < rectTransform.childCount; i++)
            {
                RectTransform child = rectTransform.GetChild(i) as RectTransform;
                if (child)
                {
                    child.anchoredPosition = new Vector2(Mathf.Lerp(values[i].x, 0f, time/duration), Mathf.Lerp(values[i].y, 0f, time / duration));
                }
            }
            time += Time.deltaTime;
            yield return null;
        }
        // clean up
        for (int i = 0; i < rectTransform.childCount; i++)
        {
            RectTransform child = rectTransform.GetChild(i) as RectTransform;
            if (child) child.anchoredPosition = Vector2.zero;
        }
    }
    IEnumerator ShowSelfOld(float duration)
    {
        float time = 0.0f;
        while (time < duration)
        {
            for (int i = 0; i < rectTransform.childCount; i++)
            {
                RectTransform child = rectTransform.GetChild(i) as RectTransform;
                if (child)
                {
                    child.anchoredPosition = new Vector2(Mathf.Lerp(child.anchoredPosition.x, 0f, 0.01f), child.anchoredPosition.y);
                }
            }
            Debug.Log("ShowSelf " + time + " duration " + duration);
            yield return null;
            time += Time.deltaTime;
        }
    }

    protected override void OnEnable()
    {
        Debug.Log("layout OnEnable");
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        Debug.Log("layout OnDisable");
        base.OnDisable();
    }
       
    private void UpdateChildren()
    {

    }
    protected void SetDirty()
    {
        UpdateChildren();
    }
    protected virtual void Update()
    {

        /*
        Debug.Log("layout Update");

        if (!previousSet)
        {
            previousPos = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);
            previousSet = true;
        }
        */
    }
    /*
    int max = 10;
    void Update()
    {
        if(max-- > 0)
        {
            Debug.Log("update other");
        }
    }*/
    protected override void OnDidApplyAnimationProperties()
    {
        //Debug.Log("OnDidApplyAnimationProperties");
    }
    protected override void OnRectTransformDimensionsChange()
    {
        //Debug.Log("layout OnRectTransformDimensionsChange");
        UpdateRect();
    }
    /*
    protected override void OnRectTransformParentChanged()
    {
        Debug.Log("layout OnRectTransformParentChanged");
    }*/
    protected override void OnTransformParentChanged()
    {
        //Debug.Log("layout OnTransformParentChanged");
    }
    private void UpdateRect()
    {
        if (!IsActive())
            return;

    }
}