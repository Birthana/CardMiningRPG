using UnityEngine;

public class DayNight : MonoBehaviour
{
    public int MAX_DAY_TIME = 6;
    public int MAX_NIGHT_TIME = 4;
    private int currentTime;

    private void Awake()
    {
        currentTime = 0;
    }

    public int GetMaxTime() { return MAX_DAY_TIME + MAX_NIGHT_TIME; }

    public void Increment()
    {
        currentTime = Mathf.Min(currentTime + 1, GetMaxTime());
        Debug.Log($"{currentTime}");
    }
}
