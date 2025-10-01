using System.Text.Json.Serialization;
using System.Text.Json;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Dominio.ModuloCompromisso;

namespace eAgenda.Infraestrutura.Arquivos.Compartilhado;

public class ContextoDados
{
    private string pastaArmazenamento = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "eAgenda"
    );

    private string arquivoArmazenamento = "dados.json";

    public List<Tarefa> Tarefas { get; set; }
    public List<Categoria> Categorias { get; set; }
    public List<Despesa> Despesas { get; set; }
    public List<Contato> Contatos { get; set; }
    public List<Compromisso> Compromissos { get; set; }

    public ContextoDados()
    {
        Tarefas = new List<Tarefa>();
        Categorias = new List<Categoria>();
        Despesas = new List<Despesa>();
        Contatos = new List<Contato>();
        Compromissos = new List<Compromisso>();
    }

    public ContextoDados(bool carregarDados) : this()
    {
        if (carregarDados)
            Carregar();
    }

    public void Salvar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.WriteIndented = true;
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        string json = JsonSerializer.Serialize(this, jsonOptions);

        if (!Directory.Exists(pastaArmazenamento))
            Directory.CreateDirectory(pastaArmazenamento);

        File.WriteAllText(caminhoCompleto, json);
    }

    public void Carregar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        if (!File.Exists(caminhoCompleto)) return;

        string json = File.ReadAllText(caminhoCompleto);

        if (string.IsNullOrWhiteSpace(json)) return;

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(
            json, 
            jsonOptions
        )!;

        if (contextoArmazenado == null) return;

        Tarefas = contextoArmazenado.Tarefas;
        Categorias = contextoArmazenado.Categorias;
        Despesas = contextoArmazenado.Despesas;
        Contatos = contextoArmazenado.Contatos;
        Compromissos = contextoArmazenado.Compromissos;
    }
}
