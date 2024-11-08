# Administração de Agenda de um Consultório Odontológico

## Organização do Projeto

- `Application/Actions/`: é onde ficam as operações do sistema que envolvam leitura/criação de dados. Uma `Action` normalmente lê e valida dados do usuário e depois escreve/lê dados no armazenamento. Elas estão divididas em:
    - `Application/ConsultationActions/`: envolvem agendamento de consulta 
    - `Application/PatientActions/`: envolvem registro de pacientes.
- `Domain`: armazena as entidades e repositórios do sistema, conforme o negócio Consultório Odontológico. 
    - `Domain/Entities/`: é onde estão definidos `Patient` e `Consultation`. 
    - `Domain/Repositories/`: `Agenda` é uma classe Singleton que gerencia a lista de consultas; semelhantemente, `Registration` é um Singleton que gerencia o registro de Pacientes.
- `Presentation/Menus/NavigationMenus/`: camada de apresentação com os menus de navegação do sistema. Esses menus não geram efeitos colaterais nem fazem leitura dos dados; sua função é dirigir o usuário para outro menu ou iniciar uma Ação.
- `Utils/`: entidades e funções utilitárias. `PrintPatients` é classe responsável por imprimir a listagem de pacientes conforme o layout estabelecido. `TimeInterval` é uma classe que representa intervalos de tempo e é usada na `Consultation`.
- `Validation/`: Camada de validação do sistema.
    - `Validation/UserInputHandler`: faz a leitura de uma entrada do usário como String. A seguir, passa a entrada em um `StringParser` para convertê-la no valor adequado. Por fim, em um `Validator` para validar o valor conforme as regras de negócio. Enquanto qualquer uma dessas fases gerar erro, o usuário deve continuar fornecendo entradas, até que uma seja válida.
    - `Validation/InputParsers/`: recebem Strings digitadas pelo usuário e a convertem para outro tipo (ou verificam a validade da String). Verificam erros na conversão e os enviam.
    - `Validation/Validators`: recebem um valor de qualquer tipo e verificam sua validade conforme alguma regra de negócio estabelecida. Geram erros caso o valor seja inválido.
- `Main`: Ponto de partida do sistema, que gerencia os menus e as ações adequadas às entradas do usuário e respostas das ações.
