using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Vector3[] key;
    [SerializeField] private int currentKey;
    [Range(0.01f,2f)]
    [SerializeField] private float speed;
    [Range(0.0f, 5f)]
    [SerializeField] private float pauseTime;
    [SerializeField] private bool forward;
    [SerializeField] private bool loop;
    [SerializeField] private bool canMove;
    private int nextKey;
    private float distance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = key[currentKey];
        NextKey();
        StartCoroutine(MovePause());
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            if (rb.position == key[nextKey])
            {
                currentKey = nextKey;
                NextKey();
            }
            rb.MovePosition(Vector3.MoveTowards(rb.position, key[nextKey], speed * MovingPlatformSettings.movingPlatformSettings.curveDefault.Evaluate(Vector3.Distance(rb.position, key[nextKey]) / distance)));
        }
    }
    private void NextKey() 
    {
        if (forward)
        {
            if (currentKey == key.Length - 1)
            {
                if (loop)
                {
                    nextKey = 0;
                    GetCurrentDistance();
                }
                else
                {
                    forward = false;
                    StartCoroutine(MovePause());
                }
            }
            else
            {
                nextKey++;
                GetCurrentDistance();
            }
        }
        else 
        {
            if (currentKey == 0)
            {
                if (loop)
                {
                    nextKey = key.Length - 1;
                    GetCurrentDistance();
                }
                else
                {
                    forward = true;
                    StartCoroutine(MovePause());
                }
            }
            else 
            {
                nextKey--;
                GetCurrentDistance();
            }
        }
    }
    private void GetCurrentDistance()
    {
        distance = Vector3.Distance(key[currentKey], key[nextKey]); ;
    }
    private IEnumerator MovePause() 
    {
        canMove = false;
        yield return new WaitForSeconds(pauseTime);
        canMove = true;
    }

    /*private float GetCurrentDistance() 
    {
        float dist = 0f;
        bool isLastWay = false;
        if (nextKey == key.Length - 1 & forward | nextKey == 0 & !forward) 
        {
            isLastWay = true;
            Debug.Log("lastway");
        }
        if (isLastWay)
        {
            return Vector3.Distance(rb.position, key[nextKey]);
        }
        else 
        {
            if (forward)
            {
                for (int i = nextKey; i < key.Length - 1; i++)
                {
                    dist += Vector3.Distance(key[i], key[i + 1]);
                }
                dist += Vector3.Distance(rb.position, key[nextKey]);
            }
            else 
            {
                for (int i = nextKey; i > 0; i--)
                {
                    dist += Vector3.Distance(key[i], key[i - 1]);
                }
                dist += Vector3.Distance(rb.position, key[nextKey]);
            }
            return dist;
        }
    }
    */
}
