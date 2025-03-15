using AYellowpaper.SerializedCollections.Editor.Data;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public string Name;

    [SerializeField] int moveSpeed;
    public bool canMove = true;
    [SerializeField] KeyCode interactKey;
    [SerializeField] float interactRadius = 5;
    [SerializeField] LayerMask interactLayer;


    Rigidbody2D rb;
    Animator anim;

    Vector2 movement;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);

        Debug.Log(movement.sqrMagnitude);
        anim.SetFloat("Speed", movement.sqrMagnitude);


        if (Input.GetKeyDown(interactKey) && canMove)
        {
            Collider2D interaction = Physics2D.OverlapCircle(transform.position, interactRadius, interactLayer);
            if (interaction == null) return;

            interaction.GetComponent<Interactable>().Interact();
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            movement = movement.normalized;
            rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed) * Time.fixedDeltaTime;
        } else rb.velocity = Vector2.zero;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
