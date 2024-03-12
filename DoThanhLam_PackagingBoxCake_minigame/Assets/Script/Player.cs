using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    private bool canMove = true;
    private Vector2 previousPosition;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (gameManager.isGameOver == false && gameManager.isGameWinner == false && canMove)
        {
            PlayerController();
        }
    }

    private void PlayerController()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2.right);
        }
    }

    private void Move(Vector2 direction)
    {
        Vector2 temporaryPosition = transform.position + (Vector3)direction;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(temporaryPosition, 0.2f);

        bool canMoveToPosition = true;
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Wall"))
            {
                canMoveToPosition = false;
                break;
            }
        }

        if (canMoveToPosition)
        {
            previousPosition = transform.position;
            transform.position = temporaryPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BlockZone"))
        {
            transform.position = new Vector2(transform.position.x, 1);
        }
        else if (collision.CompareTag("BlockZone1"))
        {
            transform.position = new Vector2(transform.position.x, -1);
        }
        else if (collision.CompareTag("BlockZone2"))
        {
            transform.position = new Vector2(1, transform.position.y);
        }
        else if (collision.CompareTag("BlockZone3"))
        {
            transform.position = new Vector2(-1, transform.position.y);
        }
        else if (collision.CompareTag("point"))
        {
            Destroy(collision.gameObject);
            gameManager.isGameWinner = true;
        }
        else if (collision.CompareTag("Wall"))
        {
            transform.position = previousPosition;
        }
    }
}