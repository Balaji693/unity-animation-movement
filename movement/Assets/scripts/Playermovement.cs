
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    
    public GameObject player;
    public Rigidbody rb;
    // Start is called before the first frame update

    // Update is called once per frame

  void Update()
    {
      if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            

        }
        if (Input.touchCount > 7)
        {
            Touch touch = Input.GetTouch(7);
            Debug.Log("helloww");

        }

    }

}
