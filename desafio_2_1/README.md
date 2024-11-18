# Conversor

# Como rodar
- `cd Conversor && dotnet run`
- É necessário configurar um arquivo `.env` na raiz do projeto `Conversor` para definir a chave privada da API (verificar `.env.example`).
- Dependência: `DotNetEnv`.

## Organização do Projeto

- `Application/`: camada de Aplicação do projeto
    - `Application/CurrencyConversor/`: classe que recebe dois códigos de moedas e um valor e retorna um objeto com a moeda origem convertida para a moeda destino.
    - `Application/InputReader/`: classe responsável por ler os dados do usuário e criar um objeto com as moedas e o valor para serem convertidos.
- `Domain/Entities`: armazena as entidades do sistema
    - `Domain/Entities/ConversionPair`: representa um par de moedas, uma origem e um destino, e um valor flutuante.
    - `Domain/Entities/ConvertedPair`: representa o par de moedas acima após a conversão da origem no destino conforme uma taxa de conversão. Armazena o par original, a taxa e o novo valor.
- `Infra/`: camada de infraestrutura do projeto.
    - `Infra/Env/EnvHandler`: classe responsável por lidar com o `.env` e ler a variável de ambiente `API_KEY`.
    - `Infra/Env/RequestHandler`: classe responsável por fazer requisições para a rota de API que recupera a taxa de conversão entre duas moedas.
    - `Infra/Json/FieldExtractor`: classe responsável por ler um JSON e extrair campos específicos dele.
- `Validation/`: Camada de validação do sistema.
    - `Validation/UserInputHandler`: faz a leitura de uma entrada do usário como String. A seguir, passa a entrada em um `InputParser` para convertê-la no valor adequado. Por fim, passo o valor em um `Validator` para validá-lo conforme as regras de negócio. Enquanto qualquer uma dessas fases gerar erro, o usuário deve continuar fornecendo entradas, até que uma seja válida.
    - `Validation/InputParsers/`: recebem Strings digitadas pelo usuário e a convertem para outro tipo (ou verificam a validade da String). Verificam erros na conversão e os enviam.
    - `Validation/Validators`: recebem um valor de qualquer tipo e verificam sua validade conforme alguma regra de negócio estabelecida. Geram erros caso o valor seja inválido.
- `Main`: Ponto de partida do sistema, que gerencia a leitura e as requisições dos dados.
