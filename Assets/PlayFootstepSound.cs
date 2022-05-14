using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TERRAIN { NONE, GRASS, WOOD, ROCK, LAST_NO_USE }

public class PlayFootstepSound : MonoBehaviour
{

    TERRAIN m_terrain = TERRAIN.NONE;

    AudioSource m_audioSource;
    Animator m_animator;
    Rigidbody m_rb;

private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_animator = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision p_collision)
    {
        string terrainTag = p_collision.collider.tag;

        if (IsTerrain(terrainTag))
        {
            if (terrainTag == "Grass")
            {
                m_terrain = TERRAIN.GRASS;
            }
            else if (terrainTag == "Rock")
            {
                m_terrain = TERRAIN.ROCK;
            }
            else if (terrainTag == "Wood")
            {
                m_terrain = TERRAIN.WOOD;
            }
        }
        Debug.Log(terrainTag);
    }
    void PlayFootStep(AnimationEvent p_animationEvent)
    {
        AudioClip clip;
        string path = "Sounds/";

        switch (m_terrain)
        {
            case TERRAIN.GRASS:
                path += "footstepsGrass";
                break;
            case TERRAIN.ROCK:
                path += "footstepsRock";
                break;
            case TERRAIN.WOOD:
                path += "footstepsWood";
                break;
            default:
                path += "footstepsGrass";
            break;
        }
        clip = Resources.Load<AudioClip>(path);
        if(p_animationEvent.animatorClipInfo.weight > 0.5){
            m_audioSource.PlayOneShot(clip);
            Debug.Log(p_animationEvent.animatorClipInfo.weight);

        }
        
    }

    bool IsTerrain(string p_tag)
    {
        bool isTerrain = p_tag == "Grass" || p_tag == "Rock" || p_tag == "Wood";
        return isTerrain;
    }

}
