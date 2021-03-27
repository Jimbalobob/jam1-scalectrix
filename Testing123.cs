using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing123 : MonoBehaviour
{

    public static float trackspeed;  // speed along the track
    public static float throttle;    // amount of input throttle
    public static float trackacc;    // acceleration down the track
    public static float rollres;     // rolling resistance
    public static float topspeed;    // top speed
    public static float topacc;      // top acceleration

    // Start is called before the first frame update
    void Start()
    {
       trackspeed = 0.0f;
       throttle = 0.0f;
       trackacc = 0.0f;
       rollres = 0.5f;
       topspeed = 100.0f;
       topacc = 40.0f;
    }

    // Update is called once per frame
    void Update()
    {
       throttle = throttle - (0.25f * Time.deltaTime);
       if (Input.GetKey("w"))
       {
           if (throttle < 1.0f)
           {
               throttle = throttle + (0.5f * Time.deltaTime);
               if (throttle > 1.0f) {throttle = 1.0f;}
           }
       } else {
       trackacc = trackacc - (0.5f * Time.deltaTime);
       }
       if (throttle < 0.0f) {throttle = 0.0f;}      
       
       trackacc = trackacc + (throttle * Time.deltaTime);
       if (trackacc > topacc) {trackacc = topacc;}
       if (trackacc < 0.0f) {trackacc = 0.0f;}
       trackspeed = trackspeed - (0.1f * Time.deltaTime);
       trackspeed = trackspeed + (trackacc * Time.deltaTime);
       if (trackspeed > topspeed) {trackspeed = topspeed;}
       if (trackspeed < 0.0f) {trackspeed = 0.0f;}
       transform.Translate (trackspeed * Time.deltaTime, 0, 0);  
    }
    private void OnGUI()
    {
       GUI.Box(new Rect(10, 10, 240, 40), "throttle:" + throttle + " trackacc:" + trackacc);
       GUI.Box(new Rect(10, 40, 240, 40), "trackspeed:" + trackspeed);
    }
}
