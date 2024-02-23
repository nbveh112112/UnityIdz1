using System;
using System.Collections;
using System.Linq;
using Core;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
  public class UpgradeBuilding : MonoBehaviour
  {
    [SerializeField] private GameResource _gameResource;
    [SerializeField] private Button _button;
    
    public ResourceBank ResourceBank { get; set; }
    public ResourceLevel ResourceLevel { get; set; }
    
    public GameResource GameResource
    {
      get => _gameResource;
      set => _gameResource = value;
    }
    
    public void Initialize()
    {
      foreach (var gr in Enum.GetValues(typeof(GameResource)).Cast<GameResource>())
      {
        if (gr != _gameResource)
        {
          ResourceBank.GetResource(gr).OnChange += CheckUpgrade;
        }
      }
    }

    private void CheckUpgrade(ObservableInt t)
    {
      int level = ResourceLevel.GetLevel(_gameResource).Value;
        foreach (var gr in Enum.GetValues(typeof(GameResource)).Cast<GameResource>())
        {
          if (gr == _gameResource) continue;
          if (ResourceBank.GetResource(gr).Value >= level) continue;
          _button.gameObject.SetActive(false);
          return;
        }
        _button.gameObject.SetActive(true);
    }

    public void OnClick()
    {
      foreach (var gr in Enum.GetValues(typeof(GameResource)).Cast<GameResource>())
      {
        if (gr != _gameResource)
        {
          ResourceBank.ChangeResource(gr, -ResourceLevel.GetLevel(_gameResource).Value);
        }
      }

      ResourceLevel.Upgrade(_gameResource);
      CheckUpgrade(new ObservableInt());
    }
  }
}