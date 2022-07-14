using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{

    [SerializeField] public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForKeyPress();
    }

    void CheckForKeyPress(){
        // Spatial Blending + Clamping
        if(Input.GetKeyDown(KeyCode.F1)){
            if (audioSource.spatialBlend > 0f){
            audioSource.spatialBlend = audioSource.spatialBlend - 0.1f;
            Debug.Log("SpatialBlend Down:"+ audioSource.spatialBlend);
            }
        }
        else if(Input.GetKeyDown(KeyCode.F2)){
            if (audioSource.spatialBlend < 1f){
            audioSource.spatialBlend = audioSource.spatialBlend + 0.1f;
            Debug.Log("SpatialBlend Up:"+ audioSource.spatialBlend);
            }
        }

        // Doppler FX + Clamping
        if(Input.GetKeyDown(KeyCode.F3)){
            if (audioSource.dopplerLevel > 0f){
                audioSource.dopplerLevel = audioSource.dopplerLevel - 0.1f;
                Debug.Log("DopplerFX Down:"+ audioSource.dopplerLevel);
            }
        }
        else if(Input.GetKeyDown(KeyCode.F4)){
            if (audioSource.dopplerLevel < 1f){
                audioSource.dopplerLevel = audioSource.dopplerLevel + 0.1f;
                Debug.Log("DopplerFX Up:"+ audioSource.dopplerLevel);
            }
        }

        // Volume Control + Clamping
        if(Input.GetKeyDown(KeyCode.F5)){
            if (audioSource.volume > (0f)){
            audioSource.volume = audioSource.volume - 0.1f;
            Debug.Log("Volume Down:"+ audioSource.volume);
            }
        }
        else if(Input.GetKeyDown(KeyCode.F6)){
            if (audioSource.volume < (1f)){
            audioSource.volume = audioSource.volume + 0.1f;
            Debug.Log("Volume Up:"+ audioSource.volume);
            }
        }

        // Balance Control + Clamping
        if(Input.GetKeyDown(KeyCode.F7)){
            if (audioSource.panStereo > (-1f)){
                audioSource.panStereo = audioSource.panStereo - 0.1f;
                Debug.Log("Balance Left:"+ audioSource.panStereo);
            }
        }
        else if(Input.GetKeyDown(KeyCode.F8)){
            if (audioSource.panStereo < (1f)){
                audioSource.panStereo = audioSource.panStereo + 0.1f;
                Debug.Log("Balance Right:"+ audioSource.panStereo);
            }
        }

        // Sound Modes (Ambient / Stereo)
        if(Input.GetKeyDown(KeyCode.F9)){
            //unMute Ambient SoundSource
            //Mute Stereo Source L+R
        }
        else if(Input.GetKeyDown(KeyCode.F10)){
            //unMute StereoSource L+R
            //Mute Stereo Source L+R
        }
    }
}
