using System;
using Core;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Game
{
  public class ProductionBuilding : MonoBehaviour
  {
    [SerializeField] private GameResource _gameResource;
    [SerializeField] private Button _button;
    public GameResource GameResource
    {
      get => _gameResource;
      set => _gameResource = value;
    }
    public ProductionAnimation ProductionAnimation
    {
      get;
      set;
    }

    public void Initialize()
    {
      _button.onClick.AddListener(OnClick);
    }
    
    private bool _enabled = true;
    private bool _pressed = false;
    private bool _corutineended = false;
    private float _pressedtime = 0f;
    public ResourceBank ResourceBank { get; set; }
    public ResourceLevel ResourceLevel { get; set; }

    private void Update()
    {
      if (_corutineended && _pressed && (Time.time - _pressedtime < 0.1f))
      {
        OnClick();
        _corutineended = false;
      }
    }
    
    public void OnClick()
    {
      _pressedtime = Time.time;
      _pressed = true;
      if (!_enabled)
      {
        return;
      }
      float time = 2f / (ResourceLevel.GetLevel(_gameResource).Value + 1f) ;
      ProductionAnimation.StartProduction(time, OnProduction);
      _enabled = false;
      _pressed = false;
    }

    private void OnProduction()
    {
      _enabled = true;
      ResourceBank.ChangeResource(_gameResource, 1);
      _corutineended = true;
    }
  }
}