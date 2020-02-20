using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    public TextMeshProUGUI m_coinsText;
    private int m_coins = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            int coins = PlayerPrefs.GetInt("Coins", 0);
            PlayerPrefs.SetInt("Coins", coins + 1); // Historical number of collected coins
            m_coinsText.text = (++m_coins).ToString(); // Only current run's number of collected coins

            other.transform.position = new Vector3(1000, 1000, 1000);
            // Better to move it someplace we won't see than destroying it, which is quite expensive
            // Better implementation would be to return it to a coin pool to use it again later with procedural generation but that's not the point of this project
        }
    }
}
