using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Reverb : MonoBehaviour
{
    [SerializeField] float m_transitionTime = 0.2f;
    AudioMixerSnapshot m_indoor;
    AudioMixerSnapshot m_outdoor;
    [SerializeField] AudioMixer m_mixer;
    [SerializeField]

    private void Start() {
        m_indoor = m_mixer.FindSnapshot("Indoor");
        m_outdoor = m_mixer.FindSnapshot("Outdoor");
    }

    private void OnTriggerEnter(Collider p_collider) {
        if(p_collider.tag == "Room"){
            m_indoor.TransitionTo(m_transitionTime);
        }
    }

    private void OnTriggerExit(Collider p_collider) {
        if(p_collider.tag == "Room"){
            m_outdoor.TransitionTo(m_transitionTime);
        }
    }
}
