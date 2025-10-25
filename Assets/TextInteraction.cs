using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    TMP_Text text;
    Vector3 currentPos;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        currentPos = transform.position;
    }

    public void HoverEffectStart()
    {
        // Gerak ke kanan dan ubah warna
        transform.DOMoveX(currentPos.x + 15f, 1f).SetEase(Ease.OutQuad);
        text.DOColor(new Color32(255, 105, 100, 255), 0.5f);
    }

    public void HoverEffectEnd()
    {
        // Balik ke posisi awal dan kembalikan warna
        transform.DOMoveX(currentPos.x, 1f).SetEase(Ease.OutQuad);
        text.DOColor(new Color32(0, 0, 0, 255), 0.5f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverEffectStart();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HoverEffectEnd();
    }
}
