using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
  public class ResourceLevel
  {
    private Dictionary<GameResource, ObservableInt> _levelDict = new();
    
    public ResourceLevel()
    {
      foreach (GameResource gr in Enum.GetValues(typeof(GameResource)).Cast<GameResource>())
      {
        _levelDict[gr] = new ObservableInt(0);
      }
    }

    public void Upgrade(GameResource gr)
    {
      _levelDict[gr].Value++;
    }

    public ObservableInt GetLevel(GameResource gr)
    {
      return _levelDict[gr];
    }
  }
}