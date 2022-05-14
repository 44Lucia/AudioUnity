using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furrito : MonoBehaviour
{
    AudioSource m_source;
    [SerializeField] AudioClip[] m_randomStuff;

    private void Awake() {
        m_source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider p_collider) {
        if(p_collider.tag == "Player"){
            if(!m_source.isPlaying){
                int index = Random.Range(0,m_randomStuff.Length);
                m_source.PlayOneShot(m_randomStuff[index]);
            }
        }
    }

}
