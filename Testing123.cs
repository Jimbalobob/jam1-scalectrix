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
        rollres = 600.0f;
        topspeed = 1000.0f;
        topacc = 500.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("w"))
        {
            if (throttle < 1.0f)
            {
                throttle = throttle + (1.0f * Time.deltaTime);  // input throttle between 0.0-1.0 - can make this the same as a controller trigger button in future
                if (throttle > 1.0f) { throttle = 1.0f; }
            }
        }
        else
        {
            throttle = throttle - (2.0f * Time.deltaTime);     // reduce throttle if let go
            trackacc = trackacc - (10.0f * Time.deltaTime);    // if not accelerating, decelerate
        }
        if (throttle < 0.0f) { throttle = 0.0f; }                 // can't have negative throttle

        trackacc = (throttle * topacc);                         // set acceleration to throttle 

        trackspeed = trackspeed - (rollres * Time.deltaTime);             // rolling resistance always slows car down
        if (trackspeed < 0.0f) { trackspeed = 0.0f; }                     // can't go backwards
        trackspeed = trackspeed + (trackacc * 20.0f * Time.deltaTime);    // apply acceleration
        if (trackspeed > topspeed) { trackspeed = topspeed; }               // limit top speed

        transform.Translate(trackspeed * Time.deltaTime, 0, 0);          // move car
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 240, 40), "throttle:" + throttle + " trackacc:" + trackacc);
        GUI.Box(new Rect(10, 40, 240, 40), "trackspeed:" + trackspeed);
    }