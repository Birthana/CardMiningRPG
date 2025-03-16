using System;
using UnityEngine;

public class DualCardManager : MonoBehaviour
{
    public event Action<CardInfo> OnShow;
    private DualCard dualCard;

    public void AddToOnShow(Action<CardInfo> func) { OnShow += func; }

    public void Show(DualCard cardToShow)
    {
        dualCard = cardToShow;
        OnShow?.Invoke(cardToShow.cardInfo1);
        OnShow?.Invoke(cardToShow.cardInfo2);
    }
}
