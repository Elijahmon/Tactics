using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Character_Information;

public class CharacterUIController : UIController {


    #region UI Fields
    [SerializeField]
    private Image _portrait;
    [SerializeField]
    private Text _name;
    [SerializeField]
    private Text _class;
    [SerializeField]
    private List<Text> _buffList = new List<Text>();
    [SerializeField]
    private Text _currentHP;
    [SerializeField]
    private Text _maxHP;
    [SerializeField]
    private Text _currentSP;
    [SerializeField]
    private Text _maxSP;
    [SerializeField]
    private Text _str;
    [SerializeField]
    private Text _tgh;
    [SerializeField]
    private Text _acc;
    [SerializeField]
    private Text _wis;
    [SerializeField]
    private Text _res;
    [SerializeField]
    private Text _lck;
    #endregion

    private

    // Use this for initialization
    void Awake()
    {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected override bool Initialize()
    {
        bool ret = base.Initialize();
        return ret;
    }

    public void UpdateforCharacter(CharacterSheet sheet)
    {
        _portrait.sprite = sheet.portrait;
        _name.text = sheet.characterName;
        _class.text = sheet.className;
        _currentHP.text = sheet.healthPoints.getCurrent().ToString();
        _maxHP.text = sheet.healthPoints.getMax().ToString();
        _currentSP.text = sheet.skillPoints.getCurrent().ToString();
        _maxSP.text = sheet.skillPoints.getMax().ToString();
        _str.text = sheet.strength.getStat().ToString();
        _tgh.text = sheet.toughness.getStat().ToString();
        _acc.text = sheet.accuracy.getStat().ToString();
        _wis.text = sheet.wisdom.getStat().ToString();
        _res.text = sheet.resistance.getStat().ToString();
        _lck.text = sheet.luck.getStat().ToString();
        //Debug.Log(sheet.PrintCharacterVitals());
    }
}
