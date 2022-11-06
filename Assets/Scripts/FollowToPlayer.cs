using UnityEngine;


public class FollowToPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerRHTransform;
    //[SerializeField] private Transform playerLHTransform;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - playerRHTransform.position;
    }

    private void FixedUpdate()
    {
        transform.position = playerRHTransform.position + offset;
        //if (playerRHTransform.gameObject.activeInHierarchy)
        //{
        //    transform.position = playerRHTransform.position + offset;
        //}
        //else
        //{
        //    transform.position = playerLHTransform.position + offset;
        //}
    }
}

