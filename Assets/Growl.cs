using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growl : MonoBehaviour
{
    [SerializeField] AudioSource m_growlSource;
    [SerializeField] AudioClip m_growl;

    Timer m_growlTimer;
    [SerializeField] float m_minTimeToGrowl = 1.0f;
    [SerializeField] float m_maxTimeToGrowl  = 4.0f;

    private void Awake() {
        m_growlTimer = gameObject.AddComponent<Timer>();
    }

    private void Start() {
        m_growlTimer.Duration = Random.Range(m_minTimeToGrowl, m_maxTimeToGrowl);
        m_growlTimer.Run();
    }

    private void Update() {
        if(m_growlTimer.IsFinished){
            m_growlTimer.Duration = Random.Range(m_minTimeToGrowl, m_maxTimeToGrowl);
            m_growlTimer.Run();
            float pitchVariation = Random.Range(0,0.2f);
            m_growlSource.pitch = 0.8f + pitchVariation;
            m_growlSource.PlayOneShot(m_growl);
        }
    }

}
