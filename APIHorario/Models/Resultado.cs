namespace APIHorario.Models;

public class Resultado
{
    public string? HorarioAtual { get; init; } = $"{DateTime.Now:HH:mm:ss}";
    public string? Mensagem { get; set; }
   
}