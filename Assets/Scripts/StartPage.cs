using UnityEngine;

public class StartPage : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
