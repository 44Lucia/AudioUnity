using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSounds : MonoBehaviour
{
    [SerializeField ]AudioSource m_audioSourceChicken;
    [SerializeField ]AudioSource m_audioSourcePio;
    Timer m_pioTimer;
    Timer m_chickenTimer;
    [SerializeField] AudioClip m_chickenSound;
    [SerializeField] AudioClip m_miniChickenSound;
    [SerializeField] float m_minTimeToPioPio = 4.0f;
    [SerializeField] float m_maxTimeToPioPio = 10.0f;

    private void Awake() {
        m_chickenTimer =  gameObject.AddComponent<Timer>();
        m_pioTimer =  gameObject.AddComponent<Timer>();
    }

    private void Start() {
        m_chickenTimer.Duration = Random.Range(m_minTimeToPioPio, m_maxTimeToPioPio);
        m_chickenTimer.Run();
    }

    private void Update() {
        if(m_chickenTimer.IsFinished){
            float pitchVariation = Random.Range(0,0.2f);
            m_audioSourceChicken.pitch = 0.8f + pitchVariation;
            m_audioSourceChicken.PlayOneShot(m_miniChickenSound);
            m_chickenTimer.Duration = Random.Range(m_minTimeToPioPio, m_maxTimeToPioPio);
            m_chickenTimer.Run();
        }

        if(m_pioTimer.IsFinished){
            float pitchVariation = Random.Range(0,0.2f);
            m_audioSourcePio.pitch = 0.8f + pitchVariation;
            m_audioSourcePio.PlayOneShot(m_chickenSound);
            m_pioTimer.Duration = Random.Range(m_minTimeToPioPio/2, m_maxTimeToPioPio/2);
            m_pioTimer.Run();
        }
    }

}
