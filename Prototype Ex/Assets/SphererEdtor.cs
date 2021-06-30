using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor (typeof(Spawner))]
public class SphererEdtor : Editor
{
    string path;
    string assetPath;
    string fileName;

    private void OnEnable()
    {
        path = Application.dataPath + "/Sphere";
        assetPath = "Assets/Sphere/";
        fileName = "sphere_" + System.DateTime.Now.Ticks.ToString();
    }


    public override void OnInspectorGUI()
    {
        Spawner spawner = (Spawner)target;
        DrawDefaultInspector();

        if(GUILayout.Button("Create Sphere"))
        {
            spawner.SpawnSphere();
        }

        if(GUILayout.Button("Save Sphere"))
        {
            System.IO.Directory.CreateDirectory(path);
            Mesh mesh = spawner.sphere.GetComponent<MeshFilter>().sharedMesh;
            AssetDatabase.CreateAsset(mesh, assetPath + mesh.name + ".asset");
            AssetDatabase.SaveAssets();

            PrefabUtility.SaveAsPrefabAsset(spawner.sphere, assetPath + fileName + ".prefab");
        }
    }
}
