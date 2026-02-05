# Integração Arduino com SQLite usando C# e LM35

Este projeto demonstra a integração entre **hardware e software**, realizando a leitura de temperatura ambiente através do **sensor LM35**, conectado a um **Arduino**, com envio contínuo dos dados via **comunicação serial** para uma aplicação desenvolvida em **C# (.NET)**, que armazena as informações em um banco de dados **SQLite**.

O objetivo é apresentar um fluxo completo de **aquisição, processamento e persistência de dados**, integrando sistemas embarcados com uma aplicação desktop/console.

---

## Funcionamento do Projeto

O funcionamento ocorre da seguinte forma:

1. O **sensor LM35** mede a temperatura ambiente  
2. O **Arduino** converte o sinal analógico em graus Celsius  
3. Os dados são enviados via **porta serial**  
4. A aplicação em **C# (.NET)**:
   - Lê os dados da serial
   - Valida e converte os valores
   - Armazena a temperatura com data e hora no **SQLite**


---

## Tecnologias Utilizadas

- **Arduino**
- **Sensor de temperatura LM35**
- **C# (.NET)**
- **System.IO.Ports** (comunicação serial)
- **SQLite** (Microsoft.Data.Sqlite)
- **Git / GitHub**
- **Linux**

---

