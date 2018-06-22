# Apresentação

Esta aplicação foi desenvolvida para oferecer as pessoas a possibilidade de consulta de veiculos direto na base da Fipe, de uma maneira facil e objetiva, bem como disponibilizar das dll para importação de desenvolvedores para integrar em seus sistemas.

# Requisitos

Para executar o programa é necessário:
* Ter Windows instalado, qualquer versão.
* Ter o Framework .Net 4.6 instalado.


# Instalação

Não há necessidade de instalação, basta executar o **ConsultaFIPE.exe**.
Para realizar debug e compilar, deve clonar o repositório ou baixar o código fonte em .zip.

# Como utilizar

**Para usuários**

Basta baixar o programa no tópico **Release** mais abaixo, descompactar em alguma pasta e rodar o GestaoFrota.exe. Ele é estilo portable, ou seja, não é necessário sua instalação, sendo assim, é aconselhado a colocar a pasta em um pen driver ou hd externo e levar para qualquer lugar. Ao executar ele pela primeira vez, um arquivo chamado **Frota.sdf** será criado, ele é o banco de dados onde conterá todas as informações, e será gerado dentro da própria localização do executável. O sistema suporta uma boa capacidade de dados, porém para frotas acima de 5 carros entre em contato comigo que é mais aconselhado a usar um banco na nuvem, ou se for para empresa, será melhor instalar um banco SQL Server Express. Mas nestá situação, entre em contato que passo as orientações.
Na pasta do programa, será criado tres novas pastas:

* Comprovantes - esta pasta será usada para o programa salvar os comprovantes de abastecimentos, troca de oleo, anexadas no momento do lançamento do gasto.
* Documentos - esta pasta será usada para salvar os documentos do carro, CNH anexadas no programa.
* Multas - esta pasta será usada para salvar as multas anexadas.
* Seguro - esta pasta será usada para salvar os contratos de seguro anexados.


**Para desenvolvedores**

O código do projeto é liberado com o intuido a fomentar o opensource para tecnologia .NET, fica livre para ser clonado para aprender ou até sugerir melhorias e alterações no projeto. Algumas informações importantes:

* A solução foi desenvolvida no Framework 4.6, em Windows Forms.
* É utilizado o pacote Newtonsoft.Json pelo Nuget.
* É utilizado o pacote RestSharp pelo Nuget.

Se desejar incorpotar em seu projeto, pode usar as dll do arquivo dllParaImportar.rar, descompactar e referenciar as dll. Os pacotes Newtonsoft.Json e RestSharp podem ser instalados em seu projeto pelo Nuget, pegando assim a ultima versão disponivel, não é necessario importar estas dll, apenas WebServiceFIPE.dll. 


# Imagens do programa

![Tela](Release/tela.PNG)


# Pacotes de terceiro

* Newtonsoft.Json Versão: 11.0.2
* RestSharp Versão: 106.3.1



# Release

A versão Release do programa, executável com suas dependencias, basta descompactar e executar, pode ser baixado no link abaixo:

Atenção, aqui é para aqueles que apenas querem utilizar o programa...

[Consulta Fipe](https://github.com/ezequielsd/ConsultaFipe/raw/master/Release/Aplicativo.rar)

# Para Desenvolvedores

Se desejar basta importar as dll para seu projeto baixando o arquivo:

[dlls](https://github.com/ezequielsd/ConsultaFipe/raw/master/Release/dllParaImportar.rar)

# Autor

Ezequiel da Silva Daniel  
[Blog](https://ezequieldaniel.wordpress.com/)  
[Email](ezequielsd@gmail.com)

# Licença

[MIT]


