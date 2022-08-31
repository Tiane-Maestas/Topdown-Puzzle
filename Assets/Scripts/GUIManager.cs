using UnityEngine;
using TMPro;
using StoneTypes;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public PlayerStateController player;
    public TMP_Text coinText;
    public Image currentStone;
    public Image nextStone;
    public Image prevStone;
    private int _currentStoneIndex = 0;
    private Sprite[] _stoneImageMap = new Sprite[8];
    private List<StoneType> _allStones = new List<StoneType>();
    private void Awake()
    {
        foreach (StoneType stone in Enum.GetValues(typeof(StoneType)))
        {
            _allStones.Add(stone);
        }
        // Load all the images
        _stoneImageMap[0] = (Sprite)Resources.Load("Stones/Normal-stone", typeof(Sprite));
        _stoneImageMap[1] = (Sprite)Resources.Load("Stones/Fire-Stone", typeof(Sprite));
        _stoneImageMap[2] = (Sprite)Resources.Load("Stones/Explosion-Stone", typeof(Sprite));
        _stoneImageMap[3] = (Sprite)Resources.Load("Stones/Bounce-Stone", typeof(Sprite));
        _stoneImageMap[4] = (Sprite)Resources.Load("Stones/Teleport-Stone", typeof(Sprite));
        _stoneImageMap[5] = (Sprite)Resources.Load("Stones/Mind-Control-Stone", typeof(Sprite));
        _stoneImageMap[6] = (Sprite)Resources.Load("Stones/Joker-Stone", typeof(Sprite));
    }
    private void Update()
    {
        coinText.text = "" + player.totalCoins;

        // Handle Change of stone type.
        if (Input.GetKeyUp(KeyCode.E))
        {
            _currentStoneIndex = (_currentStoneIndex + 1) >= (_allStones.Count) ? 0 : _currentStoneIndex + 1;
            player.currentStoneType = _allStones[_currentStoneIndex];
            SetStoneImages();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            _currentStoneIndex = (_currentStoneIndex - 1) < (0) ? _allStones.Count - 1 : _currentStoneIndex - 1;
            player.currentStoneType = _allStones[_currentStoneIndex];
            SetStoneImages();
        }
    }

    private void SetStoneImages()
    {
        int nextStoneIndex = (_currentStoneIndex + 1) >= (_allStones.Count) ? 0 : _currentStoneIndex + 1;
        int prevStoneIndex = (_currentStoneIndex - 1) < (0) ? _allStones.Count - 1 : _currentStoneIndex - 1;
        currentStone.sprite = _stoneImageMap[_currentStoneIndex];
        nextStone.sprite = _stoneImageMap[nextStoneIndex];
        prevStone.sprite = _stoneImageMap[prevStoneIndex];
        Debug.Log(prevStoneIndex);
    }
}