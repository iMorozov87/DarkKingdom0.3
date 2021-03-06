using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private List<Item> _treasures;
    [SerializeField] private int _chance = 30;
    [SerializeField] private Coints _moneyTemplate;
    [SerializeField] private uint _moneyNumber;
    [SerializeField] private ItemInstanceCreator _itemCreator;

    private List<QuestItem> _questItems = new List<QuestItem>();
    private bool _isOpen = false;

    public bool IsOpen => _isOpen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<SwordHitter>(out SwordHitter swordHitter))
        {
            if (swordHitter.AttackIsActive)
            {
                _isOpen = true;
                CreateContent();
                Destroy(gameObject);
            }
        }
    }

    public void AddQuestItem(QuestItem item)
    {
        _questItems.Add(item);
    }

    private void CreateContent()
    {
        foreach (var item in _treasures)
            TryCreateItemInstanse(item, _chance);

        foreach (var questItem in _questItems)
            _itemCreator.CreateItemInstanse(questItem);

        Coints money = Instantiate(_moneyTemplate, transform.position, Quaternion.identity);
        money.SetNumber(_moneyNumber);
    }

    private void TryCreateItemInstanse(Item item, int chance)
    {
        int maxRandomValue = 100;
        int currentRandomValue = Random.Range(0, maxRandomValue);

        if (chance <= currentRandomValue)
            _itemCreator.CreateItemInstanse(item);
    }

    public void AddItem(Item item)
    {
        _treasures.Add(item);
    }
}