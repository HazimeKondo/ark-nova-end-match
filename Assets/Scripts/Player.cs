using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Serializable]
    public struct TrailData
    {
        public TMP_InputField Input;
        public Button AddBtn;
        public Button SubtractBtn;
        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                Input.text = value.ToString();
            }
        }
    }
    
    [SerializeField] private TrailData Conservation;
    [SerializeField] private TrailData Attractivity;

    [SerializeField] private TMP_Text _points;
    
    private Animator _anim;

    private bool _enabled = true;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void UpdateConservationValue(string value)
    {
        if (Int32.TryParse(value, out int parsedValue))
            Conservation.Value = Mathf.Clamp(parsedValue, 0, Trails.MaxConservation);
        else
            Conservation.Value = Conservation.Value;
    }

    public void AddConservationValue() => Conservation.Value = Mathf.Min(Trails.MaxConservation, ++Conservation.Value);
    public void SubtractConservationValue() => Conservation.Value = Mathf.Max(0, --Conservation.Value);
    
    public void UpdateAttractivityValue(string value)
    {
        if (Int32.TryParse(value, out int parsedValue))
            Attractivity.Value = Mathf.Clamp(parsedValue, 0, Trails.MaxAttractivity);
        else
            Attractivity.Value = Attractivity.Value;
    }

    public void AddAttractivityValue() => Attractivity.Value = Mathf.Min(Trails.MaxAttractivity, ++Attractivity.Value);
    public void SubtractAttractivityValue() => Attractivity.Value = Mathf.Max(0, --Attractivity.Value);
    
    private void UpdateResult() => _points.text = Trails.Result(Conservation.Value, Attractivity.Value).ToString();

    public void SetResult(bool value)
    {
        UpdateResult();
        _anim.SetBool("Result",value);
    }

    public void ShowHide()
    {
        _enabled = !_enabled;
        _anim.SetBool("Show",_enabled);
    }
}