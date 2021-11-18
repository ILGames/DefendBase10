using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteScript : MonoBehaviour
{
    
    public void Mute()
    {
        AudioListener.volume = 0.0f;
    }

    public void UnMute()
    {
        AudioListener.volume = 1.0f;
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
