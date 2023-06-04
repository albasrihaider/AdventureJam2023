using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public int Height, Width, X, Y;
    // Start is called before the first frame update
    void Start()
    {
        if (RoomController.instance == null)
        {
            Debug.Log("Pressed play in the wrong scene!");
            return;

        }

        RoomController.instance.RegisterRoom(this);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
    }
    public Vector3 GetRoomCentre()
    {
        return new Vector3(X * Width, Y * Height, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
             //   Debug.Log("enter");
        RoomController.instance.OnPlayerEnterRoom(this);
        
        }
    }
}