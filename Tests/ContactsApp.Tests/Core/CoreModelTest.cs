using ContactsApp.Core.Results;

namespace ContactsApp.Tests.Core;
public class CoreModelTest
{
    [Fact]
    public void BaseResponse_Success_SetAndGetCorrectly()
    {
        // Arrange And Act
        var baseResponse = new BaseResponse(true);
        var success = true; // Set success value.

        // Assert
        Assert.Equal(success, baseResponse.Success);
    }

    [Fact]
    public void BaseResponse_Message_SetAndGetCorrectly()
    {
        // Arrange
        var baseResponse = new BaseResponse(true);

        var message = "test mesaj"; // Set a message.
        // Act
        baseResponse.Message = message;

        // Assert
        Assert.Equal(message, baseResponse.Message);
    }

    [Fact]
    public void BaseResponse_Constructor_InitializesSuccessAndMessage()
    {
        // Arrange
        var success = true;
        var message = "test mesaj";

        // Act
        var baseResponse = new BaseResponse(success, message);

        // Assert
        Assert.Equal(success, baseResponse.Success);
        Assert.Equal(message, baseResponse.Message);
    }

    [Fact]
    public void BaseResponse_JsonConstructor_SetProperties()
    {
        // Arrange
        var success = true;
        var message = "test mesaj";

        // Act
        var baseResponse = new BaseResponse(success, message);

        // Assert
        Assert.Equal(success, baseResponse.Success);
        Assert.Equal(message, baseResponse.Message);
    }

    [Fact]
    public void BaseDataResponse_Data_SetAndGetCorrectly()
    {
        // Arrange And Act
        var dataResponse = new BaseDataResponse<string>("test",true);
        var data = "test"; // Set sample data.

        // Assert
        Assert.Equal(data, dataResponse.Data);
    }

    [Fact]
    public void BaseDataResponse_DataType_IsGeneric()
    {
        // Arrange And
        var dataResponse = new BaseDataResponse<int>(42,true);
        var data = 42; // Set an integer data.

        // Assert
        Assert.Equal(data, dataResponse.Data);
    }

    [Fact]
    public void BaseDataResponse_Data_Initialized()
    {
        // Arrange
        var dataResponse = new BaseDataResponse<int>(default,true);

        // Act and Assert
        Assert.NotNull(dataResponse.Data);
    }

    [Fact]
    public void BaseDataResponse_Data_NotNullByDefault()
    {
        // Arrange and Act
        var dataResponse = new BaseDataResponse<string>("",true);

        // Assert
        Assert.NotNull(dataResponse.Data);
    }

    [Fact]
    public void BaseDataResponse_JsonConstructor_SetProperties()
    {
        // Arrange
        var data = "test";
        var success = true;
        var message = "test";

        // Act
        var dataResponse = new BaseDataResponse<string>(data, success, message);

        // Assert
        Assert.Equal(data, dataResponse.Data);
        Assert.Equal(success, dataResponse.Success);
        Assert.Equal(message, dataResponse.Message);
    }
}
