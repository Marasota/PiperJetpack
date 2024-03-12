using TMPro;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _flyingForce;
    [SerializeField] private TextMeshProUGUI _canvasCounter;
    [SerializeField] private SceneController _sceneController;

    private bool _isFlying = false;
    private int _cakesCounter = 0;
    private float _currentFlyingForce;



    void Start()
    {    
        _currentFlyingForce = _flyingForce;
        _cakesCounter = _sceneController.GetLoadSave().LoadCakes();
        UpdateCakesCounter();
       _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

/*
        if (Input.touchCount > 0)
        {
            _isFlying = true;
        }
        else
        {
            _isFlying = false;
        }*/


        if (Input.GetKey(KeyCode.Space))
        {
            _isFlying = true;
        }
        else
        {
            _isFlying = false;
        }

    }

    private void FixedUpdate()
    {
        if (_isFlying)
        {
            _rb.AddForce(Vector2.up * _currentFlyingForce);
        }
    }

    public float GetFlyingForce() { return _flyingForce; }

    public void SetFlyingForce(float newForce)
    {
        _currentFlyingForce = newForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cake")
        {
            _cakesCounter++;
            UpdateCakesCounter();
        }
          
        if (collision.tag == "Robo")
        {
            GetComponent<Animator>().SetTrigger("Death");
            Invoke("GameOver", 0.5f);
        }
    }

    public void UpdateCakesCounter()
    {
        _canvasCounter.text = _cakesCounter.ToString();
        _canvasCounter.color = _cakesCounter >= 5 ? Color.white : Color.gray;
    }

    public void GameOver()
    {
        _sceneController.Death(_cakesCounter);    
    }
}
