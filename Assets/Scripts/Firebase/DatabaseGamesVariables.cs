using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseGamesVariables : MonoBehaviour
{
    public static string userID;

    public static string firstName;
    public static string lastName;
    public static string email;
    public static string password;
    public static int age;
    public static string femalegender;
    public static string malegender;
    public static string isYesDiagnosis;
    public static string isNoDiagnosis;
    public static string diagnosis;
    public static bool iscontrolGroup;
    public static bool ispositiveGroup;
    public static bool isnegativeGroup;

    public static string dualname = "dual";
    public static string mazename = "maze";
    public static string trailname = "trail";
    public static string focusname = "focus";
    public static string whackname = "whack";

    // dual
    public static float highestAccuracyDual;
    public static float lastAccuracyDual;
    public static float highestScoreDual;
    public static float lastScoreDual;
    public static float highestGoRTDual;
    public static float lastGoRTDual;
    public static float highestNoRTDual;
    public static float lastNoRTDual;
    public static bool islvlOnePasseddual;
    public static bool islvlTwoPasseddual;
    public static bool islvlThreePasseddual;

    // trail
    public static float highestAccuracyTrail;
    public static float lastAccuracyTrail;
    public static float highestScoreTrail;
    public static float lastScoreTrail;
    public static bool islvlOnePassedtrail;
    public static bool islvlTwoPassedtrail;
    public static bool islvlThreePassedtrail;

    // focus
    public static float highestAccuracyFF;
    public static float lastAccuracyFF;
    public static float highestScoreFF;
    public static float lastScoreFF;
    public static float highestGoRTFF;
    public static float lastGoRTFF;
    public static float highestNoRTFF;
    public static float lastNoRTFF;

    // whack
    public static float highestAccuracyWhack;
    public static float lastAccuracyWhack;
    public static float highestScoreWhack;
    public static float lastScoreWhack;
    public static float highestGoRTWhack;
    public static float lastGoRTWhack;
    public static float highestNoRTWhack;
    public static float lastNoRTWhack;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
