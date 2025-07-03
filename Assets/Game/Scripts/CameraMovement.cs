using DG.Tweening;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private CameraStates cameraState;
    [SerializeField] private Vector3[] positions;
    private int currentPositionId = 0;
    void Start()
    {
        cameraState = CameraStates.Empty;
        MoveToNextPosition();
    }

    void Update()
    {
        //states?? i wanna keep them to separate dialogue logic and build it reliable on camerastates
        if (Input.GetKeyDown(KeyCode.Space) && currentPositionId < positions.Length)
        {
            MoveToNextPosition();
        }
    }

    public void SetCameraState(CameraStates cameraState)
    {
        this.cameraState = cameraState;
    }

    private void MoveToNextPosition(float duration = 1f)
    {
        transform.DOMove(positions[currentPositionId++], duration);
    }
}
