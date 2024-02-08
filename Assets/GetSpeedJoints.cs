using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeedJoints : MonoBehaviour
{
    public Dictionary<string, List<Vector3>> JointPos = new Dictionary<string, List<Vector3>>();
    public Dictionary<string, List<Vector3>> JointSpeed = new Dictionary<string, List<Vector3>>();
    private Dictionary<string, Vector3> lastPos = new Dictionary<string, Vector3>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TrackJoints(transform);
        UpdateMaterial();
    }

    void TrackJoints(Transform joint)
    {
        // Si le joint n'est pas encore dans le dictionnaire, l'ajouter
        if (!JointPos.ContainsKey(joint.name))
        {
            JointPos[joint.name] = new List<Vector3>();
            JointSpeed[joint.name] = new List<Vector3>();
            lastPos[joint.name] = joint.position;
        }

        // Ajouter la position actuelle à la liste des positions
        JointPos[joint.name].Add(joint.position);

        // Calculer la vitesse comme la différence de position divisée par le temps écoulé
        Vector3 speed = (joint.position - lastPos[joint.name]) / Time.deltaTime;

        // Ajouter la vitesse actuelle à la liste des vitesses
        JointSpeed[joint.name].Add(speed);

        // Mettre à jour la dernière position connue
        lastPos[joint.name] = joint.position;

        // Parcourir tous les enfants du joint actuel
        foreach (Transform child in joint)
        {
            TrackJoints(child);
        }
    }

    void UpdateMaterial()
    {
        // Supposons que `material` est le matériau de l'objet que vous voulez colorer
        Material material = GetComponent<Renderer>().material;

        // Créer un tableau pour stocker les vitesses
        float[] speeds = new float[JointSpeed.Count];

        // Mettre à jour la vitesse dans le tableau
        int i = 0;
        foreach (KeyValuePair<string, List<Vector3>> entry in JointSpeed)
        {
            float speedMagnitude = entry.Value[entry.Value.Count - 1].magnitude;

            // Ajouter la vitesse au tableau
            speeds[i] = speedMagnitude;
            i++;
        }

        // Définir la propriété du matériau
        material.SetFloatArray("_Speeds", speeds);
    }
}
