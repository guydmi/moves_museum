using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadAnimationExhib : MonoBehaviour
{
    public static LoadAnimationExhib instance;
    
    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
    }
    
    
    private string animationPath;
    private string animationName;
    public Animation animationComponent;
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
        //animationComponent.Play(clip.name);
    }

}

