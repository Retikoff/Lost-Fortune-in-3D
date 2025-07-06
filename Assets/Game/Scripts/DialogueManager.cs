using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private TMP_Text dialogueText;
    private Dictionary<CameraStates, string> texts = new();
    private void Start()
    {
        dialogueCanvas.gameObject.SetActive(false);
        texts[CameraStates.Empty] = " ";
    }

    public void GenerateText(string NPCName, float number, int objectChoice)
    {
        texts[CameraStates.Init] = "Init state";
        texts[CameraStates.NPC] = "NPC Scene " + NPCName;
        texts[CameraStates.Forest] = "Forest Scene " + number;
        texts[CameraStates.Lawn] = "Lawn Scene " + objectChoice;
        texts[CameraStates.Error] = "?Error?";
        texts[CameraStates.End] = "End";
    }

    private void Update()
    {
        CameraStates currentCameraState = cameraMovement.GetCameraState();

        if (currentCameraState == CameraStates.Init)
        {
            dialogueCanvas.gameObject.SetActive(true);
        }
        if (currentCameraState == CameraStates.End)
        {
            dialogueCanvas.gameObject.SetActive(false);
        }

        dialogueText.text = texts[currentCameraState];
    }
}
