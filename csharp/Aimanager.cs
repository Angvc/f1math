
using System;
using UnityEngine;


public class Aimanager : MonoBehaviour
{
    [SerializeField] private CPUcontroller[] CPUcomputer;
    [SerializeField] private Main player;
    // controlled from player, defaulted at 0;
    public int gamestate;
    /*  gamestate 0 = start line waiting
     *  gamestate 1 = start the race
     *  gamestate 2 = mathrandom to give variation on answering speed
     *  gamestate 3 = timerstart and implement answer when at the right timing
     *  gamestate 4 = player finished
     */

    /*timer
    private int carnum = 6;
    private float timeelapsed = 0;
    private float[] timevariety = new float[10];
    */
    private void Start()
    {
        //UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        gamestate = 0;
    }

    //in update
        /*
        switch (gamestate)
        {   case 1:
                if(growspeed < 100)
                {
                    growspeed += 0.5f;
                    for (int i = 0; i <= carnum; i++)
                    {
                        CPUcomputer[i].setspeed(growspeed);
                    }
                    return;
                }
                gamestate = 2;
            break;

            case 2:
                for (int i = 0; i <= carnum; i++)
                {
                    timevariety[i] = UnityEngine.Random.Range(1, 5)+5f;
                }
                timeelapsed = 0f;
                gamestate = 3;
            break;

            case 3:
                timeelapsed += Time.deltaTime;
                float timerounded = Mathf.Floor(timeelapsed);

                // once 10s has passed, check if current time is the time for cpu to answer;
                if (timerounded > 5f) 
                {
                    for (int i = 0; i <= carnum; i++) 
                    { 
                        if (timevariety[i].Equals(timerounded) && CPUcomputer[i].timeremaining.Equals(0)) 
                        {
                            CPUcomputer[i].Answer();
                        }
                    }
                }

                // normalize speed of cpus that has answered
                for (int i = 0; i <= carnum; i++) 
                {
                    if (!CPUcomputer[i].timeremaining.Equals(0)) 
                    {   int CPUtimerounded = Convert.ToInt16(CPUcomputer[i].timeremaining);
                        if (CPUcomputer[i].getspeed() > 100) { CPUcomputer[i].setspeed(100 - (2*CPUtimerounded)); }
                        else if (CPUcomputer[i].getspeed() < 100) { CPUcomputer[i].setspeed(100 + (2 * CPUtimerounded)); }
                        CPUcomputer[i].timeremaining -= Time.deltaTime;
                    }
                }

                if (timerounded.Equals(20)) 
                {   
                    gamestate = 2;
                    for (int i = 0; i <= carnum; i++)
                    {
                        CPUcomputer[i].timeremaining = 0f;
                    } 
                }

            break;
        }
        */

    public void setgamestate(int newgamestate)
    {
        gamestate = newgamestate;
    }
}