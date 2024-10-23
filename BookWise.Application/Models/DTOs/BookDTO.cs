﻿namespace BookWise.Application.Models.DTOs;
public class BookDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ISBN { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public DateTime PublishedAt { get; set; }
    public int NumberOfPages { get; set; }
    public decimal AverageGrade { get; set; }

    public Core.Entities.Book ToEntity() => new(Title, Description, ISBN, Author, Genre, PublishedAt, NumberOfPages, AverageGrade);

    // criar método que calcula a média das notas baseado nas reviews existentes deste livro
}
