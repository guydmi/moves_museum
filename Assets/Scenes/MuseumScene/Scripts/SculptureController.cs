using UnityEngine;
using UnityEngine.UI;

public class SculptureController : MonoBehaviour
{
    public SculptureOnTime sculptureOnTime;
    public Slider startFrameSlider;
    public Slider endFrameSlider;
    public Button createSculptureButton;

    void Start()
    {
        CreateSculpture();
        // Initialise les sliders avec les valeurs actuelles de StartFrame et EndFrame
        startFrameSlider.value = sculptureOnTime.StartFrame;
        endFrameSlider.value = sculptureOnTime.EndFrame;

        startFrameSlider.onValueChanged.AddListener(value => {
            sculptureOnTime.StartFrame = (int)value;
            if (sculptureOnTime.StartFrame > sculptureOnTime.EndFrame)
            {
                sculptureOnTime.EndFrame = sculptureOnTime.StartFrame;
                sculptureOnTime.StartFrame = sculptureOnTime.StartFrame - 1;
                endFrameSlider.value = sculptureOnTime.EndFrame;
            }
        });
        endFrameSlider.onValueChanged.AddListener(value => {
            sculptureOnTime.EndFrame = (int)value;
            if (sculptureOnTime.EndFrame < sculptureOnTime.StartFrame)
            {
                sculptureOnTime.StartFrame = sculptureOnTime.EndFrame;
                sculptureOnTime.EndFrame = sculptureOnTime.EndFrame + 1;
                startFrameSlider.value = sculptureOnTime.StartFrame;
            }
        });

        // Ajoute un listener pour le bouton pour créer la sculpture
        createSculptureButton.onClick.AddListener(CreateSculpture);

    }

    public void CreateSculpture()
    {
        // Supprime l'ancienne sculpture si elle existe
        GameObject oldSculpture = GameObject.Find("Sculpture" + sculptureOnTime.sculptureId);
        if (oldSculpture != null)
        {
            Destroy(oldSculpture);
        }

        // Crée une nouvelle sculpture
        sculptureOnTime.CreateSculptureOnTime();
    }

}
