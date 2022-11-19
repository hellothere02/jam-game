using UnityEngine;
using Cinemachine;


public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerRHTransform;
    //[SerializeField] private Transform playerLHTransform;
    [SerializeField] private CinemachineVirtualCamera leftCam;
    //private Vector3 offset;

    //private void Start()
    //{
    //    offset = transform.position - playerRHTransform.position;
    //}

    //private void FixedUpdate()
    //{
    //    transform.position = playerRHTransform.position + offset;
    //    //if (playerRHTransform.gameObject.activeInHierarchy)
    //    //{
    //    //    transform.position = playerRHTransform.position + offset;
    //    //}
    //    //else
    //    //{
    //    //    transform.position = playerLHTransform.position + offset;
    //    //}
    //}

    private void Update()
    {
        if (playerRHTransform.gameObject.activeInHierarchy)
        {
            leftCam.Priority = 11;
        }
        else
        {
            leftCam.Priority = 13;
        }
    }
}

