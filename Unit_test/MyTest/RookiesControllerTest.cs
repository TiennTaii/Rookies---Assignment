using Moq;
using Assignment_three.Controllers;
using NUnit.Framework;
using Assignment_three.Services;
using Microsoft.Extensions.Logging;
using Assignment_three.Models;
using Microsoft.AspNetCore.Mvc;

namespace RookiesControllerTest;

public class Tests
{
    private RookiesController _rookiesController;
    private Mock<IPersonService> _personServiceMock;
    private Mock<ILogger<RookiesController>> _loggerMock;
    private static List<PersonModel> _data = new List<PersonModel>{
        new PersonModel
        {
            FirstName = "Tai",
            LastName = "Pham Tien",
            BirthPlace = "Vinh Phuc"
        }
    };

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<RookiesController>>();
        _personServiceMock = new Mock<IPersonService>();
        _rookiesController = new RookiesController(_loggerMock.Object, _personServiceMock.Object);
        _personServiceMock.Setup(q => q.GetAll()).Returns(_data);
    }

    [Test]
    public void GetAllMember_Success()
    {
        var result = _rookiesController.Index();

        Assert.IsInstanceOf<ViewResult>(result);

        var view = (ViewResult)result;

        Assert.IsInstanceOf<List<PersonModel>>(view.ViewData.Model);
        Assert.IsAssignableFrom<List<PersonModel>>(view.ViewData.Model);

        var list = (List<PersonModel>)view.ViewData.Model;

        Assert.AreEqual(1, list.Count());
    }
}