
using UnityEngine;

public class Myjoystickcontroller : MonoBehaviour
{
    protected Joystick joystick;

    public float Cameralook = 100f;
    public float forwardforce = 2000f;

    public Transform playerbody;
    
    // Update is called once per frame
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        
    }
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
     if(joystick.Horizontal <= 2f)
        {
            rigidbody.velocity = new Vector3(joystick.Horizontal * 50f + Input.GetAxis("Horizontal"),
                                     rigidbody.velocity.y,
                                       0);
            rigidbody.AddForce(0, 0, forwardforce * Time.deltaTime, ForceMode.VelocityChange);

            
        }
        if (joystick.Horizontal <= -2f)
        {
            rigidbody.velocity = new Vector3(joystick.Horizontal *-50f + Input.GetAxis("Horizontal"),
                                     rigidbody.velocity.y,
                                       0);
            rigidbody.AddForce(0, 0, forwardforce * Time.deltaTime, ForceMode.VelocityChange);

          
        }




       



    }
}
