using System.Net.Http.Json;
using ClientesBlazorApp.Models;

namespace ClientesBlazorApp.Services
{
    public class ClienteApiService
    {
        private readonly HttpClient _http;

        public ClienteApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Cliente>> ObtenerClientesAsync()
        {
            var resultado = await _http.GetFromJsonAsync<List<Cliente>>("api/Clientes");
            return resultado ?? new List<Cliente>();
        }

        public async Task<Cliente?> CrearClienteAsync(Cliente cliente)
        {
            var respuesta = await _http.PostAsJsonAsync("api/Clientes", cliente);
            respuesta.EnsureSuccessStatusCode();
            return await respuesta.Content.ReadFromJsonAsync<Cliente>();
        }

        public async Task ActualizarClienteAsync(Cliente cliente)
        {
            var respuesta = await _http.PutAsJsonAsync($"api/Clientes/{cliente.Id_cliente}", cliente);
            respuesta.EnsureSuccessStatusCode();
        }

        public async Task EliminarClienteAsync(int id)
        {
            var respuesta = await _http.DeleteAsync($"api/Clientes/{id}");
            respuesta.EnsureSuccessStatusCode();
        }
    }
}