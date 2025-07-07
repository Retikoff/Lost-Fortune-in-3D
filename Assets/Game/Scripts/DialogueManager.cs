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
        texts[CameraStates.Init] = "Очнувшись главный герой не понимал где он и что вообще забыл на этом пустыре.";
        texts[CameraStates.NPC] = "Подняв глаза, наш герой увидел жизнерадостного человека по имени " + NPCName + ". Но на этом наш герой не остановился и осмелился пойти дальше...";
        texts[CameraStates.Forest] = "Пройдя небольшое расстояние, главный герой увидел лес из " + number + " деревьев различных видов.";
        texts[CameraStates.Lawn] = "Миновав лес, наш герой наткнулся на поляну " + GetTextByObjectChoice(objectChoice) + " еще не тронутую ни одним живым существом.";
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

    private string GetTextByObjectChoice(int objectChoice)
    {
        return objectChoice switch
        {
            0 => "грибов",
            1 => "мухоморов",
            2 => "роз",
            3 => "васильков",
            _ => "error"
        };
    }
}
