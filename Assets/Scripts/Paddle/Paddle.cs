using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float speed = 6.5f;
    [SerializeField] private Ball ballPrefab;

    void Start() {
        SpawnBall();
    }

    //TODO
    void Update()
    {
        // Move paddle left and right using keyboard keys, mapping is up to you
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }

        float boundedX = Mathf.Clamp(transform.position.x, -5.19f, 5.19f);
        transform.position = new Vector3(boundedX, transform.position.y, transform.position.z);

        // Paddle should be able to launch the ball upon space bar being pressed
        // A launched ball will then bounce around, changing its direction upon any collision
    }

    public void SpawnBall() {
        Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y + 0.4f, 0), Quaternion.identity);
    }
}
