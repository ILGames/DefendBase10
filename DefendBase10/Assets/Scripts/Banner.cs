using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // hide if not on applicable platforms
        if(!Application.isEditor && (Application.platform != RuntimePlatform.Android || Application.platform != RuntimePlatform.IPhonePlayer))
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        Debug.Log("click");

        // https://docs.unity3d.com/ScriptReference/RuntimePlatform.html
        if (Application.platform == RuntimePlatform.Android)
            Application.OpenURL("https://play.google.com/store/apps/details?id=air.com.importantlittlegames.codemancerch1&hl=en&gl=US");
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            Application.OpenURL("https://apps.apple.com/us/app/codemancer/id1385748933");
        else
            Application.OpenURL("https://store.steampowered.com/app/1103400/Codemancer/");
        // TODO handle desktop with links to itch or steam - !itch for web!
    }
}
