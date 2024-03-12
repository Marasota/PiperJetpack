using TMPro;
using UnityEngine;


public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private TextMeshProUGUI _cakesCounterText;
    [SerializeField] private TextMeshProUGUI _canvasDistanceText;
    [SerializeField] private TextMeshProUGUI _postDistanceText;
    [SerializeField] private TextMeshProUGUI _record;

    private float _canvasDistance = 0;
    private float _sceneSpeed;
    private LoadSave _loadSave;

  /*  private void Awake()
    {
        Application.targetFrameRate = 120;
    }*/
    void Start()
    {
        _sceneSpeed = Mathf.Abs(GameObject.Find("SpeedSystem").GetComponent<SpeedSystem>().GetSpeed());

        _canvasDistanceText.text = "0";
        _loadSave = GetComponent<LoadSave>();
    }

   

    private void Update()
    {
        CalculateDistance();
    }
    private void FixedUpdate()
    {
       
    }

    public void CalculateDistance()
    {
        _canvasDistance += _sceneSpeed * Time.deltaTime;

        
        _canvasDistanceText.text = Mathf.Round(_canvasDistance).ToString();
    }

   

    public void PauseButtonPressed()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueButtonPressed()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public LoadSave GetLoadSave()
    {
        return _loadSave;
    }

    public void Death(int newCakesCount)
    {
        _loadSave.UpdateCakes(newCakesCount);
        if(Mathf.Round(_canvasDistance) > _loadSave.LoadRecordDistance())
        {
            _loadSave.UpdateRecordDistance((int)Mathf.Round(_canvasDistance));
            _record.text = "NEW RECORD!";
        }
        else
        {
            _record.text = $"Record: {_loadSave.LoadRecordDistance()}";
        }
        _deathPanel.SetActive(true);
        _cakesCounterText.text = newCakesCount.ToString();
        _postDistanceText.text = _canvasDistanceText.text;
        Time.timeScale = 0f;
    }
}
