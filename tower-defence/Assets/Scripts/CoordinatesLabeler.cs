using UnityEngine;
using UnityEditor;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinatesLabeler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blovkedColor = Color.gray;

    private TMP_Text _label;
    private Vector2Int _coordinates;
    private WayPoint _wayPoint;

    private void Awake()
    {
        _wayPoint = GetComponentInParent<WayPoint>();
        _label = GetComponent<TMP_Text>();
        DisplayCoordinates();
    }

    private void Update()
    {
        ColorCoordinates();
        ToggleLabels();
        if (Application.isPlaying)
            return;
        UpdateObjectName();
    }
    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
            _label.enabled = !_label.enabled;
    }

    private void ColorCoordinates()
    {
        _label.color = _wayPoint.IsPlaycable ? defaultColor : blovkedColor;
    }

    private void UpdateObjectName()
    {
        transform.parent.name = _coordinates.ToString();
    }

    private void DisplayCoordinates()
    {
        var position = transform.parent.position;
        _coordinates.x = Mathf.RoundToInt(position.x / EditorSnapSettings.move.x);
        _coordinates.y = Mathf.RoundToInt(position.z / EditorSnapSettings.move.z);

        _label.text = $"{_coordinates.x};{_coordinates.y}";
    }
}
