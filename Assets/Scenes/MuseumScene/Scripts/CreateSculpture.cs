using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

public class CreateSculpture : MonoBehaviour
{
    public string animationPath = "Animations/Dancing";
    // Start is called before the first frame update
    void Start()
    {
        AnimationClip clip = Resources.Load<AnimationClip>(animationPath);
        
        Debug.Log(clip);

        //Créer un GameObject et ajouter un composant animation
        GameObject obj = new GameObject();
        Animation anim = obj.AddComponent<Animation>();
        Debug.Log(anim);
        anim.AddClip(clip, "Dancing");
        anim.Play("Dancing");


        //Ajouter un Mesh filter au game object
        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();

        //Capturer les meshes de chaque frame de l'animation
        List<Mesh> meshes = new List<Mesh>();
        for (float t =0; t < clip.length; t += Time.deltaTime)
        {
            anim.Play("Dancing");
            anim["Dancing"].time = t;
            anim.Sample();

            Mesh mesh = meshFilter.mesh;

            meshes.Add(mesh);

        }

        //Combiner les meshes
        CombineInstance[] combine = new CombineInstance[meshes.Count];
        for (int i = 0; i < meshes.Count; i++)
        {
            combine[i].mesh = meshes[i];
            combine[i].transform = Matrix4x4.identity;
        }

        Mesh combinedMesh = new Mesh();
        combinedMesh.CombineMeshes(combine);
        combinedMesh.RecalculateBounds();


        GameObject sculptureObject = new GameObject("Sculpture");

        MeshFilter filter = sculptureObject.AddComponent<MeshFilter>();
        MeshRenderer renderer = sculptureObject.AddComponent<MeshRenderer>();

        filter.mesh = combinedMesh;
        renderer.material = new Material(Shader.Find("Standard"));

        UnityEditor.PrefabUtility.SaveAsPrefabAsset(sculptureObject, "Assets/MySculpture.prefab");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
