
public class TrailMaking
{
    public string date;
    public string time;
    public int level;
    public float scorePercent;
    public float accuracy;
    public float overallTime;
    public int numberOfMistakes;

    public TrailMaking(string date, string time, int level, float scorePercent,
        float accuracy, float overallTime, int numberOfMistakes)
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
