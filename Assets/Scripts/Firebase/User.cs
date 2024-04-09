

public class User
{
    //public int groupNumber;
    public string firstName;
    public string lastName;
    public string email;
    public string password;
    public int age;
    public string femalegender;
    public string malegender;
    public string isYesDiagnosis;
    public string isNoDiagnosis;
    public string diagnosis;
    public bool iscontrolGroup;
    public bool ispositiveGroup;
    public bool isnegativeGroup;

    public User(string firstname, string lastname, string email, string password, int age, string femalegender, 
        string malegender, string isyesdiagnosis, string isnodiagnosis, string diagnosis,
        bool iscontrolgroup, bool ispositivegroup, bool isnegativegroup)
    {
        //this.groupNumber = groupnumber;
        this.firstName = firstname;
        this.lastName = lastname;
        this.email = email;
        this.password = password;
        this.age = age;
        this.femalegender = femalegender;
        this.malegender = malegender;
        this.isYesDiagnosis = isyesdiagnosis;
        this.isNoDiagnosis = isnodiagnosis;
        this.diagnosis = diagnosis;
        this.iscontrolGroup = iscontrolgroup;
        this.ispositiveGroup = ispositivegroup;
        this.isnegativeGroup = isnegativegroup;
    }
}
