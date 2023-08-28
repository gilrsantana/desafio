using Livraria.Shared.Messages;
using Livraria.Shared.Presenters;

namespace Livraria.Test.Services;

public class AuthorServiceTest
{
    private readonly Mock<IAuthorRepository> _authorRepositoryMock;
    private readonly IAuthorService _authorService;

    public AuthorServiceTest()
    {
        _authorRepositoryMock = new Mock<IAuthorRepository>();
        _authorService = new AuthorService(_authorRepositoryMock.Object);
    }

    [Fact]
    public async Task GetAllAuthorsAsync_ShouldReturnEmptyAuthorsList_WithEmptyAuthorList()
    {
        // Arrange
        _authorRepositoryMock.Setup(repo => repo.GetAllAuthorsAsync(0, 25))
            .ReturnsAsync(new List<Author>());

        // Act
        var result = await _authorService.GetAllAuthorsAsync();

        // Assert
        Assert.NotNull(result.Data);
        Assert.IsType<Presenter<ICollection<Author>>>(result);
        Assert.IsType<List<Author>>(result.Data);
        Assert.Empty(result.Data);

        Assert.NotNull(result.Errors);
        Assert.IsType<List<string>>(result.Errors);
        Assert.Single(result.Errors);
        Assert.Equal(Error.Author.NOT_FOUND, result.Errors[0]);
        
        _authorRepositoryMock
            .Verify(x => x.GetAllAuthorsAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
    }

    [Theory]
    [InlineData(-1,25)]
    [InlineData(0,0)]
    [InlineData(1,0)]
    [InlineData(-1,0)]
    [InlineData(-1,-1)]
    [InlineData(0,-1)]
    public async Task GetAllAuthorsAsync_ShouldReturnEmptyAuthorsList_WhenInvalidSkipTake(int skip, int take)
    {
        // Arrange
        _authorRepositoryMock.Setup(repo => repo.GetAllAuthorsAsync(skip, take))
            .ReturnsAsync(new List<Author>());

        // Act
        var result = await _authorService.GetAllAuthorsAsync(skip, take);

        // Assert
        Assert.NotNull(result.Data);
        Assert.IsType<Presenter<ICollection<Author>>>(result);
        Assert.IsType<List<Author>>(result.Data);
        Assert.Empty(result.Data);

        Assert.NotNull(result.Errors);
        Assert.IsType<List<string>>(result.Errors);
        Assert.Single(result.Errors);
        Assert.Equal(Error.Common.INVALID_SKIP_TAKE, result.Errors[0]);
        
        _authorRepositoryMock
            .Verify(x => x.GetAllAuthorsAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
    }
    
    [Fact]
    public async Task GetAllAuthorsAsync_ShouldReturnAuthorsList()
    {
        // Arrange
        _authorRepositoryMock.Setup(repo => repo.GetAllAuthorsAsync(0, 25))
            .ReturnsAsync(MockAuthor.ListOfAuthors);
    
        // Act
        var result = await _authorService.GetAllAuthorsAsync();
    
        // Assert
        Assert.NotNull(result.Data);
        Assert.IsType<Presenter<ICollection<Author>>>(result);
        Assert.IsType<List<Author>>(result.Data);
        Assert.Equal(3, result.Data.Count);
        
        Assert.NotNull(result.Errors);
        Assert.IsType<List<string>>(result.Errors);
        Assert.Empty(result.Errors);
        
        _authorRepositoryMock
            .Verify(x => x.GetAllAuthorsAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public async Task GetAuthorByIdAsync_ShouldReturnNull_WithNotFoundId()
    {
        // Arrange
        var authorId = Guid.NewGuid();
        _authorRepositoryMock.Setup(repo => repo.GetAuthorByIdAsync(authorId))
            .ReturnsAsync((Author?)null);
        
        // Act
        var result = await _authorService.GetAuthorByIdAsync(authorId);
    
        // Assert
        Assert.Null(result.Data);
        Assert.IsType<Presenter<Author>>(result);
        
        Assert.NotNull(result.Errors);
        Assert.IsType<List<string>>(result.Errors);
        Assert.Single(result.Errors);
        Assert.Equal(Error.Author.NOT_FOUND, result.Errors[0]);
        
        _authorRepositoryMock
            .Verify(x => x.GetAuthorByIdAsync(It.IsAny<Guid>()), Times.Once);
    }
    
    [Theory]
    [MemberData(nameof(MockAuthor.WithInvalidGuid), MemberType = typeof(MockAuthor))]
    public async Task GetAuthorByIdAsync_ShouldReturnNull_WithInvalidGuid(Guid id)
    {
        // Arrange
        _authorRepositoryMock.Setup(repo => repo.GetAuthorByIdAsync(id))
            .ReturnsAsync((Author?)null);
        
        // Act
        var result = await _authorService.GetAuthorByIdAsync(id);
    
        // Assert
        Assert.Null(result.Data);
        Assert.IsType<Presenter<Author>>(result);
        
        Assert.NotNull(result.Errors);
        Assert.IsType<List<string>>(result.Errors);
        Assert.Single(result.Errors);
        Assert.Equal(Error.Common.INVALID_ID, result.Errors[0]);
        
        _authorRepositoryMock
            .Verify(x => x.GetAuthorByIdAsync(It.IsAny<Guid>()), Times.Never);
    }
    
    [Fact]
    public async Task InsertAuthorAsync_ShouldReturnFalseWithError_WhenErrorInRepository()
    {
        // Arrange
        _authorRepositoryMock.Setup(repo => 
            repo.InsertAuthorAsync(MockAuthor.AuthorEntity)).ReturnsAsync(false);
 
        // Act
        var result = await _authorService.InsertAuthorAsync(MockAuthor.AuthorEntity);
    
        // Assert
        Assert.NotNull(result);
        Assert.IsType<Presenter<bool>>(result);
        Assert.False(result.Data);
        
        Assert.NotNull(result.Errors);
        Assert.IsType<List<string>>(result.Errors);
        Assert.Single(result.Errors);
        Assert.Equal(Error.Author.NOT_INSERTED, result.Errors[0]);
        
        _authorRepositoryMock
            .Verify(x => x.InsertAuthorAsync(It.IsAny<Author>()), Times.Once);
    }
    
    [Fact]
    public async Task InsertAuthorAsync_ShouldReturnTrue()
    {
        // Arrange
        _authorRepositoryMock
            .Setup(repo => repo.InsertAuthorAsync(It.IsAny<Author>()))
            .ReturnsAsync(true);
    
        // Act
        var result = await _authorService
                                .InsertAuthorAsync(MockAuthor.AuthorEntity);
    
        // Assert
        Assert.NotNull(result);
        Assert.IsType<Presenter<bool>>(result);
        Assert.True(result.Data);
        
        Assert.NotNull(result.Errors);
        Assert.IsType<List<string>>(result.Errors);
        Assert.Empty(result.Errors);
        
        _authorRepositoryMock
            .Verify(x => x.InsertAuthorAsync(It.IsAny<Author>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAuthorAsync_ShouldReturnFalseWithError_WhenErrorInRepository()
    {
        // Arrange
        _authorRepositoryMock.Setup(repo => 
            repo.InsertAuthorAsync(MockAuthor.AuthorEntity)).ReturnsAsync(false);
 
        // Act
        var result = await _authorService.InsertAuthorAsync(MockAuthor.AuthorEntity);
    
        // Assert
        Assert.NotNull(result);
        Assert.IsType<Presenter<bool>>(result);
        Assert.False(result.Data);
        
        Assert.NotNull(result.Errors);
        Assert.IsType<List<string>>(result.Errors);
        Assert.Single(result.Errors);
        Assert.Equal(Error.Author.NOT_INSERTED, result.Errors[0]);
        
        _authorRepositoryMock
            .Verify(x => x.InsertAuthorAsync(It.IsAny<Author>()), Times.Once);
    }
    
    [Fact]
    public async Task UpdateAuthorAsync_ShouldReturnTrue()
    {
        // Arrange
        _authorRepositoryMock
            .Setup(repo => repo.UpdateAuthorAsync(MockAuthor.AuthorEntity))
            .ReturnsAsync(true);
        // Act
        var result = await _authorService
            .UpdateAuthorAsync(Guid.NewGuid(), MockAuthor.AuthorEntity);
    
        // Assert
        Assert.NotNull(result);
        Assert.IsType<Presenter<bool>>(result);
        Assert.True(result.Data);
        
        Assert.NotNull(result.Errors);
        Assert.IsType<List<string>>(result.Errors);
        Assert.Empty(result.Errors);
        
        _authorRepositoryMock
            .Verify(x => x.UpdateAuthorAsync(It.IsAny<Author>()), Times.Once);
    }
}
