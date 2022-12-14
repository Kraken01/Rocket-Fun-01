using UnityEngine; //monobehaviour class present in unity engine namespace
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour //inheriting monobehaviour class
{

    [SerializeField] float playerThrust = 1f;
    [SerializeField] float playerRotation = 1f;
    [SerializeField] AudioClip engineThrust;

    [SerializeField] public ParticleSystem mainThrust;
    [SerializeField] Image thrustImage;
    //[SerializeField] ParticleSystem leftThrust;
    //[SerializeField] ParticleSystem rightThrust;


    Rigidbody rigidbody; //rigidbody type variable
    AudioSource audioSource;

    bool isMoving = false;
    bool isRotatingRight = false;
    bool isRotatingLeft = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); //catching reference of rigid body
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Stationary:
                    StartThrusting();
                    break;
                case TouchPhase.Ended:
                    StopThrusting();
                    break;
            }
        }*/
        Playerthrust();
        Playerrotation();
    }

    void Playerthrust()
    {
        if (isMoving)
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void Playerrotation()
    {

        if (isRotatingRight)
        {
            RotateLeft();
        }

        else if (isRotatingLeft)
        {
            RotateRight();
        }

        else
        {
            StopRotating();
        }
    }

    void StartThrusting()
    {
        rigidbody.AddRelativeForce(Vector3.up * playerThrust * Time.deltaTime);//vector3.up is a short hand for(0, 1, 0) 
        //relative force is used to add force related to the cordinates of the object
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineThrust);
        }
        if (!mainThrust.isPlaying)
        {
            mainThrust.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainThrust.Stop();
    }

    void RotateLeft()
    {
        ApplyRotation(playerRotation);  
    }

    void RotateRight()
    {
        ApplyRotation(-playerRotation);  
    }

    void StopRotating()
    {
       // leftThrust.Stop();
       // rightThrust.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rigidbody.freezeRotation = true; //freezing rotation so we can manually control rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);//vector3.forward(0, 0, 1)
        rigidbody.freezeRotation = false; //unfreezing rotation so physics can take over
    }

    public void Move(bool move)
    {
        isMoving = move;
    }

    public void MoveRight(bool move)
    {
        isRotatingRight = move;
    }

    public void MoveLeft(bool move)
    {
        isRotatingLeft = move;
    }
}

