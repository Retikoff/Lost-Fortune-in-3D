using System.Diagnostics;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private int MAX_OBJECTS = 20;
    [SerializeField] private GameObject[] TreePrefabs;
    [SerializeField] private TMP_Text NPCNameComponent;

    public void GenerateScene(string NPCName, float number, int objectChoice)
    {
        //change NPCName
        //
        //spawn forest with number of trees
        // x: 0 -11.8, z: 11.78 4
        // y : 0.32
        //
        //spawn lawn of objects
        // x: 7 11 , z: 8 11 
        // y: 0.62


        //NPC name
        NPCNameComponent.text = NPCName;

        //tree generator
        for (int i = 1; i <= number; i++)
        {
            var newTree = Instantiate(TreePrefabs[Random.Range(0, 5)]);
            newTree.name = "Tree " + i.ToString();
            newTree.transform.position = new Vector3(Random.Range(0f, -11.8f), 0.32f, Random.Range(4f, 11.78f));
        }

        //objects generator
        UnityEngine.Debug.Log(GetObjectPathById(objectChoice));
        GameObject selectedObject = GetObjectPrefabFromResources(GetObjectPathById(objectChoice));
        for (int i = 1; i <= MAX_OBJECTS; i++)
        {
            var newObject = Instantiate(selectedObject);
            newObject.name = "Object " + i.ToString();
            newObject.transform.position = new Vector3(Random.Range(7f, 11f), 0.57f, Random.Range(8f, 11f));
            newObject.transform.Rotate(new Vector3(0, Random.Range(0f, 90f), 0));
        }

        //invoke camera
        cameraMovement.SetCameraState(CameraStates.Init);
        GetComponent<DialogueManager>().GenerateText(NPCName, number, objectChoice);
    }

    private GameObject GetObjectPrefabFromResources(string name)
    {
        return Resources.Load<GameObject>(name);
    }

    private string GetObjectPathById(int id)
    {
        return id switch
        {
            0 => "Objects/Mushroom",
            1 => "Objects/Agaric",
            2 => "Objects/Rose",
            3 => "Objects/Cornflower",
            _ => ""
        };
    }
}
