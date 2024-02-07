using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SculptureOnTime : MonoBehaviour
{
    public string animationPath;
    public GameObject skeletonPrefab;
    private Animation animationComponent;
    private GameObject skeleton;
    private GameObject sculpture;
    private List<Mesh> frames = new List<Mesh>();
    private int frameCounter = 0;
    public Material Material1;
    public int StartFrame;
    public int EndFrame;
    public string sculptureId;

    public void CreateSculptureOnTime()
    {
        frames.Clear();
        frameCounter = 0;
        skeleton = Instantiate(skeletonPrefab);
        //Load the animation
        AnimationClip clip = Resources.Load<AnimationClip>(animationPath);

        if (clip == null)
        {
            Debug.LogWarning("failed to load animation");
            return;
        }

        // Add the animation 
        animationComponent = skeleton.AddComponent<Animation>();
        if (animationComponent == null)
        {
            Debug.LogError("failed to add Animation component to" + skeleton.name);
            return;
        }
        animationComponent.AddClip(clip, clip.name);

        // Play the animation 
        animationComponent.Play(clip.name);

        sculpture = new GameObject("Sculpture" + sculptureId);
        sculpture.AddComponent<MeshFilter>();
        sculpture.AddComponent<MeshRenderer>();

        //Start the sculpture creation
        StartCoroutine(CreateSculpture());
    }
    IEnumerator CreateSculpture()
    {
        Debug.Log(frames.Count.ToString());
        SkinnedMeshRenderer[] meshRenderers = skeleton.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (var renderer in meshRenderers)
        {
            renderer.enabled = false;
        }

        while (animationComponent.isPlaying && frameCounter < EndFrame)
        {
            frameCounter++;
            if (frameCounter % 5 == 0 && frameCounter > StartFrame)
            {
                Mesh combinedMesh = new Mesh();
                combinedMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
                meshRenderers[0].BakeMesh(combinedMesh);
                frames.Add(combinedMesh);
            }


            //Mesh combinedMesh = new Mesh();
            //combinedMesh.CombineMeshes(combine);


            yield return null;
        }
        CombineInstance[] combineFinal = new CombineInstance[frames.Count];
        for (int i = 0; i < frames.Count; i++)
        {
            combineFinal[i].mesh = frames[i];
            combineFinal[i].transform = transform.localToWorldMatrix;
        }
        sculpture.GetComponent<MeshFilter>().mesh = new Mesh();
        sculpture.GetComponent<MeshFilter>().mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        yield return null;
        sculpture.GetComponent<MeshFilter>().mesh.CombineMeshes(combineFinal, true, true);
        sculpture.GetComponent<MeshRenderer>().material = Material1;
        Debug.Log("sculpture created");
        //UnityEditor.PrefabUtility.SaveAsPrefabAsset(sculpture, "Assets/MySculpture1.prefab");
    }
}
