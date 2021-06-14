## Resumo
É comum em diversas situações criarmos diversos contadores, ifs e elses para limitar garantir que um método seja invocado a cada x segundos. Esse processo é exaustivo, uma vez que você precisa implementar varias e varias vezes em diversos scritps e projetos diferentes.
Com o **Call Limiter**, você pode criar limitadores facilmente utilizando as tecnicas de [Throttle e Debounce](http://loopinfinito.com.br/2013/09/24/throttle-e-debounce-patterns-em-javascript/). Apesar de serem tecnicas utilizadas comumente no universo WEB, podemos adaptar para o contexto de temporizadores no Unity.

---

## Exemplo de uso do Throttle

```
using UnityEngine;
using HGS.CallLimiter;

public class Weapon : MonoBehaviour
{
    Throttle _fireThrottle = new Throttle();

    void Update()
    {
        if (Input.GetMouseButton(0))
        {          
            _fireThrottle.Run(Fire, 0.3f);
        }
    }

		private void Fire(){
			Debug.Log("fire");
		}
}
```

**Passo a passo**

1) Importamos o namespace `HGS.CallLimiter` para ter acesso ao script de `Throttle`.

2) Atribuimos uma nova instancia do `Throttle` na variavel `_fireThrottle`. Isso é necessário pois o Throttle armazena um cronometro interno para impedir que um metodo seja chamado mais de uma vez antes do intervalo especificado.

3) Na função `Update` usamos `Input.GetMouseButton(0)`, isso será chamado a cada frame enquanto o usuário estiver pressionando o botão esquerdo do mouse.

4) Invocando `_fireThrottle.Run(Fire, 0.3f);` estamos instruindo o throttle de tiro para invocar o metodo `Fire`, caso o intervalo da ultima invocaçào seja menor que `0.3f`. Ou seja, o metodo `Fire` está limitado a ser invocado a cada `0.3` segundos.

---

## Exemplo de uso do Debounce


```
using UnityEngine;
using HGS.CallLimiter;

public class CoinManager : MonoBehaviour
{
    Debounce _addCoinDebouncer = new Debounce();
		int _coins = 0;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {          
           AddCoin(1);
        }
    }

		public void AddCoin(int amount)
		{
			_coins += amount;
			_addCoinDebouncer.Run(SaveCoins, 1, this);
		}

		private void SaveCoins(){
			Debug.Log(_coins + " Coins saved!");
		}
}
```

**Passo a passo**

1) Importamos o namespace `HGS.CallLimiter` para ter acesso ao script de `Debounce`.

2) Atribuimos uma nova instancia do `Debounce` na variavel `_addCoinDebouncer`. Isso é necessário pois o Debounce gerencia coroutines internas.

3) Criamos um fluxo de adição de moedas, enquanto o usuario estiver segurando o clique, adicionamos +1 moeda. Isso é feito no metodo `Update`, onde utilizamos `Input.GetMouseButton(0)`. Em seguida invocamos `AddCoins(1)` para incrementar 1 moeda.

4) Sempre que uma moeda é adicionada, executamos o debouncer, com `_addCoinDebouncer.Run(SaveCoins, 1, this);` onde, `SaveCoins` é o metodo que será chamado caso o jogador fique `1` segundo sem adicionar mais moedas e `this` é o MonoBehaviour atual, usamos para criar Coroutines internas.