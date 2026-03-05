namespace CheckerBoardPosition.Tests;

public class CheckerBoardPositionTest
{
    [Fact]
    public void Constructor_ValidCoordinates_Success()
    {
        // Arrange
        byte x = 2;
        byte y = 3;
        
        // Act
        var result = new CheckerBoardPosition(x, y);
        
        // Assert
        Assert.Equal(x, result.X);
        Assert.Equal(y, result.Y);
    }

    [Theory]
    [InlineData(10,12)]
    [InlineData(15,6)]
    [InlineData(6,10)]
    public void Constructor_InvalidCoordinates_Throws(byte x, byte y)
    {
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new CheckerBoardPosition(x, y));
    }
    
    [Fact]
    public void CheckerBoardPositionParse_ValidData_Success()
    {
        // Act
        string s = "A1";
        
        // Act
        var result = CheckerBoardPosition.Parse(s,null);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(s, result.ToString());
    }

    [Theory]
    [InlineData("GG")]
    [InlineData("67")]
    [InlineData("8X")]
    [InlineData("322")]
    public void CheckerBoardPositionParse_InvalidCoordinate_Throws(string s)
    {
        Assert.Throws<FormatException>(() => CheckerBoardPosition.Parse(s, null));
    }
    
    [Theory]
    [InlineData("A8")]
    [InlineData("A7")]
    [InlineData("E4")] 
    public void TryParse_ValidCoordinate_Success(string s)
    {
        var b = CheckerBoardPosition.TryParse(s, null, out CheckerBoardPosition result);
        
        Assert.True(b);
        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("GG")]
    [InlineData("67")]
    [InlineData("8X")]
    [InlineData("322")]
    public void TryParse_InvalidCoordinate_Fail(string s)
    {
        var b = CheckerBoardPosition.TryParse(s, null, out CheckerBoardPosition result);
        
        Assert.False(b);
        Assert.Null(result);
    }
    
    
    [Theory]
    [InlineData(1, 1, 'A')]
    [InlineData(2, 2, 'B')]
    [InlineData(3, 3, 'C')]
    public void ConstructorXLetter_CorrectLetter_Success(byte x, byte y, char expectedX)
    {
        // Arrange
        var position = new CheckerBoardPosition(x, y);
        
        // Act
        char result = position.XLetter;
                                   
        // Assert
        Assert.Equal(expectedX, result);
    }
    
    [Theory]
    [InlineData(7, 1, 'A')]
    [InlineData(2, 2, 'J')]
    [InlineData(2, 3, '3')]
    public void ConstructorXLetter_CorrectLetter_Fail(byte x, byte y, char expectedX)
    {
        // Arrange
        var position = new CheckerBoardPosition(x, y);
        
        // Act
        char result = position.XLetter;
                                   
        // Assert
        Assert.NotEqual(expectedX, result);
    }

    [Theory]
    [InlineData(1, 1, "A1")]
    [InlineData(2, 2, "B2")]
    [InlineData(3, 3, "C3")]
    public void Tostring_Coordinate_Success(byte x, byte y, string expectedCoordinate)
    {
        // Arrange
        var position = new CheckerBoardPosition(x, y);
   
        // Act
        var result = position.ToString();
        
        // Assert
        Assert.Equal(expectedCoordinate, result);
    }
    
}