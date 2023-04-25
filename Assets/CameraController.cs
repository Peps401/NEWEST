using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 velocity = Vector3.zero;

    [Range(0,1)]
    public float smoothTime;

    public Vector3 positionOffset = new Vector3(0,0, -10);

    private void Awake(){
        player = GameObject.FindGameObjectWithTag("MainCharacter").transform;
    }
    
    private void LateUpdate(){
        Vector3 targetPosition = player.position + positionOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
