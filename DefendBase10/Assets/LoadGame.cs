using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LoadGame : MonoBehaviour
{
    /* Custom cursor if required
    // if you want it private do:
    [Serializefield] 
    Texture2D cursor; 
    // Otherwise you can do it publicly.
    public Texture2D cursor;
    */

    public TextMeshProUGUI text;
    private static Material m_TextBaseMaterial;
    private static Material m_TextHighlightMaterial;

    private void Awake()
    {
        // Get a reference to the default base material
        m_TextBaseMaterial = text.fontSharedMaterial;

        // Create new instance of the material assigned to the text object
        // Assumes all text objects will use the same highlight
        m_TextHighlightMaterial = new Material(m_TextBaseMaterial);

        // Set Glow Power on the new material instance
        m_TextHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 1.0f);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load()
    {
        Application.LoadLevel("Gameplay");
    }
    public void OnMouseOver()
    {
        //Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        text.fontSharedMaterial = m_TextHighlightMaterial;
        text.UpdateMeshPadding();
    }
    public void OnMouseExit()
    {
        //Cursor.SetCursor (null,Vector2.zero,CursorMode.Auto);
        text.fontSharedMaterial = m_TextBaseMaterial;
        text.UpdateMeshPadding();
    }
}
