using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KartSystems.Mod
{
    public class CoinManager : MonoBehaviour
    {
        public TextMeshProUGUI m_coinsText;
        private int m_coins;

        void Start()
        {
            m_coins = 0;
        }

        public void CoinCollected()
        {
            int coins = PlayerPrefs.GetInt("Coins", 0);
            PlayerPrefs.SetInt("Coins", coins + 1); // Historical number of collected coins
            m_coinsText.text = (++m_coins).ToString(); // Only current run's number of collected coins
        }
    }

}
