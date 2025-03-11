using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Setup(CardInfo cardInfo)
    {
        image.sprite = cardInfo.sprite;
    }
}
