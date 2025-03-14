using AYellowpaper.SerializedCollections.Editor.Data;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
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
    float horizontal;
    float vertical;

    Rigidbody2D rb;
    Animator anim;

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
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

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
            Vector2 movement = new Vector2(horizontal, vertical).normalized;
            rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed) * Time.fixedDeltaTime;
        } else rb.velocity = Vector2.zero;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
