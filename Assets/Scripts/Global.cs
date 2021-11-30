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
    public static int score = 0;                //puntuació inicial sempre 0
    public static int maxScore = 0;             //puntuació final acabar nivell 
    public static int level = 1;                //Nivell inicial
    public static int maxLevel = 0;
    public static int maxLevelPublished = 2;    //Aqui he fet canvi
    public static int maxTime = 0;              //temps inicial sempre 0
    public static int maxTotalTime = 0;         // temps final acabar nivell
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
}
