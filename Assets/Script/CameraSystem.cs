using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private float x;
    [Range(1f, 20f)] 
    [SerializeField] private float height;
    [Range(1f, 20f)] 
    [SerializeField] private float distance;
    [Range(0.05f, 5f)] 
    [SerializeField] private float followSpeed;

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(x, height, Player.player.rb.position.z - distance), followSpeed * Time.deltaTime);
    }
    /*private void FixedUpdate()
    {
        float magnitude = Player.player.rb.velocity.magnitude;
        height = Mathf.Clamp(Mathf.Lerp(height, height * magnitude / 20f, 0.005f), 15f, 20f);
        distance = Mathf.Clamp(Mathf.Lerp(distance, distance * magnitude / 10f, 0.005f), 5f, 10f);
    }
    */
}
