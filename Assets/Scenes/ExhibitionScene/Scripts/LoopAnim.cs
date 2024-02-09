using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAnim : MonoBehaviour
{
    public void ControlLoop(Animation animation){
        if (animation.wrapMode == WrapMode.Once){
            animation.wrapMode = WrapMode.Loop;
            animation.Play();
        }
        else{
            animation.wrapMode = WrapMode.Once;
        }
    }  
}