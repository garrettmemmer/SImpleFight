using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehaviour : MonoBehaviour
{

    // Transform of the GameObject you want to shake
    private Transform transform;

    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.3f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;//tutorial had this as Vector3d

    public bool shakeMe = false;

    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//should this be in fixed update?
    {

        if(shakeMe == true)
        {
            TriggerShake();
            Debug.Log(shakeDuration); // "ScreenWiggle() called");
            shakeMe = false;
        }

        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
            Debug.Log("inside shakeDuration > 0;....." +  shakeDuration);
        }
        else
        {
            if (shakeDuration < 0)
            {
                shakeDuration = 0f;
                transform.localPosition = initialPosition;
               // shakeMe = false;
            }

        }
    }

    public void ShakeKey()
    {

    }

    public void TriggerShake()
    {
        shakeDuration = 2.0f;
        //edit private float dampingSpeed = 10.0f;
        dampingSpeed = 10.0f;


    }

    //should i just make a variable that will call TriggerShake()
}
