using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private CameraStates cameraState;
    [SerializeField] private Vector3[] positions;
    [SerializeField] private Vector3[] rotations;
    private int currentPositionId = 0;
    InputAction action;
    void Start()
    {
        cameraState = CameraStates.Empty;
        action = InputSystem.actions.FindAction("Jump");
        MoveToNextPosition();
    }

    void Update()
    {
        //states?? i wanna keep them to separate dialogue logic and build it reliable on camerastates

        if (action.WasPressedThisFrame() && currentPositionId < positions.Length)
        {
            MoveToNextPosition();
            UpdateState();
        }
    }

    public void SetCameraState(CameraStates cameraState)
    {
        this.cameraState = cameraState;
    }

    private void MoveToNextPosition(float duration = 2f)
    {
        transform.DOMove(positions[currentPositionId++], duration);
    }

    private void UpdateState()
    {
        switch (currentPositionId)
        {
            case 0:
                cameraState = CameraStates.Empty;
                break;
            case 1:
                cameraState = CameraStates.Init;
                break;
            case 2:
                cameraState = CameraStates.NPC;
                break;
            case 3:
                cameraState = CameraStates.Forest;
                break;
            case 4:
                cameraState = CameraStates.Lawn;
                break;
            default:
                cameraState = CameraStates.Error;
                break;
        }
    }
}
