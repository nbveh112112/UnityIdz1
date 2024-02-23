using System;
using System.Collections;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
  public class ProductionAnimation : MonoBehaviour
  {
    [SerializeField] private GameResource _gameResource;
    [SerializeField] private Slider _slider;

    public GameResource GameResource
    {
      get => _gameResource;
      set => _gameResource = value;
    }

    public void Initiate()
    {
      _slider.image.enabled = false;
    }
    public void StartProduction(float time, Action callback)
    {
      StartCoroutine(Production(time, callback));
    }

    IEnumerator Production(float time, Action callback)
    {
      _slider.image.enabled = true;
      float i = 0f;
      while(i < 1f)
      {
        i += Time.deltaTime/time;
        _slider.value = i;
        yield return null;
      }
      _slider.value = 0f;
      callback.Invoke();
      _slider.image.enabled = false;
    }
  }
}
