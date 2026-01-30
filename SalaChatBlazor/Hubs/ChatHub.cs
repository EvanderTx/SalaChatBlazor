using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace SalaChatBlazor.Hubs
{
    public class ChatHub : Hub
    {
        // Armazena: ConnectionId -> (NomeUsuario, Sala)
        private static readonly ConcurrentDictionary<string, (string Nome, string Sala)> Usuarios = new();

        public async Task EntrarNaSala(string nomeUsuario, string? idSala)
        {
            string salaDestino = string.IsNullOrWhiteSpace(idSala) ? "Geral" : idSala;

            // Adiciona ao grupo do SignalR
            await Groups.AddToGroupAsync(Context.ConnectionId, salaDestino);

            Usuarios[Context.ConnectionId] = (nomeUsuario, salaDestino);

            // Notifica entrada apenas para a sala específica
            await Clients.Group(salaDestino).SendAsync("AvisoEntrada", $"{nomeUsuario} entrou na sala {salaDestino}!");

            await AtualizarDadosSala(salaDestino);
        }

        public async Task EnviarMensagem(string nomeUsuario, string? idSala, string texto)
        {
            string salaDestino = string.IsNullOrWhiteSpace(idSala) ? "Geral" : idSala;
            await Clients.Group(salaDestino).SendAsync("ReceberMensagem", nomeUsuario, texto);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (Usuarios.TryRemove(Context.ConnectionId, out var info))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, info.Sala);
                await AtualizarDadosSala(info.Sala);
            }
            await base.OnDisconnectedAsync(exception);
        }

        private async Task AtualizarDadosSala(string sala)
        {
            var usuariosNaSala = Usuarios.Values
                .Where(u => u.Sala == sala)
                .Select(u => u.Nome)
                .ToList();

            await Clients.Group(sala).SendAsync("UpdateUsers", usuariosNaSala, usuariosNaSala.Count);
        }
    }
}
