using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using UnityEngine;

public class EndresultManager : MonoBehaviour
{

    [SerializeField] private CPUcontroller[] Computer;
    [SerializeField] private quizManager Player;
    [SerializeField] private resultentry[] entry; 


    void Start()
    {
        int player;
        int[] cpu = new int[7];

        // get score for player
        player = Player.getcorrects() - Player.getincorrects();
        // get score for cpus
        for (int i = 0; i < cpu.Length; i++)
        {
            cpu[i] = Computer[i].getcorrects() - Computer[i].getincorrects();
        }

        //get highest score, add to entry, then set it's score to 0;
        for (int i = 0;i<entry.Length; i++) // repeat to entry every result entry
        {
            // get highest cpu score.
            int highestcpuscore = cpu.Max();
            // check if player is higher, if yes then insert player's score then set to 0
            UnityEngine.Debug.Log(" new value just drop");
            for (int j = 0; j < 7; j++)
            {
                UnityEngine.Debug.Log(cpu[j] + " of cpu "+j);
            }
            if (player >= highestcpuscore) 
            { 
                entry[i].setname("Player");  
                entry[i].setcor(Player.getcorrects().ToString());
                entry[i].setincor(Player.getincorrects().ToString());
                player = -100; // in case theres cpu that has negative score
            }
            else // if a cpu have higher score then this part runs;
            {
                int thiscpu = 0;
                // check which cpu has highest score
                for (int j = 0; j< 7; j++)
                {   // code only runs if cpu has the highest score
                    if (cpu[j].Equals( highestcpuscore)) 
                    {
                        thiscpu = j;
                    }
                }
                entry[i].setname("Computer" + thiscpu);
                entry[i].setcor(Computer[thiscpu].getcorrects().ToString());
                entry[i].setincor(Computer[thiscpu].getincorrects().ToString());
                cpu[thiscpu] = -100;// in case theres cpu that has negative score
            }

        }
    }

}
