using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    String materialSelectedPath = "Assets/Scenes/ExhibitionScene/Materials/ButtonSelected.mat";
    String materialUnselectedPath = "Assets/Scenes/ExhibitionScene/Materials/ButtonUnselected.mat";
    LoadAnimationExhib animExhibInstance = LoadAnimationExhib.instance;
    // Start is called before the first frame update
    void Start()
    {   
        if (gameObject.name == "ButtonLoop"){
        PositionButton(-0.22f);
        } else if (gameObject.name == "ButtonPlay"){
            PositionButton(0.22f);
        }
        Animation animExhib = animExhibInstance.animationComponent;
        Material currentMaterial = GetComponent<Renderer>().material;
        if (animExhib.wrapMode == WrapMode.Loop || currentMaterial.name == "ButtonUnselected"){
            SetMaterial(currentMaterial, materialSelectedPath);
        }
        else if (animExhib.wrapMode == WrapMode.Once || currentMaterial.name == "ButtonSelected"){
            SetMaterial(currentMaterial, materialUnselectedPath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Animation animExhib = animExhibInstance.animationComponent;
        Material currentMaterial = GetComponent<Renderer>().material;
        if (animExhib.wrapMode == WrapMode.Loop || currentMaterial.name == "ButtonUnselected"){
            SetMaterial(currentMaterial, materialSelectedPath);
        }
        else if (animExhib.wrapMode == WrapMode.Once || currentMaterial.name == "ButtonSelected"){
            SetMaterial(currentMaterial, materialUnselectedPath);
        }
    }

    void PositionButton(float rightShift){
        Transform parentTransform = animExhibInstance.transform;
        Vector3 buttonPosition = parentTransform.position + parentTransform.forward*1f
                                                        + parentTransform.right*rightShift;
        transform.position = buttonPosition;
    }

    void SetMaterial(Material myMaterial, String newMaterialPath){
        Material newMaterial = Resources.Load<Material>(newMaterialPath);
        myMaterial = newMaterial;
    }
}
