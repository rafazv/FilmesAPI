using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme {

    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo título é obrigatório")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "O campo diretor é obrigatório")]
    public string? Diretor { get; set; }
    public string? Genero { get; set; }

    [Range(1, 600, ErrorMessage = "A duração deve estar entre 1 e 600 minutos")]
    public int Duracao { get; set; }

}