using UnityEngine;
using UnityEngine.UI;

public class DeckCardUI : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Setup(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
