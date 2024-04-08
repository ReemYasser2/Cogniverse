using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrailReinforcement : MonoBehaviour
{
    public TMP_Text reinforcmentText;

    // Update is called once per frame
    void Update()
    {
        reinforcmentText.text = ReinforcementManagement.reinforcementText;

    }


}
