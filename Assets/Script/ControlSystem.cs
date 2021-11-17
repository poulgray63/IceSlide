using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlSystem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static ControlSystem instance;
    private Vector2 dragStartPosition;
    private Vector2 direction;
    private float angle = 0.0f;
    private float lenght = 0.0f;
    private Vector2 forcePerPixel;
    private bool isDraging = false;


    [Range(1f, 5f)]
    [HideInInspector] public bool canImpulse = true;
    [Range(100f,5000f)]
    [SerializeField] private float forceMultiplier;
    [SerializeField] private float cooldownTime; 
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform linePointer;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private Animator animatorCooldown;

    private void Awake()
    {
        instance = this;
        animatorCooldown.SetFloat("CooldownTime", 1 / cooldownTime);
        forcePerPixel = new Vector2(1f / Screen.width, 1f / Screen.height);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(GameCycle.instance.statement == GameCycle.Statement.Waiting) 
        {
            GameCycle.instance.statement = GameCycle.Statement.Game;
        }
        lineRenderer.enabled = true;
        linePointer.gameObject.SetActive(true);
        dragStartPosition = new Vector2(eventData.position.x * forcePerPixel.x, eventData.position.y * forcePerPixel.y);
        isDraging = true;
        Time.timeScale = 0.33f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Player.player.rb.angularVelocity = Vector3.zero;
        Vector2 dragPosition = new Vector2(eventData.position.x * forcePerPixel.x, eventData.position.y * forcePerPixel.y);
        direction = new Vector2(dragStartPosition.x - dragPosition.x, dragStartPosition.y - dragPosition.y);
        angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        lenght = Vector2.Distance(dragStartPosition, dragPosition) * 15;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lineRenderer.enabled = false;
        linePointer.gameObject.SetActive(false);
        if (canImpulse)
        {
            Player.player.rb.AddForce(new Vector3(direction.x, 0f, direction.y) * forceMultiplier);
            animatorCooldown.SetTrigger("Reload");
            canImpulse = false;
        }
        else 
        {
            animatorCooldown.SetTrigger("NotReady");
        }
        isDraging = false;
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (isDraging) 
        {
            lineRenderer.SetPosition(1, Vector3.Lerp(lineRenderer.GetPosition(1), new Vector3(0f, 0f, lenght), 50f * Time.deltaTime));
            linePointer.localPosition = Vector3.Lerp(linePointer.localPosition, new Vector3(0f, 0f, lenght), 50f * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        if (isDraging) 
        {
            //Player.player.rb.MoveRotation(Quaternion.Euler(0f, Mathf.Lerp(Player.player.rb.rotation.eulerAngles.y, angle, 0.5f), 0f));
            Player.player.rb.MoveRotation(Quaternion.Euler(0f, angle, 0f));
        }
    }
}
