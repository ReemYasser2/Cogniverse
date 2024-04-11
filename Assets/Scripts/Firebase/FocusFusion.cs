public class FocusFusion 
{
    public string date;
    public string time;
    public int level;
    public float scorePercent;
    public float accuracy;
    public float overallTime;
    public float goResponseTime;
    public float noGoResponseTime;

    public FocusFusion(string date, string time, int level, float scorePercent,
        float accuracy, float overallTime, float goResponseTime, float noGoResponseTime)
    {
        this.date = date;
        this.time = time;
        this.level = level;
        this.scorePercent = scorePercent;
        this.accuracy = accuracy;
        this.overallTime = overallTime;
        this.goResponseTime = goResponseTime;
        this.noGoResponseTime = noGoResponseTime;
    }
}
