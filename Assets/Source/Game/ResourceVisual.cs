using Core;
using TMPro;
using UnityEngine;

namespace Game
{
  public class ResourceVisual : MonoBehaviour
  {
    [SerializeField] private GameResource _gameResource;
    [SerializeField] private TextMeshProUGUI _valueText;
    private ResourceBank _resourceBank;
    public ResourceBank ResourceBank
    {
      get => _resourceBank;
      set
      {
        _resourceBank = value;
        _resourceBank.GetResource(_gameResource).OnChange += OnChange;
      }
    }
    void OnChange(ObservableInt o)
    {
      _valueText.text = $"{o.Value}";
    }
  }
}