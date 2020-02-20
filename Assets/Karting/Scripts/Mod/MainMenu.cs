using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI m_time;
    public TextMeshProUGUI m_coins;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        m_time.text  = PlayerPrefs.GetFloat("BestTime", 99).ToString();
        m_coins.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    }
}
