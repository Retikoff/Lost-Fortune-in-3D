using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    }

    private void GenerateScene()
    {
        
    }
}
