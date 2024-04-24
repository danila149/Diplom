using UnityEngine;

namespace Character
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Inventory inventory;
        [SerializeField] private CraftingSystem craftingSystem;

        public bool OnPause { get; set; }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && (!inventory.IsInvetoryOpen && !craftingSystem.IsCrafting))
            {
                pauseMenu.SetActive(true);
                playerMovement.PlayerInput = false;
                OnPause = true;
            }
            if(!pauseMenu.activeSelf)
                OnPause = false;
        }
    }
}