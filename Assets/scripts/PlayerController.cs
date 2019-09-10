using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    BattleManager _battle;
    [SerializeField]
    PlayerCameraController _cameraController;
    [SerializeField]
    Transform camTarget;
    [SerializeField]
    LayerMask selectionMask;
    [SerializeField]
    LayerMask navigationMask;
    [SerializeField]
    float selectionDistance;

    [SerializeField]
    GameObject characterPrefab;

    Player _player;

    List<PlayerCharacterController> spawnedCharacters;
    PlayerCharacterController selectedCharacter;

    public void Init(Player player)
    {
        _player = player;
        spawnedCharacters = new List<PlayerCharacterController>();
    }

    public void SpawnCharacter(Vector3 position)
    {
        Debug.Log("Spawning Character at " + position);
        PlayerCharacterController c = Instantiate<GameObject>(characterPrefab).GetComponent<PlayerCharacterController>();
        c.transform.position = position;
        spawnedCharacters.Add(c);
        c.Init();
        Deselect();
    }

    public void DespawnCharacter(PlayerCharacterController character)
    {
        spawnedCharacters.Remove(character);
        Destroy(character.gameObject);
    }

    void SelectPlayerCharacter(PlayerCharacterController p)
    {
        selectedCharacter = p;
        camTarget.parent = p.transform;
        p.ToggleSelectionVisible(true);
        //Debug.Log("Selected " + p.name);
    }

    public void Deselect()
    {
        if (selectedCharacter != null)
        {
            selectedCharacter.ToggleSelectionVisible(false);
            selectedCharacter = null;
        }
        camTarget.parent = transform;
    }

    public List<PlayerCharacterController> GetCharacters()
    {
        return spawnedCharacters;
    }

    #region Input
    bool lmbOldState;
    bool rmbOldState;


    public void ProcessLMBInput(Vector2 mousePosition)
    {
        RaycastHit hit;
        if (Physics.Raycast(_cameraController.GetCamera().ScreenPointToRay(mousePosition), out hit, selectionDistance, selectionMask))
        {
            if(hit.transform.tag == "Player")
            {
                PlayerCharacterController selected =  hit.transform.GetComponent<PlayerCharacterController>();
                SelectPlayerCharacter(selected);
            }
            else
            {

            }
        }
    }

    public void ProcessRMBInput(Vector2 mousePosition)
    {
        if (selectedCharacter != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(_cameraController.GetCamera().ScreenPointToRay(mousePosition), out hit, selectionDistance, navigationMask))
            {
                //Debug.Log("hit " + hit.point);
                selectedCharacter.SetNewDestination(hit.point);
            }
            
        }
    }

    public void ProcessMousePosition(Vector2 mousePosition)
    {
        _cameraController.ProcessMousePosition(mousePosition);
    }
    
    public void ProcessConfirmInput(bool input)
    {

    }

    public void ProcessCancelInput(bool input)
    {

    }
    #endregion
}
