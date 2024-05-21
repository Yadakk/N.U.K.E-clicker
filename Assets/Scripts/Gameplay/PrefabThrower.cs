using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabThrower : MonoBehaviour
{
    [SerializeField] private Object _prefab;
    [SerializeField] private Transform _putObjectsInto;
    [SerializeField] private Vector2 _minForce;
    [SerializeField] private Vector2 _maxForce;
    [SerializeField] private float _minTorque;
    [SerializeField] private float _maxTorque;
    [SerializeField] private float _fadeAfterSeconds;
    [SerializeField] private float _fadeSpeed = 1f;
    private Canvas _canvas;
    private CanvasScaler _canvasScaler;

    private void Start()
    {
        _canvas = ActiveCanvas.Canvas;
    }

    public void Throw()
    {
        if (!enabled) return;
        var initialRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        var gameObject = Instantiate(_prefab, transform.position, initialRotation, _putObjectsInto) as GameObject;
        var forceX = Random.Range(_minForce.x, _maxForce.x);
        var forceY = Random.Range(_minForce.y, _maxForce.y);
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        float canvasScale = GetCanvasScale(_canvas);
        rb.gravityScale *= canvasScale;
        rb.AddForce(new Vector2(forceX, forceY) * canvasScale, ForceMode2D.Impulse);
        rb.AddTorque(RandomWithInversion(_minTorque, _maxTorque));
        StartCoroutine(RemoveWithFadeAfterSeconds(_fadeAfterSeconds, gameObject.GetComponent<Image>(), gameObject));
    }

    private float GetCanvasScale(Canvas canvas)
    {
        return Screen.width / canvas.GetComponent<CanvasScaler>().referenceResolution.x;
    }

    private float RandomWithInversion(float min, float max)
    {
        min = Mathf.Abs(min);
        max = Mathf.Abs(max);
        float result = Random.Range(min, max);
        if (Random.Range(0, 2) == 1)
            result *= -1;
        return result;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _putObjectsInto.childCount; i++)
        {
            Destroy(_putObjectsInto.GetChild(i).gameObject);
        }
    }

    private IEnumerator RemoveWithFadeAfterSeconds(float seconds, Image image, GameObject gameObject)
    {
        yield return new WaitForSeconds(seconds);
        while (image.color.a > 0)
        {
            if (!enabled) yield break;
            var newColor = image.color;
            newColor.a -= Time.deltaTime * _fadeSpeed;
            image.color = newColor;
            yield return null;
        }
        Destroy(gameObject);
    }
}
