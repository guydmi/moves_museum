using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class PushButton : MonoBehaviour
{
    public string animationPath;
    public string animationName = "animation";
    private XRBaseInteractable interactable;

    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnButtonPressed);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("LeftController") || other.gameObject.CompareTag("RightController"))
        {
            // Enregistre le nom de l'animation
            PlayerPrefs.SetString("animationPath", animationPath);
            PlayerPrefs.SetString("animationName", animationName);

            // Charge la nouvelle scène
            SceneManager.LoadScene("ExhibitionScene");
        }
    }
           

    void OnButtonPressed(SelectEnterEventArgs args)
    {
        // Enregistre le nom de l'animation
        PlayerPrefs.SetString("animationName", animationName);
        PlayerPrefs.SetString("animationPath", animationPath);
        Debug.Log("yollo");
        // Charge la nouvelle scène
        SceneManager.LoadScene("ExhibitionScene");
    }
}
