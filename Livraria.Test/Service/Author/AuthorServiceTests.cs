using Livraria.Repository.Interfaces;
using Livraria.Service.Interfaces;
using Livraria.Service.Services;
using Livraria.Test.Mock;
using Moq;

namespace Livraria.Test.Service.Author;

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
            .ReturnsAsync(new List<Domain.Entities.Author>());

        // Act
        var result = await _authorService.GetAllAuthorsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<Domain.Entities.Author>>(result);
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
        Assert.IsType<List<Domain.Entities.Author>>(result);
        Assert.Equal(3, result.Count);
    }
    
    [Fact]
    public async Task GetAuthorByIdAsync_ShouldReturnNull()
    {
        // Arrange
        var authorId = Guid.NewGuid();
        _authorRepositoryMock.Setup(repo => repo.GetAuthorByIdAsync(authorId)).ReturnsAsync((Domain.Entities.Author?)null);
        
        // Act
        var result = await _authorService.GetAuthorByIdAsync(authorId);

        // Assert
        Assert.Null(result);
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
    
    [Fact]
    public async Task InsertAuthorAsync_ShouldReturnTrue()
    {
        // Arrange
        var author = MockAuthor.GetAuthor();
        _authorRepositoryMock.Setup(repo => repo.InsertAuthorAsync(author)).ReturnsAsync(true);

        // Act
        var result = await _authorService.InsertAuthorAsync(author);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(true, result);
    }
    
    [Fact]
    public async Task InsertAuthorAsync_ShouldReturnNull()
    {
        // Arrange
        var author = MockAuthor.GetAuthor();
        _authorRepositoryMock.Setup(repo => repo.InsertAuthorAsync(author)).ReturnsAsync((bool?)null);
        // Act
        var result = await _authorService.InsertAuthorAsync(author);

        // Assert
        Assert.Null(result);
    }
}
