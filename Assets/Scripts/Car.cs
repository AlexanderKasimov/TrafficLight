using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Rigidbody2D rb;

    private Color32 color;

    private Vector2 movementDirection;
    [SerializeField]
    private float movementSpeed = 10f;

    private SpriteRenderer spriteRenderer;

    private bool isColorActive = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();


    }


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnTrafficLightChanged += OnTrafficLightChanged;

    }

    public void Init(Vector2 movementDirection, Color32 color)
    {
        this.movementDirection = movementDirection.normalized;
        this.color = color;
        spriteRenderer.color = color;
        CheckIfColorActive(GameManager.instance.GetActiveColor());
    }  

    private void FixedUpdate() 
    {
        if (isColorActive)
        {
            Vector2 movementVector = movementDirection * movementSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movementVector);
        }

    }

    private void OnTrafficLightChanged(Color32 color)
    {    
        CheckIfColorActive(color);
    }

    private void CheckIfColorActive(Color32 color)
    {
        isColorActive = this.color.r == color.r && this.color.g == color.g && this.color.b == color.b; 

    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Car"))
        {
            GameManager.instance.Lose();
        }
        if (other.CompareTag("Finish"))
        {
            GameManager.instance.CarFinished();
        }       

        Destroy(gameObject);
    }
}
