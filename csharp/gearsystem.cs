using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gearsystem : MonoBehaviour
{
    [SerializeField] private Main main;
    [SerializeField] private Button down,stay,up;
    [SerializeField] private GameObject self,quizui;
    private int currentgear;
    void OnEnable()
    {
        currentgear = main.getcurrentgear();
        switch (currentgear)
        {
            case 0:{
                    down.interactable = false;
                    stay.interactable = false;
                    up.interactable = true;
                }break;
            case 1:{ 
                    down.interactable = false;
                    stay.interactable = true;
                    up.interactable = true;
                }break;
            case 2:{
                    down.interactable = true;
                    stay.interactable = true;
                    up.interactable = true;
                }break;
            case 3:{
                    down.interactable = true;
                    stay.interactable = true;
                    up.interactable = true;
                }break;
            case 4:{
                    down.interactable = true;
                    stay.interactable = true;
                    up.interactable = true;
                }break;
            case 5:{
                    down.interactable = true;
                    stay.interactable = true;
                    up.interactable = true;
                }break;
            case 6:{
                    down.interactable = true;
                    stay.interactable = true;
                    up.interactable = true;
                }break;
            case 7:{
                    down.interactable = true;
                    stay.interactable = true;
                    up.interactable = false;
                }break;
        }// end of switch statement for interactable buttons
    }
    
    public void buttondown()
    {
        main.setgearstrat(-1);
        quizui.SetActive(true);
        self.SetActive(false);
    }

    public void buttonstay()
    {
        main.setgearstrat(0);
        quizui.SetActive(true);
        self.SetActive(false);
    }

    public void buttonup()
    {
        main.setgearstrat(1);
        quizui.SetActive(true);
        self.SetActive(false);
    }
}
