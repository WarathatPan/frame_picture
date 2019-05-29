using UnityEngine;
using System.Collections;

public class Gravity_Change : MonoBehaviour {

    // Use this for initialization
    Vector3 mypos;
    Collider2D mycolider;
    Rigidbody2D myrigi;
    Quaternion ROT;
    float check = 0;
    float start;
    float count = 0;
    float rtx, rty, rtz;
	void Start () {
        mypos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ROT = transform.rotation;
        mycolider = GetComponent<Collider2D>();
        myrigi = GetComponent<Rigidbody2D>();
        mycolider.enabled = false;
        myrigi.simulated = false;

       if (start == 0)
           InvokeRepeating("startROT", 1f ,0.1f);
            // Invoke("startROT", 1f);


    }
	
	// Update is called once per frame
	void Update () {
        // print("check : "+check);
        print("RZ : "+Arduino_Initial.rotY);
        // print(" count "+count);
        if (start == 1)
       {
            mycolider.enabled = true;
            myrigi.simulated = true;
            float x = Mathf.Sin(Mathf.Deg2Rad * Arduino_Initial.rotY);
            float y = Mathf.Cos(Mathf.Deg2Rad * Arduino_Initial.rotY);
            Physics2D.gravity = new Vector2(-x, -y);
            check = 0;
        }

        if (Arduino_Initial.rotY > -10f && Arduino_Initial.rotY < 10f)
        {
            check = 1;
            count++;
            Invoke("coutdown", 0f);
        }
        else {
            check = 0;
            count = 0;
        }
            
        
	}

    void startROT()
    {
        if (start==0 )
        {
            if (Arduino_Initial.rotY > -10f && Arduino_Initial.rotY < 10f)
            {
                start = 0;
            }
            else {
                start = 1;
            }
        }
       
    }

    void coutdown()
    {
        if (check == 1 && count == 1)
        {
            Invoke("coutdown2", 1f);
        }
    }

    void coutdown2()
    {
        if (check == 1 )
        {
            Invoke("coutdown3", 1f);
        }
    }

    void coutdown3()
    {
        if (check == 1 )
        {
            Invoke("coutdown4", 1f);
        }
    }

    void coutdown4()
    {
        if (check == 1 )
        {
            Invoke("backtobegin", 0f);
        }
    }
    void backtobegin()
    {
        mycolider.enabled = false;
        myrigi.simulated = false;
        transform.position = mypos;
        transform.rotation = ROT;
        Invoke("startROT", 1f);
        count = 0;
        start = 0;
    }

}
