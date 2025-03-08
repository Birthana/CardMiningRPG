using UnityEngine;
using TMPro;

public class EnergyUI : MonoBehaviour
{
    public Character character;
    public TextMeshProUGUI ui;

    private void Awake()
    {
        character.OnEnergyChange += Display;
    }

    public void Display(int currentEnergy)
    {
        ui.text = $"{currentEnergy}";
    }
}
