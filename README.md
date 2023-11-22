
# Desafio Fcamara

Este projeto foi criado como solução do desafio 1, onde foi solicitado a criaçao de um projeto que simule um caixa eletrônico.

A solução foi criada em .net 7, usando padrão MVC, porem não foi criada nenhuma interface para este projeto, porem o projeto esta utilizando SWAGGER onde é possivel fazer os testes do endpoint.




## Documentação da API

Como parametros enviados no desafio temos notas de R$10,00 , R$20,00 , R$50,00 e R$100,00.
Coloquei somente 2 unidades disponiveis de cada nota, ou seja se solicitarmos um saque de R$300,00 , teremos 2 notas de R$100,00 e 2 notas de R$50,00 (exemplo demonstrado abaixo).

Temos o Swagger implementado porem segue um breve descritivo da rota criada

#### Realizando o saque do valor enviado 


```http
  POST /Caixa/saque
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `valorSaque` | `int` | **Obrigatório**. O valor do Saque desejado |

#### Payload envio

```JSON
{
  "valorSaque": 300
}
```

#### Payload retorno

```JSON
{
  "resultado": {
    "mensagem": "Saque Realizado com Sucesso",
    "notasSaque": [100,100,50,50]
  }
}
```

## Possíveis erros

Valores os quais não temos notas para fazer o saque.

#### Payload envio

```JSON
{
  "valorSaque": 75
}
```

#### Payload retorno

```JSON
{
  "resultado": {
    "mensagem": "Não é possivel efetuar o saque do valor informado.",
    "notasSaque": null
  }
}
```


Quando não temos notas suficientes, neste caso se colocarmos 0 quantidade de notas de R$10,00 e solicitarmos um saque de 10 irá retornar o erro abaixo.
#### Payload envio

```JSON
{
  "valorSaque": 10
}
```

#### Payload retorno

```JSON
{
  "resultado": {
    "mensagem": "Não foi possivel efetuar o saque pois não temos notas de R$10 disponiveis no momento.",
    "notasSaque": null
  }
}
```


## Autores

- [@NicolasAugustoSiqueira](https://github.com/NicolasAugustoSiqueira)

