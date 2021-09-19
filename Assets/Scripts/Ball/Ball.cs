using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody = null;

    private bool launched = false;
    private float speed = 6.5f;
    private Vector3 currentDirection = Vector3.zero;

    //TODO: Add code to move ball along with code to delete pieces upon colliding with one
    //Ball should only move once its been launched
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && currentDirection.Equals(Vector3.zero)) {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                currentDirection = new Vector3(0f, 1.0f, 0f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                currentDirection = new Vector3(-1.0f, 1.0f, 0f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                currentDirection = new Vector3(1.0f, 1.0f, 0f);
            }
            else {
                currentDirection = new Vector3(0f, 1.0f, 0f);
            }

            currentDirection = currentDirection.normalized;
        }

        if (!currentDirection.Equals(Vector3.zero)) {
            launched = true;
        }

        if (launched)
        {
            Vector3 newDelta = currentDirection * speed * 10f * Time.deltaTime;
            rigidBody.MovePosition(transform.position + newDelta);
        }
        else {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            }

            float boundedX = Mathf.Clamp(transform.position.x, -5.19f, 5.19f);
            transform.position = new Vector3(boundedX, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        currentDirection = Vector2.Reflect(currentDirection, collision.contacts[0].normal);
        if (collision.gameObject.CompareTag("Piece")) {
            Destroy(collision.gameObject);
        }
    }
}
