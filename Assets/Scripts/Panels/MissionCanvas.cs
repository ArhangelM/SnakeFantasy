using UnityEngine;

public class MissionCanvas : MonoBehaviour
{
    public void OkHandler()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowCanvas()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
