using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPauseAnim : MonoBehaviour
{
    public void ControlAnim(Animation animation){
        if (animation.isPlaying == true){
            animation.Stop();
        }
        else{
            animation.Play();
        }

    }
}
