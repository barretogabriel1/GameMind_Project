using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD_Script : MonoBehaviour
{
   public void menu() {
   		SceneManager.LoadScene("Menu");
   }

   public void author() {
   		SceneManager.LoadScene("Author");
   }

   public void instructions() {
   		SceneManager.LoadScene("Instructions");
   }

   public void game() {
   		SceneManager.LoadScene("GameScene");
   }
}
