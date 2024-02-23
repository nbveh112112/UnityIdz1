using Core;
using TMPro;
using UnityEngine;

namespace Game
{
  public class UpgradeVisual : MonoBehaviour
  {
    [SerializeField] private GameResource _gameResource;
    [SerializeField] private TextMeshProUGUI _valueText;
    private ResourceLevel _resourceLevel;
    
    public ResourceLevel ResourceLevel
    {
      get => _resourceLevel;
      set
      {
        _resourceLevel = value;
        _resourceLevel.GetLevel(_gameResource).OnChange += OnChange;
      }
    }
    void OnChange(ObservableInt o)
    {
      _valueText.text = $"{o.Value}";
    }
  }
}