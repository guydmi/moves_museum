using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Titre : MonoBehaviour
{
    public Text textField;
    private string animationPath;
    private string animationName;
    private Animation animationComponent;
    [SerializeField] TextMeshProUGUI m_Object;

    // Start is called before the first frame update
    void Start()
    {
        animationPath = PlayerPrefs.GetString("animationPath");
        animationName = PlayerPrefs.GetString("animationName");
        m_Object.text = animationName;
        textField.text = animationName;
        Debug.Log(animationName);
    }

    
}
