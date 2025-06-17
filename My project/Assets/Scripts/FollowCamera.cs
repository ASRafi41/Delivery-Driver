using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingsToFollow; // The object the camera will follow
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = thingsToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
