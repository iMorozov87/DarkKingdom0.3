using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    [SerializeField] private float _minRotation = -20.0F;
    [SerializeField] private float _maxRotation = 20.0F;
    [SerializeField] private float _timeDestroy = 10.0f;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(_minRotation, _maxRotation));
        Destroy(gameObject, _timeDestroy);
        StartCoroutine(WaitDestruction(_timeDestroy));
    }

    public void Init(Vector3 localScale)
    {
        transform.localScale = localScale;
    }

    private IEnumerator WaitDestruction(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
