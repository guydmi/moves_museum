using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Activate_button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)){
            GameObject hitObject = hit.transform.gameObject;
            Debug.Log("Touched an object: " + hitObject.name);
            LoadAnimationExhib animExhib = LoadAnimationExhib.instance;
            Animation animation = animExhib.animationComponent;
            if (hitObject.name == "ButtonPlay"){
                hitObject.GetComponent<PlayPauseAnim>().ControlAnim(animation);
            }
            else if (hitObject.name == "ButtonLoop"){
                hitObject.GetComponent<LoopAnim>().ControlLoop(animation);
            }
        }
    }
}