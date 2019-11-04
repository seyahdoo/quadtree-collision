using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public InputField shapeCountField;
    public Dropdown detectionMethodDropdown;
    public Toggle drawShapesEnabledToggle;
    public Toggle drawTreeEnabledToggle;
    public Toggle removeDeadEnabledToggle;
    public Toggle removeExcessEnabledToggle;
    public Text frameTime;

    private void Update()
    {
        frameTime.text = Time.deltaTime.ToString();
    }

    public void OnShapeCountChanged()
    {
        Settings.shapeCount = int.Parse(shapeCountField.text);
    }

    public void OnDetectionMethodChanged()
    {
        Settings.mode = (Settings.CollisionDetectionMode)detectionMethodDropdown.value;
    }

    public void OnDrawShapesEnabledChanged()
    {
        Settings.debugDrawShapes = drawShapesEnabledToggle.isOn;
    }

    public void OnDrawTreeEnabledChanged()
    {
        Settings.debugDrawTree = drawTreeEnabledToggle.isOn;
    }

    public void OnRemoveDeadEnabledChanged()
    {
        Settings.removeDead = removeDeadEnabledToggle.isOn;
    }
    public void OnRemoveExcessEnabledChanged()
    {
        Settings.removeExcess = removeExcessEnabledToggle.isOn;
    }

}
