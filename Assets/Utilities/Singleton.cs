using UnityEngine;

/*
 *  Class contracto (abstracta) responsável pela criação singular de tipos através desta, ou seja,
 *  o tipo X que extende a class Singleton designa o T pelo tipo a ser utilizado como instância.
 *  Neste caso podemos observar que a class Singleton extende de MonoBehaviour e especifica que T é MonoBehaviour,
 *  referindo assim que a instância daquele tipo T é do tipo MonoBeaviour.
 *  Num caso mais prático a class GameManager extende de Singleton e especifica que T é do tipo GameManager, ou seja,
 *  a instância que esta cria e retorna é de si própria, limitando o programa em si a utilização singular dessa instância e
 *  não permitindo a criação de mais instâncias do tipo GameManager, daí o nome Singleton.
 */
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            DontDestroyOnLoad(instance);
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<T>();
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
}
