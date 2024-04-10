
public class TrailMaking
{
    public string date;
    public string time;
    public int level;
    public float scorePercent;
    public int accuracy;
    public float overallTime;
    public int numberOfMistakes;

    public TrailMaking(string date, string time, int level, float scorePercent,
        int accuracy, float overallTime, int numberOfMistakes)
    {
        this.date = date;
        this.time = time;
        this.level = level;
        this.scorePercent = scorePercent;
        this.accuracy = accuracy;
        this.overallTime = overallTime;
        this.numberOfMistakes = numberOfMistakes;
    }
}
