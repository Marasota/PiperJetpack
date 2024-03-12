using UnityEngine;

public class LoadSave : MonoBehaviour
{
    private void Start()
    {
       
    }

    public void UpdateCakes(int newCakesCount)
    {
        PlayerPrefs.SetInt("CakesCount", newCakesCount);
        PlayerPrefs.Save();  
    }

    public void UpdateRecordDistance(int newRecordDistance)
    {
        PlayerPrefs.SetInt("RecordDistance", newRecordDistance);
        PlayerPrefs.Save();
    }


    public int LoadCakes()
    {
        if (PlayerPrefs.HasKey("CakesCount"))
        {
           return PlayerPrefs.GetInt("CakesCount");
        }
        else
        {
            PlayerPrefs.SetInt("CakesCount", 0);
            return 0;
        }
    }

    public int LoadRecordDistance()
    {
        if (PlayerPrefs.HasKey("RecordDistance"))
        {
            return PlayerPrefs.GetInt("RecordDistance");
        }
        else
        {
            PlayerPrefs.SetInt("RecordDistance", 0);
            return 0;
        }
    }
}
