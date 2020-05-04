using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rig;

    
    private AudioSource audioSource;



    void Awake()
    {
        Time.timeScale = 1.0f;

        //Get the rigid body component of the player
        rig = GetComponent<Rigidbody>();

        //This gets the coin audio from the component
        audioSource = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

        //If the game is paused simply end this function
        if (GameManager.instance.paused == true)
        {
            Debug.Log("Game is Paused");
            return;
        }

        if (transform.position.y < -20)
        {
            GameManager.instance.GameOver();     
        }

        //Calls the move function
        Move();    
     
    }

    void Move()
    {
        //This returns a -1 if the a key is held down and 1 if the right key is
        float xInput = Input.GetAxis("Horizontal");

        //This does the same thing but for the w and s key.
        float zInput = Input.GetAxis("Vertical");

        //This creates the new direction for my player
        Vector3 dir = new Vector3(xInput, 0, zInput) * moveSpeed;

       

        //This sets the y velocity to the current velocity
        dir.y = rig.velocity.y;

        rig.velocity = dir;


        //This is for the facing direction
        Vector3 facingDir = new Vector3(xInput, 0, zInput);


        if (facingDir.magnitude > 0)
        {
            transform.forward = facingDir;
        }

        if(Input.GetButtonDown("Jump"))
        {
            TryJump();
        }
    }

    public float jumpForce;

    void TryJump()
    {
        //Creates a ray at every corner to point down
        Ray ray1 = new Ray(transform.position + new Vector3(0.5f, 0, 0.5f), Vector3.down);
        Ray ray2 = new Ray(transform.position + new Vector3(-0.5f, 0, 0.5f), Vector3.down);
        Ray ray3 = new Ray(transform.position + new Vector3(0.5f, 0, -0.5f), Vector3.down);
        Ray ray4 = new Ray(transform.position + new Vector3(-0.5f, 0, -0.5f), Vector3.down);

        //Cast the rays to boolean variables
        bool cast1 = Physics.Raycast(ray1, 0.7f);
        bool cast2 = Physics.Raycast(ray2, 0.7f);
        bool cast3 = Physics.Raycast(ray3, 0.7f);
        bool cast4 = Physics.Raycast(ray4, 0.7f);

        //If any is true then the player should be able to jump
        if(cast1 || cast2 || cast3 || cast4)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    //This triggers when I collide with something 
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("I Hit Something");
        //If the thing I collide with has an enemy tag
        if (other.CompareTag("Enemy"))
        {
            //I call the gameover function from GameManager
            GameManager.instance.GameOver();
        }
        else if(other.CompareTag("Coin"))
        {
            //This destroys the coin
            Destroy(other.gameObject);

            //This plays the audio when the player collides with a coin
            audioSource.Play();

            //Go into the GameManager class and activate the add score function
            GameManager.instance.AddScore(1);

            
        }
        else if(other.CompareTag("Goal"))
        {
            //Calls the level end function when the goal is pressed
            GameManager.instance.LevelEnd();
        }
    }

    
}
