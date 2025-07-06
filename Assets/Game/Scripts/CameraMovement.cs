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
        if (action.WasPressedThisFrame() && currentPositionId < positions.Length)
        {
            UpdateState();
            RotateForNextPosition();
            MoveToNextPosition();
        }
    }

    public void SetCameraState(CameraStates cameraState)
    {
        this.cameraState = cameraState;
    }

    public CameraStates GetCameraState()
    {
        return cameraState;
    }

    private void MoveToNextPosition(float duration = 4f)
    {
        transform.DOMove(positions[currentPositionId++], duration);
    }

    private void RotateForNextPosition(float duration = 4f)
    {
        transform.DORotate(rotations[currentPositionId], duration);   
    }

    private void UpdateState()
    {
        cameraState = currentPositionId switch
        {
            //i want to keep them for dialogue system
            0 => CameraStates.Empty,
            1 => CameraStates.Init,
            2 => CameraStates.NPC,
            3 => CameraStates.Forest,
            4 => CameraStates.Lawn,
            5 => CameraStates.End,
            _ => CameraStates.Error,
        };
    }
}
