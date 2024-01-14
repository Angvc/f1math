using PathCreation.Examples;
using System;
using System.Collections;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public int lapcount;
    public GameObject ABC;
    private bool gameon;
    private bool inturn;
    // for countdown
    public float timeRemaining = 5;
    private bool Countdown;
    public TMP_Text timetext;
    private IEnumerator _timercr;

    // for correct&incorrect effects
    public bool Estatus;   // Estatus will be set to true from Answers.script
    public bool Astatus;    // Astatus takes answer status from Answers.script
    public GameObject quizui; // toggle on off during effects
    public GameObject infoui; // toggle on off during effects
    public PathFollower player; // controlling player's speed default at 20, need to change manually
    private float acceleration; // will be added to speed each frame, but also degrade over time

    //for match
    public float questionlimitreached ;
    public GameObject EndresultUI;
    [SerializeField] private speedotext inforbarcontroller;
    private float speedmod = 0f;
    private float turningspeed = 0;
    private float speedupdown = 20;
    private float speedbuildup;

    // for quiz indicator 3/3 wrong dnf
    [SerializeField] private Image first,second,third;
    private int wrongans;
    // for gear system
    private int currentgear;
    private int gearstrat;
    [SerializeField] private GameObject gearui;
    [SerializeField] private TextMeshProUGUI geartext;
    // for ai
    [SerializeField] private Aimanager aimanager;
    // for sfx
    [SerializeField] private AudioClip _Uipopupclip;
    [SerializeField] private AudioClip countdownclip;

    //for bgm
    [SerializeField] private GameObject rrace;
    [SerializeField] private GameObject finish;
    private void starttimer()
    {
        _timercr = Startcountdown(10);
        StartCoroutine(_timercr);
    }
    IEnumerator Startcountdown(int timeremaining)
    {
        for (int i = timeremaining; i >= 0; i--)
        {
            if (i >= 4) { timetext.text = "Ready?!"; }
            else if (i >= 3) { timetext.text = i.ToString(); SoundManager.Instance.Playsound(countdownclip); }
            else if (i >= 1) { timetext.text = i.ToString(); }
            else { timetext.text = "Go!";}

            yield return new WaitForSeconds(1);
        }
        timetext.text = " ";
        ABC.SetActive(true);
        infoui.SetActive(true);
        SoundManager.Instance.Playsound(_Uipopupclip);
        Countdown = false; gameon = true;
    }

    private void Start()
    {
        lapcount = 0;
        gameon = false;
        inturn = false;
        speedbuildup = 0;
        // Countdown = true;
        Estatus = false;
        Astatus = false;
        questionlimitreached = 0;
        player.speed = 0;
        acceleration = 0;
        currentgear = 0;
        gearstrat = 1;
        wrongans = 0;
        starttimer();
    }

    void Update()
    {
        // build up speed from 0 to 100 at start
        //if (gameon && speedbuildup < 100) { speedbuildup += 0.5f; }
        // check if in turn, reduce speed and grow accordingly
        Debug.Log(lapcount);
        if (inturn)
        {
            if (turningspeed < 50) { turningspeed += 1f; }
            else turningspeed = 50;
        }
        else
        {
            if (turningspeed > 0) {turningspeed -= 0.5f; }
            else turningspeed = 0;
        }
        //start of correct and wrong events, activated when estatus set to true in answers script
        // old
        /*if (Estatus)
        {   // cooldown is set from answers.script
            timeRemaining -= Time.deltaTime;
            // reducing and regrowing player's speed.
            if (Astatus){ speedmod = +(timeRemaining/5) * speedupdown; }
            else        { speedmod = -(timeRemaining / 5) * speedupdown; }

            //check if quizUI is active then deactivate it.
            if (quizui.activeSelf)
            {
                quizui.SetActive(false);
            }

            //reactivate it when cooldown is 0, reactivate UI ,and deactivate Estatus
            if (Math.Round(timeRemaining) <= 0) 
            {
                if (questionlimitreached >= 1) { gameon = false; }
                if (gameon) 
                {
                    speedmod = 0;
                    quizui.SetActive(true);
                    SoundManager.Instance.Playsound(_Uipopupclip);
                }

                Estatus = false;
            }
        }*/
        // new
        if (Estatus)
        {
            SoundManager.Instance.Playsound(_Uipopupclip);
            if (Astatus)
            {
                acceleration += 0.5f;
                currentgear += gearstrat;
                geartext.text = currentgear.ToString();
                quizui.SetActive(false);
                gearui.SetActive(true);
            } 
            else
            {
                wrongans += 1;
                switch (wrongans)
                {
                    case 1:
                        {
                            first.color = new Color(1f, 0.39f, 0.39f);
                        }break;
                    case 2:
                        {
                            second.color = new Color(1f, 0.39f, 0.39f);
                        }break;
                    case 3:
                        {
                            third.color = new Color(1f, 0.39f, 0.39f);
                        }break;
                }
            }

            Estatus = false;
        }

        speedmod += acceleration;
        if(speedmod < 0)  { speedmod = 0; }
        else if(speedmod >100) { speedmod = 100; }
        /// acceleration decay
        if(acceleration > -0.005f) { acceleration -= 0.0001f; }
        Debug.Log("accele: " + acceleration + " | speed: "+speedmod);
        //end of correct and wrong events, deactivated after it finished
        player.speed = speedmod * (1 - (turningspeed * 0.01f));
    }

    // triggered every lap
    private void OnTriggerEnter(Collider colider)
    {
        if (colider.CompareTag("turn"))
        {
            inturn = true;
        }
        else
        {
            lapcount++;
            Debug.Log(lapcount);
            inforbarcontroller.StartTimer();
            // if lap 3, gameon set to false, quiz ended. 
            if (lapcount >= 2)
            {
                gameon = false;
                ///Debug.Log("gamestatus= " + gameon);
                ABC.SetActive(false);
                infoui.SetActive(true);
                EndresultUI.SetActive(true);
                rrace.SetActive(false);
                finish.SetActive(true);
                gearui.SetActive(false);
            }
        }
        //end of lapcount events
    }

    private void OnTriggerExit(Collider colider)
    {
        if (colider.CompareTag("turn"))
        {
            inturn = false;
            Debug.Log(inturn);
        }
    }

        // for countdown
        void DisplayTime(float timetodisplay)
    {
        timetodisplay -= 1;
        timetext.text = Math.Round(timetodisplay).ToString();
    }

    public int getcurrentgear()
    {
        return currentgear;
    }
    public void setgearstrat(int gear)
    {
        gearstrat = gear;
    }
}

// huge mess of a code, 0 planning teehee
