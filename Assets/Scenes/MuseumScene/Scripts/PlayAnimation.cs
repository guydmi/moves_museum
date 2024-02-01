using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class PlayAnimation : MonoBehaviour
{
    public string animationPath = "Animations/Dancing";
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //if (!gameObject.GetComponent<Animator>())
        //{
        //    animator = gameObject.AddComponent<Animator>();
        //}
        //else
        //{
        //    animator = GetComponent<Animator>();
        //}
        //Avatar avatar = Resources.Load<Avatar>("Animations/Ch36_nonPBR@Dancing");
        //if (avatar != null )
        //{
        //    animator.avatar = avatar;
        //}
        //else
        //{
        //    Debug.LogError("avatar not found");
        //}

        //AnimatorController controller = AnimatorController.CreateAnimatorControllerAtPath("Assets/Resources/Controllers/MyController.controlller");
        //AnimatorStateMachine stateMachine = new AnimatorStateMachine();
        //stateMachine.name = "MyStateMachine";
        //AssetDatabase.AddObjectToAsset(stateMachine, controller);
        //AnimatorState state = stateMachine.AddState("Dancing");

        //AnimationClip clip = Resources.Load<AnimationClip>(animationPath);

        //if (clip != null )
        //{
        //    state.motion = clip;
        //}
        //else
        //{
        //    Debug.LogError("animation not found");
        //}
        //controller.layers[0].stateMachine = stateMachine;

        //animator.runtimeAnimatorController = controller;
        //animator.Play("Dancing");
    }
}
