using System;
using UnityEditor.Hardware;

namespace Core
{
  public class ObservableInt
  {
    public ObservableInt(){}
    public ObservableInt(int t)
    {
      _value = t;
    }
    public event Action<ObservableInt> OnChange;

    private int _value;
    
    public int Value
    {
      get => _value;
      set
      {
        _value = value;
        OnChange?.Invoke(this);
      }
    }
    
  }
}