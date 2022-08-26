using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform player;
    private Vector3 nextCameraPosition;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        nextCameraPosition = new Vector3(player.position.x, player.position.y, -10);
    }

    private void FixedUpdate()
    {
        nextCameraPosition.x = player.position.x;
        nextCameraPosition.y = player.position.y;
        this.transform.position = nextCameraPosition;
    }
}
