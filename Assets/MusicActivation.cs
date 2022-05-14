using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicActivation : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot baseSnapshot;
    [SerializeField] AudioMixerSnapshot combatSnapshot;
    [SerializeField] AudioMixerSnapshot ambienceCombatSnapShot;
    [SerializeField] AudioMixerSnapshot ambienceSnapShot;

    [SerializeField] float transitionTime = 0.2f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Combat"){
            combatSnapshot.TransitionTo(transitionTime);
            ambienceCombatSnapShot.TransitionTo(transitionTime);
        } 
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Combat")
            baseSnapshot.TransitionTo(transitionTime);
            ambienceSnapShot.TransitionTo(transitionTime);
    }
}
