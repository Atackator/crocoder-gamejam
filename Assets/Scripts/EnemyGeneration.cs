using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int numberOfEnemies = 15;  // Numărul de inamici de generat
    public Vector2 spawnAreaMin = new Vector2(-55, -55);  // Limita minimă a zonei de spawn
    public Vector2 spawnAreaMax = new Vector2(15, 15);    // Limita maximă a zonei de spawn
    public GameObject enemyPrefab;  // Prefabul inamicilor
    public float timer = 3f;
    void Start()
    {
        
        // Începe generarea inamicilor la fiecare 5 secunde
        InvokeRepeating("SpawnEnemy", 0f, timer); // Se va apela la fiecare 5 secunde
    }

    void SpawnEnemy()
    {
        // Generarea unei poziții aleatoare în zona definită
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0); // Poziția în 2D (Z = 0 pentru 2D)

        // Instantierea unui inamic la poziția generată
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Dacă ai nevoie să oprești generarea după un anumit număr de inamici, folosește un contor:
        numberOfEnemies--;
        if (numberOfEnemies <= 0)
        {
            CancelInvoke("SpawnEnemy"); // Oprește generarea când nu mai sunt inamici de creat
        }
    }
}
