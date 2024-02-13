using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAnimationExhib : MonoBehaviour
{
    private string animationPath;
    private string animationName;
    private string skeletonPath;
    private Animation animationComponent;
    //public GameObject skeletonPrefab;
    public GameObject skeleton;
    private AnimationClip clip;
  



    void Awake()
    {
        skeletonPath = PlayerPrefs.GetString("skeletonPath");
        GameObject skeletonPrefab = Resources.Load<GameObject>(skeletonPath);
        if (skeletonPrefab == null)
        {
            Debug.LogError("failed to load skeleton prefab from " + skeletonPath);
            return;
        }
        skeleton = Instantiate(skeletonPrefab);
        animationPath = PlayerPrefs.GetString("animationPath");
        animationName = PlayerPrefs.GetString("animationName");
        Debug.Log(animationName);
        Debug.Log(animationPath);
        //Load the animation
        AnimationClip clip = Resources.Load<AnimationClip>(animationPath);
        animationComponent = skeleton.AddComponent<Animation>();
        if (animationComponent == null)
        {
            Debug.LogError("failed to add Animation component to" + skeleton.name);
            return;
        }
        animationComponent.AddClip(clip, clip.name);

        // Play the animation 
        animationComponent.Play(clip.name);
    }
}

