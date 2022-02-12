using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    //General
    public static bool canAudioPlay = true;
    public static bool canSFXPlay = true;
    public static bool isPlayingMusic;

    //Game
    public static int score = 0;
    public static int maxScore = 0;
    public static int level = 1;
    public static int maxLevel = 0;
    public static int maxLevelPublished = 10;
    public static int maxTime;
    public static int maxTotalTime = 0;
    public static List<int> requestBox = new List<int>();
    public static int machine2BoxTime = 0;
    public static int machine2accumulatedBoxesLimit;
    public static int machine1BoxTime = 0;
    public static int machine1accumulatedBoxesLimit;
    public static int machine1BoxFirstTime;
    public static int machine3BoxTime = 0;
    public static int machine3accumulatedBoxesLimit;
    public static int machine1Score;
    public static int machine2Score;
    public static int machine3Score;
    public static bool meteorites = true;
    public static float initialTime;
    public static float finalTime;



    public static int priceSpeedBoost = 450 ;
    public static int priceStopMachineBoost = 600 ;
    public static int priceClearMeteoBoost = 1000 ;
    public static int priceCapsuleBoost = 1250 ;
    public static int priceX2CoinsBoost = 1000 ;
    public static int priceMaxBoxsBoost = 1500 ;


}
