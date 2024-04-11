

public class DualGame
{
    public bool islvlOnePassed;
    public bool islvlTwoPassed;
    public bool islvlThreePassed;
    public float highestAccuracy;
    public float lastAccuracy;
    public float highestScore;
    public float lastScore;
    public float highestGoRT;
    public float lastGoRT;
    public float highestNoRT;
    public float lastNoRT;

    public DualGame(bool islvlOnePassed, bool islvlTwoPassed, bool islvlThreePassed,
        float highestAccuracy, float lastAccuracy, float highestScore, float lastScore, 
        float highestGoRT, float lastGoRT, float highestNoRT, float lastNoRT) 
    {
        this.islvlOnePassed = islvlOnePassed;
        this.islvlTwoPassed = islvlTwoPassed;
        this.islvlThreePassed = islvlThreePassed;;
        this.highestAccuracy = highestAccuracy;
        this.lastAccuracy = lastAccuracy;
        this.highestScore = highestScore;
        this.lastScore = lastScore;
        this.highestGoRT = highestGoRT;
        this.lastGoRT = lastGoRT;
        this.highestNoRT = highestNoRT;
        this.lastNoRT = lastNoRT;

    }
}

public class MazeGame
{
    public bool islvlOnePassed;
    public bool islvlTwoPassed;

    public MazeGame(bool islvlOnePassed, bool islvlTwoPassed)
    {
        this.islvlOnePassed = islvlOnePassed;
        this.islvlTwoPassed = islvlTwoPassed;
    }
}

public class TrailGame
{
    public bool islvlOnePassed;
    public bool islvlTwoPassed;
    public bool islvlThreePassed;
    public float highestAccuracy;
    public float lastAccuracy;
    public float highestScore;
    public float lastScore;

    public TrailGame(bool islvlOnePassed, bool islvlTwoPassed, bool islvlThreePassed,
        float highestAccuracy,float lastAccuracy, float highestScore, float lastScore)
    {
        this.islvlOnePassed = islvlOnePassed;
        this.islvlTwoPassed = islvlTwoPassed;
        this.islvlThreePassed = islvlThreePassed;
        this.highestAccuracy = highestAccuracy;
        this.lastAccuracy = lastAccuracy;
        this.highestScore = highestScore;
        this.lastScore = lastScore;
    }
}

public class FocusGame
{
    public bool islvlOnePassed;
    public bool islvlTwoPassed;
    public float highestAccuracy;
    public float lastAccuracy;
    public float highestScore;
    public float lastScore;
    public float highestGoRT;
    public float lastGoRT;
    public float highestNoRT;
    public float lastNoRT;

    public FocusGame(bool islvlOnePassed, bool islvlTwoPassed,
        float highestAccuracy, float lastAccuracy, float highestScore, float lastScore, float highestGoRT,
        float lastGoRT, float highestNoRT, float lastNoRT)
    {
        this.islvlOnePassed = islvlOnePassed;
        this.islvlTwoPassed = islvlTwoPassed;
        this.highestAccuracy = highestAccuracy;
        this.lastAccuracy = lastAccuracy;
        this.highestScore = highestScore;
        this.lastScore = lastScore;
        this.highestGoRT = highestGoRT;
        this.lastGoRT = lastGoRT;
        this.highestNoRT = highestNoRT;
        this.lastNoRT = lastNoRT;
    }
}

public class WhackGame
{
    public bool islvlOnePassed;
    public bool islvlTwoPassed;
    public float highestAccuracy;
    public float lastAccuracy;
    public float highestScore;
    public float lastScore;
    public float highestGoRT;
    public float lastGoRT;
    public float highestNoRT;
    public float lastNoRT;

    public WhackGame(bool islvlOnePassed, bool islvlTwoPassed, float highestAccuracy, float lastAccuracy, float highestScore,
        float lastScore, float highestGoRT, float lastGoRT, float highestNoRT, float lastNoRT)
    {
        this.islvlOnePassed = islvlOnePassed;
        this.islvlTwoPassed = islvlTwoPassed;
        this.highestAccuracy = highestAccuracy;
        this.lastAccuracy = lastAccuracy;
        this.highestScore = highestScore;
        this.lastScore = lastScore;
        this.highestGoRT = highestGoRT;
        this.lastGoRT = lastGoRT;
        this.highestNoRT = highestNoRT;
        this.lastNoRT = lastNoRT;
    }
}