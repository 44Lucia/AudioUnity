using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TERRAIN { NONE, GRASS, WOOD, ROCK, LAST_NO_USE }

public class PlayFootstepSound : MonoBehaviour
{

    TERRAIN m_terrain = TERRAIN.NONE;

    AudioSource m_audioSource;

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
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
    void PlayFootStep()
    {
        AudioClip clip;
        string path = "Sounds/";

        switch (m_terrain)
        {
            case TERRAIN.GRASS:
                path += "footstepsWood";
                break;
            case TERRAIN.ROCK:
                path += "footstepsRock";
                break;
            case TERRAIN.WOOD:
                path += "footstepsWood";
                break;
            default:
                path += "footstepsWood";
            break;
        }
        clip = Resources.Load<AudioClip>(path);
        m_audioSource.PlayOneShot(clip);
    }

    bool IsTerrain(string p_tag)
    {
        bool isTerrain = p_tag == "Grass" || p_tag == "Rock" || p_tag == "Wood";
        return isTerrain;
    }

}
