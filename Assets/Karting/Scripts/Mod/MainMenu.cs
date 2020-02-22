using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace KartSystems.Mod
{
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

        // Best time and coins collected so far count fetched from PlayerPrefs and displayed
        private void OnEnable()
        {
            m_time.text = PlayerPrefs.HasKey("BestTime") ? PlayerPrefs.GetFloat("BestTime").ToString() : "-";
            m_coins.text = PlayerPrefs.GetInt("Coins", 0).ToString();
        }
    }

}
