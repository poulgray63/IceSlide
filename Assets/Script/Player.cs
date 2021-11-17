using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Player : MonoBehaviour
{
    public static Player player;
    [HideInInspector] public Rigidbody rb;
    private BoxCollider boxCollider;
    private bool _isInsideFinish = false;
    private bool isInsideFinish 
    {
        get 
        {
            return _isInsideFinish;
        }
        set
        {
            if (_isInsideFinish != value)
            {
                _isInsideFinish = value;
                if (value)
                {
                    WinTimer.instance.TimerStart();
                }
                else 
                {
                    WinTimer.instance.TimerStop();
                }
            }
        }
    }
    private void Awake()
    {
        player = this;
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }
    public void SetStartPosition() 
    {
        rb.velocity = Vector3.zero;
        rb.position = Vector3.zero;
        rb.rotation = Quaternion.Euler(Vector3.zero);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(TagManager.instance.water))
        {
            SetStartPosition();
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag(TagManager.instance.finish))
        {
            if (boxCollider.bounds.min.x >= collider.bounds.min.x & boxCollider.bounds.max.x <= collider.bounds.max.x & boxCollider.bounds.min.z >= collider.bounds.min.z & boxCollider.bounds.max.z <= collider.bounds.max.z)
            {
                isInsideFinish = true;
            }
            else 
            {
                if (isInsideFinish) 
                {
                    isInsideFinish = false;
                }
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag(TagManager.instance.finish))
        {
            WinTimer.instance.TimerStop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagManager.instance.spike)) 
        {
            SetStartPosition();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagManager.instance.boost)) 
        {
            rb.AddForce(Vector3.forward * 1500f * Time.deltaTime);
        }
    }
}
