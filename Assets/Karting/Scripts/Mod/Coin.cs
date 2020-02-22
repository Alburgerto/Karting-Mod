using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KartSystems.Mod
{
    [RequireComponent(typeof(AudioSource))]
    public class Coin : MonoBehaviour
    {
        public float m_respawnTime = 15;
        public CoinManager m_coinManager;
        public AudioClip m_coinPickUpClip;
        private AudioSource m_audioSource;
        private Vector3 m_initialPosition;

        void Start()
        {
            m_initialPosition = transform.position;
            m_audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                m_audioSource.PlayOneShot(m_coinPickUpClip);
                m_coinManager.CoinCollected();
                StartCoroutine(SpawnCoin());
                transform.position = new Vector3(1000, 1000, 1000); // Destroying objects is not good for you, better take them somewhere you won't look >:]
            }
        }

        // Respawns coin in initial position m_respawnTime seconds after being collected
        private IEnumerator SpawnCoin()
        {
            yield return new WaitForSeconds(m_respawnTime);
            transform.position = m_initialPosition;
        }
    }

}
