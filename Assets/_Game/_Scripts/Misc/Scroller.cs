using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour {
    [SerializeField] private Vector2 _dir = new(0, 0.01f);
    private RawImage _img;

    private void Awake() {
        _img = GetComponent<RawImage>();
    }

    private void Update() {
        _img.uvRect = new Rect(_img.uvRect.position + _dir * Time.fixedDeltaTime, _img.uvRect.size);
    }
}