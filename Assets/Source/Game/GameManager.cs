using System.Collections.Generic;
using Core;
using UnityEngine;


namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        private ResourceBank _resourceBank;
        private ResourceLevel _resourceLevel;
        
            // Start is called before the first frame update

        private void Awake()
        {
            _resourceBank = new ResourceBank();
            _resourceLevel = new ResourceLevel();
            CreateDisplays();
            CreateProductions();
            CreateUpgrades();
            _resourceBank.ChangeResource(GameResource.Food, 5);
            _resourceBank.ChangeResource(GameResource.Humans, 4);
            _resourceBank.ChangeResource(GameResource.Wood, 3);
            _resourceBank.ChangeResource(GameResource.Stone, 2);
            _resourceBank.ChangeResource(GameResource.Gold, 1);
            _resourceLevel.Upgrade(GameResource.Gold);
            _resourceLevel.Upgrade(GameResource.Food);
            _resourceLevel.Upgrade(GameResource.Humans);
            _resourceLevel.Upgrade(GameResource.Wood);
            _resourceLevel.Upgrade(GameResource.Stone);
        }
        

        void CreateDisplays()
        {
            foreach (var tmp in _canvas.GetComponentsInChildren<ResourceVisual>())
            {
                tmp.ResourceBank = _resourceBank;
            }
            foreach (var tmp in _canvas.GetComponentsInChildren<UpgradeVisual>())
            {
                tmp.ResourceLevel = _resourceLevel;
            }
        }

        void CreateProductions()
        {
            Dictionary<GameResource, ProductionAnimation> animations = new();
            foreach (var tmp in _canvas.GetComponentsInChildren<ProductionAnimation>())
            {
                animations[tmp.GameResource] = tmp;
                tmp.Initiate();
            }
            foreach (var tmp in _canvas.GetComponentsInChildren<ProductionBuilding>())
            {
                tmp.ResourceBank = _resourceBank;
                tmp.ResourceLevel = _resourceLevel;
                tmp.ProductionAnimation = animations[tmp.GameResource];
                tmp.Initialize();
            }
        }

        void CreateUpgrades()
        {
            foreach (var tmp in _canvas.GetComponentsInChildren<UpgradeBuilding>())
            {
                tmp.ResourceBank = _resourceBank;
                tmp.ResourceLevel = _resourceLevel;
                tmp.Initialize();
            }
        }
    }
}
