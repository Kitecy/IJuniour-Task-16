using UnityEngine;
using UnityEngine.UI;

public class StartPage : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    private void Awake()
    {
        _playButton.onClick.AddListener(Play);
    }

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
