// CubeDropper.cs
using UnityEngine;

public enum OperationType
{
    None,
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public class CubeDropper : MonoBehaviour
{
    private float fallSpeed = 80f;
    private float maxFallSpeed = 150f;
    private float currentFallSpeed;
    private bool canIncreaseSpeed = false;

    private OperationType operationType = OperationType.None;

    public OperationType OperationType // プロパティを追加
    {
        get { return operationType; }
        set { operationType = value; }
    }

    private GameManager gameManager;

    public float FallSpeed
    {
        get { return currentFallSpeed; }
        set { currentFallSpeed = value; }
    }

    void Start()
    {
        currentFallSpeed = fallSpeed;
        Invoke("EnableSpeedIncrease", 5f);

        gameManager = FindObjectOfType<GameManager>();

        SetRandomOperationType();
    }

    void EnableSpeedIncrease()
    {
        canIncreaseSpeed = true;
    }

    void Update()
    {
        transform.Translate(Vector3.down * currentFallSpeed * Time.deltaTime);

        if (canIncreaseSpeed)
        {
            IncreaseSpeedByScore();
            currentFallSpeed = Mathf.Min(currentFallSpeed + Time.deltaTime, maxFallSpeed);
        }
    }

    void IncreaseSpeedByScore()
    {
        if (gameManager != null)
        {
            int score = gameManager.GetScore();
            float speedIncreaseFactor = 0.1f;
            currentFallSpeed += score * speedIncreaseFactor;
        }
    }

    void SetRandomOperationType()
    {
        if (operationType == OperationType.None)
        {
            OperationType[] operationTypes = (OperationType[])System.Enum.GetValues(typeof(OperationType));
            operationType = operationTypes[Random.Range(1, operationTypes.Length)];
        }
    }
}
