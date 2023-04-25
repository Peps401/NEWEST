using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public bool initialVisibility = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(initialVisibility);
        DoorController[] doorControllers = GetComponentsInChildren<DoorController>();
        foreach (DoorController door in doorControllers)
        {
            door.roomController = this;
        }
    }

    public void Toggle(bool visible){
        gameObject.SetActive(visible);
    }
}
