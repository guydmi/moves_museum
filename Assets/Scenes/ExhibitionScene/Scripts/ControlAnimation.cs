using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlAnimation : MonoBehaviour
{
    private string animationPath;
    private string animationName;
    private string skeletonPath;
    private Animation animationComponent;
    //public GameObject skeletonPrefab;
    public GameObject skeleton;
    private AnimationClip clip;
    public Slider slider_animation;

    void Start()
    {
        // Obtenez l'animation de l'objet LoadAnimation
        
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
        animationComponent.AddClip(clip, animationName);
        animationComponent.Play(animationName);
        


    }

    void Update()
    {
        slider_animation.value = animationComponent[animationName].normalizedTime % 1.0f;
    }

    // Méthode pour jouer l'animation
    public void PlayAnimation()
    {
        Debug.Log("play");
        Debug.Log(animationComponent);
        Debug.Log(animationName);
        animationComponent[animationName].speed = 1;
        //anim.Play();
    }

    // Méthode pour mettre en pause l'animation
    public void PauseAnimation()
    {
        Debug.Log(animationComponent[animationName]);
        animationComponent[animationName].speed = 0;
        Debug.Log(animationComponent[animationName].speed);
    }
    public void ExitScene()
    {
        Debug.Log("exit");
        SceneManager.LoadScene("MuseumScene");
    }
    public void AnimateOnSliderValue()
    {
        //animationComponent[animationName].speed = 0;
        animationComponent[animationName].normalizedTime = slider_animation.value;
        //animationComponent[animationName].speed = 1;
    }
    

    
}
