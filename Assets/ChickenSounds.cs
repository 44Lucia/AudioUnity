using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSounds : MonoBehaviour
{
    AudioSource m_audioSource;
    Timer m_eventTimer;
    [SerializeField] AudioClip m_chickenSound;
    [SerializeField] float m_minTimeToPioPio = 2.0f;
    [SerializeField] float m_maxTimeToPioPio = 6.0f;

    private void Awake() {
        m_audioSource = GetComponent<AudioSource>();
        m_eventTimer =  gameObject.AddComponent<Timer>();
    }

    private void Start() {
        m_eventTimer.Duration = Random.Range(m_minTimeToPioPio, m_maxTimeToPioPio);
        m_eventTimer.Run();
    }

    private void Update() {
        if(m_eventTimer.IsFinished){
            float pitchVariation = Random.Range(0,0.2f);
            m_audioSource.pitch = 0.8f + pitchVariation;
            m_audioSource.PlayOneShot(m_chickenSound);
            m_eventTimer.Duration = Random.Range(m_minTimeToPioPio, m_maxTimeToPioPio);
            m_eventTimer.Run();
        }
    }

}
