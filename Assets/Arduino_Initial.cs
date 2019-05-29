using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class Arduino_Initial : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("COM3", 57600);
    public static int rot;
    public static float rotX, rotY, rotZ;
    // Use this for initialization
    void Start()
    {
        OpenConnection();
    }

    // Update is called once per frame
    void Update()
    {
        // print(UnityReadData());
        try
        {
            string[] s = sp.ReadLine().Split(',');

            rotX = float.Parse(s[0]);
            rotY = float.Parse(s[1]);
            rotZ = float.Parse(s[2]);

        }
        catch (System.Exception) { }

    }

    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                sp.Open(); // opens the connection
                sp.ReadTimeout = 100; //sets the timeout value before reporting error
                print("Port Opend!");
            }
        }
        else
        {
            if (sp.IsOpen)
                print("Port is already open");
            else
                print("Port == null");
        }
    }

    void OnApplicationQuit()
    {
        sp.Close();
    }

    public static void UnitySendData(string m)
    {
        sp.Write(m);
    }

    /* public static string UnityReadData()
     {
         string me;
         try
         {
             return(sp.ReadLine());
         }catch(System.Exception){ return "0"; }

         //return me;
     }*/

}

