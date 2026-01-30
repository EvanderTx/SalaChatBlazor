# 🚀 Blazor Real-Time Chat com SignalR
Este é um projeto de estudo desenvolvido em Blazor Web App (.NET 10) para demonstrar o poder da comunicação bi-direcional em tempo real utilizando ASP.NET Core SignalR.

## 📝 Sobre o Projeto
A aplicação permite que usuários entrem em uma sala global ou criem/entrem em salas privadas através de um ID único. O sistema gerencia a contagem de membros por sala e permite a troca de mensagens instantâneas sem a necessidade de atualizar a página.

## ✨ Funcionalidades
- Entrada Dinâmica: Usuário define seu nome e escolhe entre a sala "Geral" ou um ID privado.

- Comunicação Real-time: Envio e recebimento de mensagens instantâneas via WebSockets.

- Controle de Presença: Lista de usuários ativos na sala e contador atualizado em tempo real.

- Notificações de Sistema: Avisos visuais quando novos membros entram na sala.

- Interface Reativa: Construída inteiramente em C# com Blazor Interactive Server.

## 🛠️ Tecnologias Utilizadas
- C# / .NET 10

- Blazor (Interactive Server Mode)

- SignalR (Gerenciamento de Hubs e Grupos)

- Bootstrap 5 (Estilização CSS)

## 🏗️ Estrutura do Código
- Hubs/ChatHub.cs: O "cérebro" do servidor. Gerencia os grupos (salas), conexões e o roteamento de mensagens.

- Pages/SalaChat.razor: A interface do usuário. Contém a lógica de conexão do cliente e a renderização dinâmica do chat.

- Program.cs: Configuração dos serviços do SignalR e mapeamento da rota do Hub.

# 🚀 Como rodar o projeto
## Pré-requisitos:

- Ter o SDK do .NET instalado.

- Um editor de código (VS Code ou Visual Studio).

## Clonar o repositório:

## Bash

- git clone https://github.com/EvanderTx/SalaChatBlazor.git
- cd nome-do-repositorio
## Executar a aplicação:

## Bash

- dotnet watch run
Testar a interatividade: Abra https://localhost:5001 em dois navegadores diferentes para simular a conversa entre dois usuários.

# 🧠 Conceitos Aprendidos
- Uso de ConcurrentDictionary e Tuplas para gerenciar estado em memória de forma thread-safe.

- Diferença entre renderização estática e interativa no Blazor.

- Padrão de comunicação Hub-Client do SignalR.

- Gerenciamento de grupos (Groups) para salas isoladas.

# 🛠️ Próximos Passos (Roadmap de Estudos)
Para levar este projeto ao próximo nível e aprofundar seus conhecimentos em Blazor, aqui estão algumas sugestões de melhorias:

## 1. Persistência de Dados
- Desafio: Atualmente, se o servidor reiniciar, as mensagens somem.

- Ação: Integre o Entity Framework Core com SQLite ou SQL Server para salvar o histórico de mensagens e consultá-lo ao entrar na sala.

## 2. Estilização e UX (User Experience)
- Scroll Automático: Use JS Interop para fazer a caixa de chat rolar para o final automaticamente sempre que uma nova mensagem chegar.

- Balões de Chat: Diferencie visualmente as suas mensagens das mensagens de outros usuários (ex: suas mensagens à direita em azul, outras à esquerda em cinza).

- Indicador de Digitação: Implementar o famoso "Fulano está digitando..." usando um evento oninput que dispara uma mensagem para o Hub.

## 3. Autenticação Simples
- Desafio: Qualquer um pode usar qualquer nome.

- Ação: Crie uma tela de login real ou apenas garanta que nomes duplicados não possam entrar na mesma sala.

## 4. Funcionalidades de Moderação
- Comandos de Barra: Crie comandos como /limpar (apaga as mensagens da tela) ou /sair (desconecta o usuário).
 
- Criação de IDs Aleatórios: Adicione um botão "Gerar Sala Aleatória" que cria um GUID para o usuário compartilhar com amigos.

##💡 Dica Final para o seu Aprendizado
Ao documentar esse projeto no seu portfólio, mencione que você escolheu o Blazor Server por causa da baixa latência do SignalR, o que o torna ideal para dashboards e ferramentas de colaboração em tempo real.

