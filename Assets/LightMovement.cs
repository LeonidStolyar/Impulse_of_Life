using UnityEngine;

public class LightMovement : MonoBehaviour
{
    public string direction;
    [SerializeField] private float lenghtMove;

    private Vector2 vec2Dir;
    private Rigidbody2D rb;

    private void Awake() {
        ChangeDir();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 0f, 1f);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (direction == "top"){
            vec2Dir.x = 0;
            vec2Dir.y = 1;
        }
        else if (direction == "left"){
            vec2Dir.x = -1;
            vec2Dir.y = 0;
        }
        else if (direction == "down"){
            vec2Dir.x = 0;
            vec2Dir.y = -1;
        }
        else if (direction == "right"){
            vec2Dir.x = 1;
            vec2Dir.y = 0;
        }
    }
    public void ChangeDir()
    {
        
    }
    private void FixedUpdate() {
        
    }
    private void Move()
    {
        transform.position += new Vector3(vec2Dir.x * lenghtMove, vec2Dir.y * lenghtMove);
    }
}
