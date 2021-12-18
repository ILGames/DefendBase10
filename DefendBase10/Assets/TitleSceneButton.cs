using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TitleSceneButton : EventTrigger
{
    TextMeshProUGUI text;

    private static Material m_TextBaseMaterial;
    private static Material m_TextHighlightMaterial;

    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        if(!m_TextBaseMaterial)
        {
            m_TextBaseMaterial = text.fontSharedMaterial;

            // Create new instance of the material assigned to the text object
            // Assumes all text objects will use the same highlight
            m_TextHighlightMaterial = new Material(m_TextBaseMaterial);

            // Set Glow Power on the new material instance
            m_TextHighlightMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 1.0f);
        }
    }

    public override void OnPointerEnter(PointerEventData data)
    {
        text.fontSharedMaterial = m_TextHighlightMaterial;
        text.UpdateMeshPadding();
    }

    public override void OnPointerExit(PointerEventData data)
    {
        text.fontSharedMaterial = m_TextBaseMaterial;
        text.UpdateMeshPadding();
    }

    
}