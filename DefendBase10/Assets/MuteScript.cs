using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteScript : MonoBehaviour
{
    public Text text;

    void Awake()
    {
        ToggleMuted();
        ToggleMuted();
    }

    public void Mute()
    {
        AudioListener.volume = 0.0f;
        text.text = "sound\non";
    }

    public void UnMute()
    {
        AudioListener.volume = 1.0f;
        text.text = "sound\noff";
    }

    public void ToggleMuted()
    {
        if (AudioListener.volume > 0.5f)
        {
            Mute();
        }
        else{
            UnMute();
        }
    }
}
