using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int MAX_OBJECTS = 20;
    [SerializeField] private GameObject[] TreePrefabs;
    [SerializeField] private GameObject NPCPrefab;
    private string NPCName;
    private float number;
    private int objectChoice;

    public void SetUp(string NPCName, float number, int objectChoice)
    {
        this.NPCName = NPCName;
        this.number = number;
        this.objectChoice = objectChoice;
        GenerateScene();
    }

    private void GenerateScene()
    {
        //spawn player and tablet with NPCName
        //spawn forest with number of trees
        // x: -2.7 -11, z: 14 7
        // y : 0.32
        //spawn lawn of objects
        // x: 7 11 , z: 8 11 find better values
        // y: 0.52

        //tree generator
        for (int i = 1; i <= number; i++)
        {
            var newTree = Instantiate(TreePrefabs[Random.Range(0, 5)]);
            newTree.name = "Tree " + i.ToString();
            newTree.transform.position = new Vector3(Random.Range(-2.7f, -11.5f), 0.32f, Random.Range(7f, 14.1f));
        }

        //objects generator
        UnityEngine.Debug.Log(GetObjectPathById(objectChoice));
        GameObject selectedObject = GetObjectPrefabFromResources(GetObjectPathById(objectChoice));
        for (int i = 1; i <= MAX_OBJECTS; i++)
        {
            var newObject = Instantiate(selectedObject);
            newObject.name = "Object " + i.ToString();
            newObject.transform.position = new Vector3(Random.Range(7f, 11f), 0.52f, Random.Range(8f, 11f));
        }
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
