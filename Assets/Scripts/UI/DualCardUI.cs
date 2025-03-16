using UnityEngine;

public class DualCardUI : MonoBehaviour
{
    private CardSpawner spawner;

    private void Awake()
    {
        spawner = FindObjectOfType<CardSpawner>();
        var dualCardManager = FindObjectOfType<DualCardManager>();
        dualCardManager.AddToOnShow(SpawnUI);
    }

    public void SpawnUI(CardInfo cardInfo)
    {
        spawner.Spawn(cardInfo.GetCharacter(), cardInfo, transform);
    }
}
