public class WhackAmole 
{
    public string date;
    public string time;
    public int level;
    public float scorePercent;
    public int accuracy;
    public float overallTime;
    public float goResponseTime;
    public float noGoResponseTime;

    public WhackAmole(string date, string time, int level, float scorePercent,
        int accuracy, float overallTime, float goResponseTime, float noGoResponseTime)
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
