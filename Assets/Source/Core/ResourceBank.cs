using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
  public class ResourceBank
  {
    private Dictionary<GameResource, ObservableInt> _resourceDict = new();

    public ResourceBank()
    {
      foreach (GameResource gr in Enum.GetValues(typeof(GameResource)).Cast<GameResource>())
      {
        _resourceDict[gr] = new ObservableInt(0);
      }
    }
    public void ChangeResource(GameResource gr, int v)
    {
      _resourceDict[gr].Value += v;
    }

    public ObservableInt GetResource(GameResource r)
    {
      return _resourceDict[r];
    }
  }
}