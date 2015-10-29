using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    // Update is called once per frame (called before rendering a frame)
    private void Start()
    {
        offset = transform.position;
    }

    // Better for follow cameras, procedure animation and gathering last known states
    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
