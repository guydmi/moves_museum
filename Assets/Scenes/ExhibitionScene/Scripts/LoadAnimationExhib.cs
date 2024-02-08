using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAnimationExhib : MonoBehaviour
{
    private string animationPath;
    private string animationName;
    private Animation animationComponent;
    public GameObject skeletonPrefab;
    private GameObject skeleton;
    // Start is called before the first frame update
    void Start()
    {
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

