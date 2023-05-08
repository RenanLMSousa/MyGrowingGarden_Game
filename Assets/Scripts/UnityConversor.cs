using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityConversor
{
    public static string secToDHMS(float timeInSecs) {
        if(timeInSecs == 0) { return "Grown!"; }

        float remaingTime = timeInSecs;
        int days = (int)(remaingTime / 86400);
        remaingTime = remaingTime % 86400;

        int hours = (int)(remaingTime / 3600);
        remaingTime = remaingTime % 3600;

        int minutes = (int)(remaingTime / 60);
        remaingTime = remaingTime % 60;

        int seconds = (int)remaingTime;
        string DHMSFormatString = "";

        if (days > 0) DHMSFormatString += days.ToString() + "D";
        if (hours > 0) DHMSFormatString += hours.ToString() + "H";
        if (minutes > 0) DHMSFormatString += minutes.ToString() + "m";
        if (seconds > 0) DHMSFormatString += seconds.ToString() + "s";



        return DHMSFormatString;


    }

    public static string moneyToK(float initialValue)
    {  
        int orderOfMagnitude = 0;
        float currentValue = initialValue;
        while (currentValue / 1000 >=1)
        {
            currentValue /= 1000;
            orderOfMagnitude++;

        }


        string complete = "";
        switch (orderOfMagnitude)
        {
            case 0:
                return initialValue.ToString();
                
            case 1:
                complete = "K";
                break;
            case 2:
                complete = "M";
                break;
            case 3:
                complete = "B";
                break;
            case 4:
                complete = "T";
                break;
            case 5:
                complete = "Qa";
                break;
            case 6:
                complete = "Qi";
                break;
            default:
                complete = (char)(orderOfMagnitude - 6 +'a')+"";
                break;
                


        }
        return currentValue.ToString("0.##") + complete;
    }
}
