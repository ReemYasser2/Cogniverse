
public class Maze 
{
    public string date;
    public string time;
    public int level;
    public float overallTime;
    public int numberOfHits;

    public Maze (string date, string time, int level, float overallTime, int numberOfHits)
    {
        this.date = date;
        this.time = time;
        this.level = level;
        this.overallTime = overallTime;
        this.numberOfHits = numberOfHits;
    }
}
