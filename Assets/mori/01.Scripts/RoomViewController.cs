using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomViewController : MonoBehaviour
{
    [SerializeField] private List<GameObject> rooms = new();
    [field: SerializeField] public GameObject Arrows { get; private set; }
    
    private int currentIndex = 0;
    public bool IsMoveable { get; private set; } = true;

    private void Start()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            rooms[i].SetActive(i == currentIndex);
        }
        Arrows.SetActive(IsMoveable && rooms.Count > 1);
    }

    public void SetMoveable(bool isMoveable)
    {
        this.IsMoveable = isMoveable;
        Arrows.SetActive(isMoveable && rooms.Count > 1);
    }

    public void MoveLeft() => Move(-1);
    public void MoveRight() => Move(1);
    
    private void Move(int direction)
    {
        if (!IsMoveable || rooms.Count < 2) return;

        int nextIndex = (currentIndex + direction + rooms.Count) % rooms.Count;
        rooms[currentIndex].SetActive(false);
        currentIndex = nextIndex;
        rooms[nextIndex].SetActive(true);
    }

    private void Update()
    {
        if (!Arrows.activeSelf)
        {
            return;
        }

        if (Keyboard.current.aKey.wasPressedThisFrame && IsMoveable)
        {
            MoveLeft();
        }

        if (Keyboard.current.dKey.wasPressedThisFrame && IsMoveable)
        {
            MoveRight();
        }
    }
}