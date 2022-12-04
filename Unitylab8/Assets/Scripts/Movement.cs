using UnityEngine;

public class Movement : MonoBehaviour
{
    //parameters - for tuning, typically set in the editor
    // cashe - e.g. references for redability or speed
    //state - private instance variables
    Rigidbody rb;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticles;
    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessInput();
        ProcessRotation();
    }

    void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
        
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

     private void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
       rb.freezeRotation = true; //freezing rotation so we can manually rotate
       transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
       rb.freezeRotation = false; //unfreezing rotation so the physics sustem can take over
    }

    void AudioSource()
    {

    }
    
}
