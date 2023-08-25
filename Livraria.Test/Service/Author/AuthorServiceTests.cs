using Livraria.Domain.Entities;
using Livraria.Domain.ValueObjects;
using Moq;
using Livraria.Repository.Interfaces;
using Livraria.Service.Interfaces;
using Livraria.Service.Services;

namespace Livraria.Teste.Service;

public class AuthorServiceTests
{
    private readonly Mock<IAuthorRepository> _authorRepositoryMock;
    private readonly IAuthorService _authorService;

    public AuthorServiceTests()
    {
        _authorRepositoryMock = new Mock<IAuthorRepository>();
        _authorService = new AuthorService(_authorRepositoryMock.Object);
    }
    
    [Fact]
    public async Task GetAllAuthorsAsync_ShouldReturnEmptyAuthorsList()
    {
        // Arrange
        _authorRepositoryMock.Setup(repo => repo.GetAllAuthorsAsync(0, 25))
            .ReturnsAsync(new List<Author>());

        // Act
        var result = await _authorService.GetAllAuthorsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<Author>>(result);
        Assert.Empty(result);
    }
    
    [Fact]
    public async Task GetAllAuthorsAsync_ShouldReturnAuthorsList()
    {
        // Arrange
        var authors = MockAuthor.GetAuthorsList();
        _authorRepositoryMock.Setup(repo => repo.GetAllAuthorsAsync(0, 25))
            .ReturnsAsync(authors);

        // Act
        var result = await _authorService.GetAllAuthorsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<Author>>(result);
        Assert.Equal(3, result.Count);
    }
    
    [Fact]
    public async Task GetAuthorByIdAsync_ShouldReturnAuthor()
    {
        // Arrange
        var author = MockAuthor.GetAuthor();
        var authorId = author.Id;
        _authorRepositoryMock.Setup(repo => repo.GetAuthorByIdAsync(authorId))
            .ReturnsAsync(author);
        
        
        // Act
        var result = await _authorService.GetAuthorByIdAsync(authorId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(authorId, result.Id);
    }
}
